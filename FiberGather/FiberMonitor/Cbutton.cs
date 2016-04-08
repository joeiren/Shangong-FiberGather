using System;
using System.Windows.Forms;
using FiberMonitor.Properties;

namespace FiberMonitor
{
    public partial class Cbutton : UserControl
    {
        public bool m_bEnable = true;
        public bool m_bLock;

        public Cbutton()
        {
            InitializeComponent();
        }

        private void Cbutton_Load(object sender, EventArgs e)
        {
            BackgroundImage = Resources._111;
        }

        private void Cbutton_MouseMove(object sender, MouseEventArgs e)
        {
            if (!m_bLock)
            {
                BackgroundImage = Resources._222;
            }
        }

        private void Cbutton_MouseLeave(object sender, EventArgs e)
        {
            if (!m_bLock)
            {
                BackgroundImage = Resources._111;
            }
        }

        private void Cbutton_MouseClick(object sender, MouseEventArgs e)
        {
            if (!m_bLock)
            {
                BackgroundImage = Resources._333;
                m_bLock = true;

                if (Global.s_Main != null)
                {
                    Global.s_Main.ResetTab(this);
                }
            }
        }

        public void ResetState()
        {
            m_bLock = false;
            BackgroundImage = Resources._111;
            label1.Enabled = true;
            m_bEnable = true;
        }

        public void ButtonDown()
        {
            m_bLock = true;
            BackgroundImage = Resources._333;
        }

        public void SetText(string text)
        {
            label1.Text = text;
        }

        public void SetEnable(bool enable)
        {
            label1.Enabled = enable;
            m_bLock = !enable;
            m_bEnable = enable;
            if (!enable)
            {
                BackgroundImage = Resources.huise;
            }
        }
    }
}