using System;
using System.Drawing;
using System.Windows.Forms;
using FiberMonitor.Properties;

namespace FiberMonitor
{
    public partial class MainForm : Form
    {
        private int m_tabIndex;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Global.s_Main = this;

            cbutton1.SetText("Graphical View");
            cbutton2.SetText("Numeric View");
            cbutton3.SetText("Power Monitor");
            cbutton4.SetText("FFT View");

            cbutton1.ButtonDown();
            cbutton3.SetEnable(false);

            cButtonEx1.SetText("Connect", "Connected");
            cButtonEx1.SetLablePos(new Point(5, 38));
            cButtonEx1.normal = Resources.connect1;
            cButtonEx1.cursor = Resources.connect2;
            cButtonEx1.cursor2 = Resources.connect4;
            cButtonEx1.down = Resources.connect3;
            cButtonEx1.ResetState();

            cButtonEx2.SetText("Start", "Pause");
            cButtonEx2.SetLablePos(new Point(15, 38));
            cButtonEx2.normal = Resources.start1;
            cButtonEx2.cursor = Resources.start2;
            cButtonEx2.cursor2 = Resources.pause2;
            cButtonEx2.down = Resources.pause1;
            cButtonEx2.disable = Resources.start3;
            cButtonEx2.ResetState();
            cButtonEx2.DisableButton();

            cButtonEx3.SetText("Exit", "Exit");
            cButtonEx3.SetLablePos(new Point(10, 38));
            cButtonEx3.normal = Resources.exit1;
            cButtonEx3.cursor = Resources.exit2;
            cButtonEx3.cursor2 = Resources.exit2;
            cButtonEx3.down = Resources.exit1;
            //cButtonEx3.disable = Properties.Resources.start3;
            cButtonEx3.ResetState();

            cButtonEx4.SetText("Save", "Save");
            cButtonEx4.SetLablePos(new Point(17, 38));
            cButtonEx4.normal = Resources.save1;
            cButtonEx4.cursor = Resources.save2;
            cButtonEx4.cursor2 = Resources.save2;
            cButtonEx4.down = Resources.save1;
            cButtonEx4.disable = Resources.save3;
            cButtonEx4.ResetState();
            cButtonEx4.DisableButton();

            TabBtnIndexChanged(m_tabIndex);

            labelDate.Text = DateTime.Now.ToString("HH:mm:ss\r\nyyyy-MM-dd");

            InitParams();

            timer1.Start();

            //DataTCPClinet.ConnectServerThread();
            //-------------------------------
            //UdpClient client = null;
            //string receiveString = null;
            //byte[] receiveData = null;
        }

        private void TabBtnIndexChanged(int index)
        {
            if (index == 0)
            {
                graphicalView1.Show();
                numericView1.Hide();
            }
            else if (index == 1)
            {
                numericView1.Show();
                graphicalView1.Hide();
            }
            else if (index == 2)
            {
            }
            else if (index == 3)
            {
            }
        }

        private void TabButtonClicked(Cbutton cbtn)
        {
            if (cbtn == cbutton1)
            {
                if (m_tabIndex == 0 || !cbtn.m_bEnable)
                {
                    return;
                }
                m_tabIndex = 0;
            }
            else if (cbtn == cbutton2)
            {
                if (m_tabIndex == 1 || !cbtn.m_bEnable)
                {
                    return;
                }
                m_tabIndex = 1;
            }
            else if (cbtn == cbutton3)
            {
                if (m_tabIndex == 2 || !cbtn.m_bEnable)
                {
                    return;
                }
                m_tabIndex = 2;
            }
            else if (cbtn == cbutton4 || !cbtn.m_bEnable)
            {
                if (m_tabIndex == 3)
                {
                    return;
                }
                m_tabIndex = 3;
            }
            TabBtnIndexChanged(m_tabIndex);
        }

        public void InitParams()
        {
            txtIP.Text = Global.Ip;
            textBox1.Text = Global.SavePath;
            if (comboBox1.Items.Contains(Global.iSamples.ToString()))
            {
                comboBox1.SelectedItem = Global.iSamples.ToString();
            }
        }

        public void ResetTab(Cbutton cbtn)
        {
            if (cbutton1 != cbtn && cbutton1.m_bEnable)
            {
                cbutton1.ResetState();
            }
            if (cbutton2 != cbtn && cbutton2.m_bEnable)
            {
                cbutton2.ResetState();
            }
            if (cbutton3 != cbtn && cbutton3.m_bEnable)
            {
                cbutton3.ResetState();
            }
            if (cbutton4 != cbtn && cbutton4.m_bEnable)
            {
                cbutton4.ResetState();
            }

            TabButtonClicked(cbtn);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelDate.Text = DateTime.Now.ToString("HH:mm:ss\r\nyyyy-MM-dd");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            dialog.Description = "请选择文件路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Global.SavePath = dialog.SelectedPath;
                textBox1.Text = Global.SavePath;
            }
        }

        private void cButtonEx3_MouseClick(object sender, MouseEventArgs e)
        {
            Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("退出?", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
            else
            {
                //  DataTCPClinet.DisConnect();
                graphicalView1.CloseSaveThread();
            }
        }

        /// <summary>
        ///     connect button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cButtonEx1_MouseClick(object sender, MouseEventArgs e)
        {
            if (Global.bConnect)
            {
                cButtonEx2.ResetState();
                cButtonEx4.ResetState();
            }
            else
            {
                cButtonEx2.DisableButton();
                cButtonEx4.DisableButton();

                graphicalView1.StopDrawWave();
                graphicalView1.ClearWave();
            }
        }

        private void cButtonEx4_MouseClick(object sender, MouseEventArgs e)
        {
            MessageBox.Show("Saved successfully", "提示");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Global.iSamples = int.Parse(comboBox1.SelectedItem.ToString());
            graphicalView1.SamplesChanged();
        }

        /// <summary>
        ///     start/pause button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cButtonEx2_MouseClick(object sender, MouseEventArgs e)
        {
            if (cButtonEx2.bDown)
            {
                graphicalView1.StartDrawWave();
            }
            else
            {
                graphicalView1.StopDrawWave();
            }
        }
    }
}