using System;
using System.Linq;
using System.Windows.Forms;

namespace FiberMonitor
{
    public partial class NumericView : UserControl
    {
        public NumericView()
        {
            InitializeComponent();
        }

        private void NumericView_Load(object sender, EventArgs e)
        {
        }

        public void StopGet() //没效果
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e) //定时
        {
            if (Global.AIDataArr2.Count > 0) //仅想表达其中有数据
            {
                //准备取存放的数据显示,现取第一通道,由于用作测试
                //转变思路,取所有通道的数据,显于一处,(XX并考虑将XX)
                var c = Global.AIDataArr2; //原先采用list显示,现决定修改
                //
                var c0 = Global.AIDataArr2[0];
                var row = c0.GetLength(0);
                var col = c0.GetLength(1);
                var data = c0.Cast<double>().ToArray();
                var data2 = data.Take(col).Select(x => x.ToString()).ToArray();
                if (data2.Length > 0)
                {
                    listView1.Items.Add(new ListViewItem(data2));
                }
                Global.AIDataArr2.Clear(); //清空存放的数据
                //尝试加个if处理多余显示的数据
                if (listView1.Items.Count > 10)
                {
                    listView1.Items.Clear();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "第一通道")
            {
                Global.viewChannelN = 0;
                listView1.Items.Clear();
            }
            if (comboBox1.Text == "第二通道")
            {
                Global.viewChannelN = 1;
                listView1.Items.Clear();
            }
            if (comboBox1.Text == "第三通道")
            {
                Global.viewChannelN = 2;
                listView1.Items.Clear();
            }
            if (comboBox1.Text == "第四通道")
            {
                Global.viewChannelN = 3;
                listView1.Items.Clear();
            }
            if (comboBox1.Text == "第五通道")
            {
                Global.viewChannelN = 4;
                listView1.Items.Clear();
            }
            if (comboBox1.Text == "第六通道")
            {
                Global.viewChannelN = 5;
                listView1.Items.Clear();
            }
            if (comboBox1.Text == "第七通道")
            {
                Global.viewChannelN = 6;
                listView1.Items.Clear();
            }
            if (comboBox1.Text == "第八通道")
            {
                Global.viewChannelN = 7;
                listView1.Items.Clear();
            }
        }
    }
}