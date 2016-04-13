using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Corp.ShanGong.FiberInstrument.BizCore;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.IBizSpec;
using Corp.ShanGong.FiberInstrument.Model;
using Corp.ShanGong.FiberInstrument.Setting;
using Timer = System.Windows.Forms.Timer;

namespace Corp.ShanGong.FiberInstrument.Presentation
{
    public partial class FiberMainForm : Form
    {
        private static bool _running;
        private static Timer _renderTimer;
        private static Timer _mockTimer;
        private static readonly int _sendLocalPort = 9001;
        private static readonly int _gatherInterval = 100; //采样频率 10HZ(0.1)
        private readonly ConcurrentQueue<PhysicalQuantity> _toSaveQueue = new ConcurrentQueue<PhysicalQuantity>();
        private readonly ConcurrentQueue<PhysicalQuantity> _toSendQueue = new ConcurrentQueue<PhysicalQuantity>();
        private WaveFormViewData _waveViewData;
        private InstrumentOperation Operator;

        public FiberMainForm()
        {
            InitializeComponent();
            ReadProfile();
           
            GlobalSetting.Instance.DataFileLocalPath = textBoxDataFileLocalPath.Text;
            GlobalSetting.Instance.ChannelWay = Convert.ToInt32(comboBoxDeviceType.SelectedItem);
            InitListView();
            InitWaveControl();
            InitTimer();
            _waveViewData = new WaveFormViewData();
        }

        public int LocalPort
        {
            get
            {
                var text = textBoxLocalPort.Text.Trim();
                if (text.IsNumber())
                {
                    return Convert.ToInt32(textBoxLocalPort.Text.Trim());
                }
                return 0;
            }
        }

        public int RemotePort
        {
            get
            {
                return Convert.ToInt32(textBoxRemotePort.Text.Trim());
            }
        }

        public string RemoteIp
        {
            get
            {
                return textBoxRemote.Text.Trim();
            }
        }

        public int SendRemotePort
        {
            get
            {
                return Convert.ToInt32(textBoxSendRemotePort.Text.Trim());
            }
        }

        public string SendRemoteIp
        {
            get
            {
                return textBoxSendRemoteIp.Text.Trim();
            }
        }

        private void InitConnect()
        {
            try
            {
                if (Operator == null)
                {
                    Operator = new InstrumentOperation(LocalPort, RemoteIp, RemotePort);
                }
                else
                {
                    if (Operator.Communication.Local.Port != LocalPort ||
                        Operator.Communication.Remote.Port != RemotePort ||
                        Operator.Communication.Remote.Address.ToString() != RemoteIp)
                    {
                        Operator.Communication.Reset();
                        Operator = null;
                        Operator = new InstrumentOperation(LocalPort, RemoteIp, RemotePort);
                    }
                }
            }
            catch (Exception ex)
            {
                var bex = new BoundaryException("初始化UDP通道失败！", ex);
                AppendLog(bex.Display);
            }
        }

        private void ResetControls()
        {
            if (_running)
            {
                groupBoxSave.Enabled = true;
                buttonStart.Text = @"启动";
                buttonConnect.Enabled = true;
                _running = !_running;
            }
            else
            {
                groupBoxSave.Enabled = false;
                buttonStart.Text = @"停止";
                buttonConnect.Enabled = false;
                _running = !_running;
            }
        }

        private async Task RecData(CancellationToken token)
        {
            if (_running)
            {
                try
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }
                    var result = await Operator.ReadLoop(AppSetting.Container.Resolve<IPhysicalCalculator>());
                    if (result.Any())
                    {
                        _waveViewData.PushChannelWaveData(result.Last());
                        if (checkBoxSendData.Checked)
                        {
                            _toSendQueue.Enqueue(result.Last());
                        }
                        _toSaveQueue.Enqueue(result.Last());
                    }
                }
                catch (BoundaryException bex)
                {
                    if (token.CanBeCanceled)
                    {
                        _cancelSource.Cancel();
                        bex.Display += "\t数据接收已退出";
                    }
                    ControlRenderInvoke.SafeInvoke(textBoxLog, () => AppendLog(bex.Display));
                }
                catch (Exception ex)
                {
                    var bex = new BoundaryException(ex);
                    if (token.CanBeCanceled)
                    {
                        _cancelSource.Cancel();
                        bex.Display += "\t数据接收已退出";
                    }
                    ControlRenderInvoke.SafeInvoke(textBoxLog, () => AppendLog(bex.Display));
                }
            }
        }

        private void InitTimer()
        {
            _renderTimer = new Timer();
            _renderTimer.Interval = _gatherInterval; 
            _renderTimer.Tick += _renderTimer_Tick;

//            _mockTimer = new Timer();
//            _mockTimer.Interval = 50;
//            _mockTimer.Tick +=_mockTimer_Tick;
//            _mockTimer.Start();
        }

        private void _mockTimer_Tick(object aSender, EventArgs aE)
        {
            ShowWaveForm();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            WriteProfile();
            base.OnClosing(e);
            if (_renderTimer != null)
            {
                _renderTimer.Stop();
            }

            if (_running && Operator != null)
            {
                Task.Run(() => Operator.Stop());
            }
        }
        CancellationTokenSource _cancelSource = new CancellationTokenSource();
        private async Task NetRecData(CancellationToken token)
        {
            while (true)
            {
                await RecData(token).ContinueWith(task => task.Wait(token));
                if (token.IsCancellationRequested)
                {
                    break;
                }
            }
        }
        private void _renderTimer_Tick(object aSender, EventArgs aE)
        {
            //Task.Run(() =>
            {
                //RecData().ContinueWith(task => task.Wait());

                PhysicalQuantity sendQ;
                if (_toSendQueue.TryDequeue(out sendQ))
                {
                    try
                    {
                        Task.Run(() => new Action(async () =>
                        {
                            var send = new SendQuantityPackage(_sendLocalPort, SendRemoteIp, SendRemotePort, sendQ);
                            await send.SendData();
                        })());
                    }
                    catch (Exception ex)
                    {
                        var bex = new BoundaryException(ex);
                        AppendLog(bex.Message);
                    }
                }
                PhysicalQuantity quan;

                if (_toSaveQueue.TryDequeue(out quan))
                {
                    if (checkBoxEnableSaveLocal.Checked)
                    {
                        Task.Run(() =>
                        {
                            string[] dataArray;
                            if (GlobalSetting.Instance.EnableSaveTestData)
                            {
                                dataArray = quan.ToTestDataString();
                            }
                            else
                            {
                                dataArray = quan.ToDataString();
                            }
                            for (var i = 0; i < dataArray.Length; i++)
                            {
                                StressDataFile.SaveByChannel(dataArray[i], i + 1);
                            }
                           
                        });
                    }
                    
                    ControlRenderInvoke.SafeInvoke(listViewQuantity, () =>
                    {
                        try
                        {
                            if (listViewQuantity.Items.Count > 0)
                            {
                                for (var i = 0; i < GlobalSetting.Instance.SensorCount; i++)
                                {
                                    var item = listViewQuantity.Items[i];
                                    item.SubItems[0].Text = (i + 1).ToString();
                                    for (var j = 0; j < GlobalSetting.Instance.ChannelWay; j++)
                                    {
                                        var text = quan.ChannelValues[j].GratingValues[i].WaveLengthExtension.ToString();
                                        item.SubItems[j + 1].Text = text;
                                    }
                                }
                            }
                            else
                            {
                                for (var i = 0; i < GlobalSetting.Instance.SensorCount; i++)
                                {
                                    var textArray = new string[GlobalSetting.Instance.ChannelWay + 1];
                                    textArray[0] = "";
                                    for (var j = 0; j < GlobalSetting.Instance.ChannelWay; j++)
                                    {
                                        textArray[j + 1] =
                                            quan.ChannelValues[j].GratingValues[i].WaveLengthExtension.ToString();
                                    }

                                    listViewQuantity.Items.Add(new ListViewItem(textArray, -1));
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            var bex = new BoundaryException(ex);
                            AppendLog(bex.Display);
                        }
                    });
                }
            }
            //);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            try
            {
                InitConnect();
                var result = false;
                Task.Run(() => result = Operator.TestConnection().Result)
                    .ContinueWith(task => task.Wait())
                    .Wait();
                AppendLog(result ? "连接成功" : "连接失败");
            }
            catch (Exception ex)
            {
                var bex = new BoundaryException(ex);
                AppendLog(new[] { bex.Display, bex.DetailInfo });
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                InitConnect();
                if (!_running)
                {
                    var result = new Tuple<bool, string>(false, "");
                    Task.Run(() => result = Operator.Start().Result)
                        .ContinueWith(task => task.Wait())
                        .Wait();
                    if (!result.Item1)
                    {
                        AppendLog("启动失败！" + result.Item2);
                    }
                    else
                    {
                        ResetControls();
                        AppendLog("启动成功！");
                        _renderTimer.Start();
                        _cancelSource = new CancellationTokenSource();
                        Task.Run(() => NetRecData(_cancelSource.Token));

                        AppendLog(string.Format("数据接收已经开始！   本地数据保存{0}开启！  数据发送{1}开启！",
                            checkBoxEnableSaveLocal.Checked ? "已" : "未", checkBoxSendData.Checked ? "已" : "未"));
                    }
                }
                else
                {

                    _cancelSource.Cancel();
                    _cancelSource = null;
                    Task.Run(() => Operator.Stop().Result)
                        .ContinueWith(task => task.Wait())
                        .Wait();
                    _renderTimer.Stop();
                    ResetControls();
                    AppendLog("已经停止接收！");
                }
            }
            catch (BoundaryException bex)
            {
                AppendLog(new[] { bex.Display, bex.DetailInfo });
            }
        }
        
        private void buttonBrowser_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.ShowNewFolderButton = true;
            dialog.SelectedPath = textBoxDataFileLocalPath.Text;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBoxDataFileLocalPath.Text = dialog.SelectedPath;
                GlobalSetting.Instance.DataFileLocalPath = textBoxDataFileLocalPath.Text;
            }
        }

        private void checkBoxSendData_CheckedChanged(object sender, EventArgs e)
        {
            this.labelSendIp.Visible = checkBoxSendData.Checked;
            this.labelSendPort.Visible = checkBoxSendData.Checked;
            this.textBoxSendRemoteIp.Visible = checkBoxSendData.Checked;
            this.textBoxSendRemotePort.Visible = checkBoxSendData.Checked;
        }

        private void checkBoxEnableSaveLocal_CheckedChanged(object sender, EventArgs e)
        {
            labelLocalPath.Visible = checkBoxEnableSaveLocal.Checked;
            textBoxDataFileLocalPath.Visible = checkBoxEnableSaveLocal.Checked;
            buttonBrowser.Visible = checkBoxEnableSaveLocal.Checked;
        }

        private void ReadProfile()
        {
            textBoxLocalPort.Text = OperateIniFile.ReadIniData("basic", "LocalPort", "8001", "profile.ini");
            var index = OperateIniFile.ReadIniData("basic", "ChannelWayIndex", "0", "profile.ini");
            comboBoxDeviceType.SelectedIndex = string.IsNullOrEmpty(index) ? 0 : Convert.ToInt32(index);
            checkBoxEnableSaveLocal.Checked = (OperateIniFile.ReadIniData("save", "EnableLocalSave", "0", "profile.ini") != "0");
            textBoxDataFileLocalPath.Text = OperateIniFile.ReadIniData("save", "LocalPath", "D:\\", "profile.ini");

            checkBoxSendData.Checked = (OperateIniFile.ReadIniData("save", "EnableSendData", "0", "profile.ini") != "0");
            textBoxSendRemoteIp.Text = OperateIniFile.ReadIniData("save", "SendRemoteIp", "192.168.0.19", "profile.ini");
            textBoxSendRemotePort.Text = OperateIniFile.ReadIniData("save", "SendRemotePort", "9000", "profile.ini");

            checkBoxEnableSaveDB.Checked = (OperateIniFile.ReadIniData("save", "EnableSaveDB", "0", "profile.ini") != "0");
        }

        private void WriteProfile()
        {
            OperateIniFile.WriteIniData("basic", "LocalPort", textBoxLocalPort.Text.Trim(), "profile.ini");
            OperateIniFile.WriteIniData("basic", "ChannelWayIndex", comboBoxDeviceType.SelectedIndex.ToString(), "profile.ini");

            OperateIniFile.WriteIniData("save", "EnableLocalSave", checkBoxEnableSaveLocal.Checked ? "1" : "0","profile.ini");
            OperateIniFile.WriteIniData("save", "LocalPath", textBoxDataFileLocalPath.Text, "profile.ini");

            OperateIniFile.WriteIniData("save", "EnableSendData", checkBoxSendData.Checked ? "1" : "0", "profile.ini");
            OperateIniFile.WriteIniData("save", "SendRemoteIp", textBoxSendRemoteIp.Text, "profile.ini");
            OperateIniFile.WriteIniData("save", "SendRemotePort", textBoxSendRemotePort.Text, "profile.ini");
            OperateIniFile.WriteIniData("save", "EnableSaveDB", checkBoxEnableSaveDB.Checked ? "1" : "0", "profile.ini");
        }

        private void AppendLog(string[] append)
        {
            var ori = textBoxLog.Lines;
            Array.ForEach(append, it => it.StartWithDateStamp());
            textBoxLog.Lines = ori.Concat(append).ToArray();
            textBoxLog.Select(textBoxLog.TextLength, 1);
            textBoxLog.ScrollToCaret();
        }

        private void AppendLog(string append)
        {
            var ori = textBoxLog.Lines;
            textBoxLog.Lines = ori.Concat(new[] { append.StartWithDateStamp() }).ToArray();
            textBoxLog.Select(textBoxLog.TextLength, 1);
            textBoxLog.ScrollToCaret();
        }

        private void comboBoxDeviceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            GlobalSetting.Instance.ChannelWay = Convert.ToInt32(comboBoxDeviceType.SelectedItem);
            InitListView();
        }

      
    }
}