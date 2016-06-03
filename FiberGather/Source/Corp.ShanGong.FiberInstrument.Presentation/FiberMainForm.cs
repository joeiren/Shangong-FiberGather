using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autofac;
using Corp.ShanGong.FiberInstrument.BizCore;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.DataPersistence;
using Corp.ShanGong.FiberInstrument.IBizSpec;
using Corp.ShanGong.FiberInstrument.Model.LocalSelf;
using Corp.ShanGong.FiberInstrument.Setting;

using Timer = System.Windows.Forms.Timer;

namespace Corp.ShanGong.FiberInstrument.Presentation
{
    public partial class FiberMainForm : Form
    {
        private static bool _running;
        private static Timer _renderTimer;
        private static readonly int _gatherInterval = 100; //页面刷新频率 10HZ(0.1)
        private static ConcurrentQueue<PhysicalQuantity> _toRefreshQueue = new ConcurrentQueue<PhysicalQuantity>();
        private static ConcurrentQueue<PhysicalQuantity> _toSaveQueue = new ConcurrentQueue<PhysicalQuantity>();
        private static ConcurrentQueue<PhysicalQuantity> _toSendQueue = new ConcurrentQueue<PhysicalQuantity>();
        private static ConcurrentQueue<PhysicalQuantity> _toDbQueue = new ConcurrentQueue<PhysicalQuantity>();
        private static ConcurrentQueue<AdSpectraQuantity> _adQueue = new ConcurrentQueue<AdSpectraQuantity>();
        private static bool _isDebugMode = false;
        private static int _localSaveLoop = 1;
        private static int _netSendLoop = 1;
        private static int _dbSaveLoop = 1;
        private WaveFormViewData _waveViewData;
        private InstrumentOperation Operator;

        public FiberMainForm()
        {
            InitializeComponent();
            ReadProfile();
            
            InitListView();
            InitWaveControl();
            InitAdChart();
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
                numUDCollect.Enabled = true;
                _running = !_running;
            }
            else
            {
                groupBoxSave.Enabled = false;
                buttonStart.Text = @"停止";
                buttonConnect.Enabled = false;
                numUDCollect.Enabled = false;
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
                    if (_isDebugMode)
                    {
                        var result = await Operator.ReadLoopAd();
                        _adQueue.Enqueue(result);
                    }
                    else
                    {
                        var result = await Operator.ReadLoop(AppSetting.Container.Resolve<IPhysicalCalculator>());
                        if (result.Any())
                        {
                            _toRefreshQueue.Enqueue(result.Last());
                            //EnqueuData(result);                        
                        }
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

        private void EnqueuData(PhysicalQuantity result)
        {
            _waveViewData.PushChannelWaveData(result);
            if (checkBoxEnableSaveLocal.Checked)
            {
                if (_localSaveLoop == Math.Max(1, SystemConfigLoader.SystemConfig.LocalDataInterval))
                {
                    _toSaveQueue.Enqueue(result);
                    _localSaveLoop = 1;
                }
                else
                {
                    _localSaveLoop++;
                }
            }

            if (checkBoxSendData.Checked)
            {
                if (_netSendLoop == Math.Max(1, SystemConfigLoader.SystemConfig.NetDataInterval))
                {
                    _toSendQueue.Enqueue(result);
                    _netSendLoop = 1;
                }
                else
                {
                    _netSendLoop++;
                }
            }

            if (checkBoxEnableSaveDB.Checked)
            {
                if (_dbSaveLoop == Math.Max(1, SystemConfigLoader.SystemConfig.DbDataInterval))
                {
                    _toDbQueue.Enqueue(result);
                    _dbSaveLoop = 1;
                }
                else
                {
                    _dbSaveLoop++;
                }
            }
        }

        private void ClearQueueData()
        {
            _toRefreshQueue = new ConcurrentQueue<PhysicalQuantity>();
            _toDbQueue = new ConcurrentQueue<PhysicalQuantity>();
            _toSaveQueue = new ConcurrentQueue<PhysicalQuantity>();
            _toSendQueue = new ConcurrentQueue<PhysicalQuantity>();
            _adQueue = new ConcurrentQueue<AdSpectraQuantity>();
        }

        private void InitTimer()
        {
            _renderTimer = new Timer();
            _renderTimer.Interval = _gatherInterval; 
            _renderTimer.Tick += _renderTimer_Tick;
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
            
            AdSpectraQuantity adQuan;
            if (_isDebugMode)
            {
                if (_adQueue.TryDequeue(out adQuan))
                {
                    ControlRenderInvoke.SafeInvoke(plotViewAdChart, () => { FillAdPoint(adQuan); });
                    Task.Run(() =>
                        {
                            var result = Operator.StartWithDebug().Result;
                        }).ContinueWith(task => task.Wait()).Wait();
                }
                return;
            }
            PhysicalQuantity quan;
            // 界面刷新    
            if (_toRefreshQueue.TryDequeue(out quan))
            {
                EnqueuData(quan);
                ControlRenderInvoke.SafeInvoke(listViewQuantity, () =>
                {
                    try
                    {
                        if (listViewQuantity.Items.Count > 0)
                        {
                            for (var i = 0; i < GlobalStaticSetting.Instance.SensorCount; i++)
                            {
                                var item = listViewQuantity.Items[i];
                                item.SubItems[0].Text = (i + 1).ToString();
                                for (var j = 0; j < GlobalStaticSetting.Instance.ChannelWay; j++)
                                {
                                    var text = quan.ChannelValues[j].GratingValues[i].WaveLengthExtension.ToString();
                                    item.SubItems[j + 1].Text = text;
                                }
                            }
                        }
                        else
                        {
                            for (var i = 0; i < GlobalStaticSetting.Instance.SensorCount; i++)
                            {
                                var textArray = new string[GlobalStaticSetting.Instance.ChannelWay + 1];
                                textArray[0] = "";
                                for (var j = 0; j < GlobalStaticSetting.Instance.ChannelWay; j++)
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

            //通过UDP 发送数据
            PhysicalQuantity sendQ;
            if (_toSendQueue.TryDequeue(out sendQ))
            {
                try
                {
                    Task.Run(() => new Action(async () =>
                    {
                        var send = new SendQuantityPackage(SystemConfigLoader.SystemConfig.NetDataLocalPort, SendRemoteIp, SendRemotePort, sendQ);
                        await send.SendData();
                    })());
                }
                catch (Exception ex)
                {
                    var bex = new BoundaryException(ex);
                    AppendLog(bex.Message);
                }
            }           

            //本地文件保存
            PhysicalQuantity saveQuan;
            if (_toSaveQueue.TryDequeue(out saveQuan))
            {                
                Task.Run(() =>
                {
                    string[] dataArray;
                    if (GlobalStaticSetting.Instance.EnableSaveTestData)
                    {
                        dataArray = saveQuan.ToTestDataString();
                    }
                    else
                    {
                        dataArray = saveQuan.ToPhysicalWaveDataString();
                    }
                    for (var i = 0; i < dataArray.Length; i++)
                    {
                        StressDataFile.SaveByChannel(dataArray[i], i + 1);
                    }
                });
            }
            PhysicalQuantity dbQuan;
            // 数据库保存
            if (_toDbQueue.TryDequeue(out dbQuan))
            {
                Task.Run(() => SendDataToDb.Save(dbQuan, AppSetting.Container.Resolve<IDataPersistence>()));
            }
                       
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
                WriteProfile();
                if (!_running)
                {
                    var result = new Tuple<bool, string>(false, "");
                   
                    if (checkBoxDebugMode.Checked) // 光谱
                    {
                        _isDebugMode = true;
                        Task.Run(() => 
                        {
                            result = Operator.StartWithDebug().Result;
                        }).ContinueWith(task => task.Wait()).Wait();
                    }
                    else
                    {
                        _isDebugMode = false;
                        Task.Run(() => result = Operator.Start().Result).ContinueWith(task => task.Wait()).Wait();
                    }
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
                    ClearQueueData();
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
                SystemConfigLoader.SystemConfig.LocalRootPath = textBoxDataFileLocalPath.Text;
            }
        }

        private void checkBoxSendData_CheckedChanged(object sender, EventArgs e)
        {
            this.labelSendIp.Visible = checkBoxSendData.Checked;
            this.labelSendPort.Visible = checkBoxSendData.Checked;
            this.textBoxSendRemoteIp.Visible = checkBoxSendData.Checked;
            this.textBoxSendRemotePort.Visible = checkBoxSendData.Checked;
            this.labelSendInterval.Visible = checkBoxSendData.Checked;
            this.numUDNetSendInterval.Visible = checkBoxSendData.Checked;
        }

        private void checkBoxEnableSaveLocal_CheckedChanged(object sender, EventArgs e)
        {
            labelLocalPath.Visible = checkBoxEnableSaveLocal.Checked;
            textBoxDataFileLocalPath.Visible = checkBoxEnableSaveLocal.Checked;
            buttonBrowser.Visible = checkBoxEnableSaveLocal.Checked;
            this.labelLocalSaveInterval.Visible = checkBoxEnableSaveLocal.Checked;
            this.numUDLocalSaveInterval.Visible = checkBoxEnableSaveLocal.Checked;
        }

        private void checkBoxEnableSaveDB_CheckedChanged(object sender, EventArgs e)
        {
            this.labelDbConfig.Visible = checkBoxEnableSaveDB.Checked;
            this.textBoxDbConfigString.Visible = checkBoxEnableSaveDB.Checked;
            this.labelDbSaveInterval.Visible = checkBoxEnableSaveDB.Checked;
            this.numUDDbSaveInterval.Visible = checkBoxEnableSaveDB.Checked;
        }
        private void ReadProfile()
        {
            textBoxLocalPort.Text = OperateIniFile.ReadIniData("basic", "LocalPort", "8001", "profile.ini");
            
            checkBoxEnableSaveLocal.Checked = (OperateIniFile.ReadIniData("save", "EnableLocalSave", "0", "profile.ini") != "0");
            textBoxDataFileLocalPath.Text = OperateIniFile.ReadIniData("save", "LocalPath", "D:\\", "profile.ini");

            checkBoxSendData.Checked = (OperateIniFile.ReadIniData("save", "EnableSendData", "0", "profile.ini") != "0");
            textBoxSendRemoteIp.Text = OperateIniFile.ReadIniData("save", "SendRemoteIp", "192.168.0.19", "profile.ini");
            textBoxSendRemotePort.Text = OperateIniFile.ReadIniData("save", "SendRemotePort", "9000", "profile.ini");

            checkBoxEnableSaveDB.Checked = (OperateIniFile.ReadIniData("save", "EnableSaveDB", "0", "profile.ini") != "0");


            SystemPreference sysPreference = SystemConfigLoader.SystemConfig;
            if (sysPreference != null)
            {
                textBoxRemote.Text = sysPreference.HostIp;
                checkBoxEnableSaveDB.Checked = sysPreference.EnableDbData;
                checkBoxEnableSaveLocal.Checked = sysPreference.EnableLocalData;
                checkBoxSendData.Checked = sysPreference.EnableNetData;
                textBoxDataFileLocalPath.Text = sysPreference.LocalRootPath;
                textBoxRemotePort.Text = sysPreference.HostPort.ToString();
                textBoxLocalPort.Text = sysPreference.LocalPort.ToString();
                textBoxSendRemoteIp.Text = sysPreference.NetDataRemoteIp;
                textBoxSendRemotePort.Text = sysPreference.NetDataRemotePort.ToString();

                textBoxDbConfigString.Text = sysPreference.DbConfigString;
                numUDCollect.Value = Math.Max(1, sysPreference.CollectInterval);
                numUDLocalSaveInterval.Value = Math.Max(1, sysPreference.LocalDataInterval);
                numUDNetSendInterval.Value = Math.Max(1, sysPreference.NetDataInterval);
                numUDDbSaveInterval.Value = Math.Max(1, sysPreference.DbDataInterval);
            }
        }

        private void WriteProfile()
        {
            OperateIniFile.WriteIniData("basic", "LocalPort", textBoxLocalPort.Text.Trim(), "profile.ini");        
            OperateIniFile.WriteIniData("save", "EnableLocalSave", checkBoxEnableSaveLocal.Checked ? "1" : "0","profile.ini");
            OperateIniFile.WriteIniData("save", "LocalPath", textBoxDataFileLocalPath.Text, "profile.ini");
            OperateIniFile.WriteIniData("save", "EnableSendData", checkBoxSendData.Checked ? "1" : "0", "profile.ini");
            OperateIniFile.WriteIniData("save", "SendRemoteIp", textBoxSendRemoteIp.Text, "profile.ini");
            OperateIniFile.WriteIniData("save", "SendRemotePort", textBoxSendRemotePort.Text, "profile.ini");
            OperateIniFile.WriteIniData("save", "EnableSaveDB", checkBoxEnableSaveDB.Checked ? "1" : "0", "profile.ini");

            SystemPreference sysPreference = SystemConfigLoader.SystemConfig;
            if (sysPreference != null)
            {
                //sysPreference.HostIp = textBoxRemote.Text;
                sysPreference.EnableDbData = checkBoxEnableSaveDB.Checked;
                sysPreference.EnableLocalData = checkBoxEnableSaveLocal.Checked;

                sysPreference.EnableNetData = checkBoxSendData.Checked;
                sysPreference.LocalRootPath = textBoxDataFileLocalPath.Text;
                sysPreference.HostPort = string.IsNullOrEmpty(textBoxRemotePort.Text) ? 0 : Convert.ToInt32(textBoxRemotePort.Text);
                sysPreference.LocalPort = string.IsNullOrEmpty(textBoxLocalPort.Text) ? 0 : Convert.ToInt32(textBoxLocalPort.Text);
                sysPreference.NetDataRemoteIp = textBoxSendRemoteIp.Text;
                sysPreference.NetDataRemotePort = string.IsNullOrEmpty(textBoxSendRemotePort.Text)
                    ? 0 : Convert.ToInt32(textBoxSendRemotePort.Text);
              
                sysPreference.DbConfigString = textBoxDbConfigString.Text;
                sysPreference.CollectInterval = (int)numUDCollect.Value;
                sysPreference.LocalDataInterval = (int)numUDLocalSaveInterval.Value;
                sysPreference.NetDataInterval = (int)numUDNetSendInterval.Value;
                sysPreference.DbDataInterval = (int)numUDDbSaveInterval.Value;


                SystemConfigLoader.SystemConfig = sysPreference;
            }
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

        private void numUD_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown num = sender as NumericUpDown;
            num.Value = ResetNumValue(num.Value, num.Minimum, num.Maximum, num.Increment);
           
        }

        private decimal ResetNumValue(decimal @value, decimal min, decimal max, decimal increment)
        {
            if (@value > min && @value < max)
            {
                if (@value % increment != 0)
                {
                    @value = (@value % increment) * increment;
                }
            }
            return @value;
        }

        private void checkBoxDebugMode_CheckedChanged(object sender, EventArgs e)
        {
            this.comboBoxChannel.Visible = checkBoxDebugMode.Checked;
        }

    }
}