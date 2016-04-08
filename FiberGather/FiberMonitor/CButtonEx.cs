using System;
using System.Drawing;
using System.Windows.Forms;

namespace FiberMonitor
{
    public partial class CButtonEx : UserControl
    {
        public bool bDown;
        public bool bEnable = true;
        public Image cursor = null;
        public Image cursor2 = null;
        public Image disable = null;
        public Image down = null;
        public Image normal = null;
        private string sText1 = "";
        private string sText2 = "";

        public CButtonEx()
        {
            InitializeComponent();
        }

        private void CButtonEx_Load(object sender, EventArgs e)
        {
            BackgroundImage = normal;
        }

        private void CButtonEx_MouseClick(object sender, MouseEventArgs e)
        {
            if (bEnable)
            {
                if (bDown)
                {
                    BackgroundImage = normal;
                    label1.Text = sText1;
                }
                else
                {
                    BackgroundImage = down;
                    label1.Text = sText2;
                }
                bDown = !bDown;
            }
        }

        private void CButtonEx_MouseMove(object sender, MouseEventArgs e)
        {
            if (bEnable)
            {
                if (bDown)
                {
                    BackgroundImage = cursor2;
                }
                else
                {
                    BackgroundImage = cursor;
                }
            }
        }

        private void CButtonEx_MouseLeave(object sender, EventArgs e)
        {
            if (bEnable)
            {
                if (bDown)
                {
                    BackgroundImage = down;
                }
                else
                {
                    BackgroundImage = normal;
                }
            }
        }

        public void ResetState()
        {
            label1.Enabled = true;
            bDown = false;
            bEnable = true;

            BackgroundImage = normal;
        }

        public void SetText(string textUp, string textDown)
        {
            label1.Text = textUp;

            sText1 = textUp;
            sText2 = textDown;
        }

        public void DisableButton()
        {
            bEnable = false;
            bDown = false;
            BackgroundImage = disable;
            label1.Enabled = false;
        }

        public void SetLablePos(Point pos)
        {
            label1.Location = pos;
        }
    }
}