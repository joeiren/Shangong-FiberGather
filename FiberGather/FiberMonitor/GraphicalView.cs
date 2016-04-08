using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace FiberMonitor
{
    public partial class GraphicalView : UserControl
    {
        private readonly List<float[]> SaveDataList = new List<float[]>();
        private readonly List<List<float>> xArr = new List<List<float>>();
        private readonly List<List<float>> yArr = new List<List<float>>();
        private CFileOperation accFileOperation; //保存txt,相关代码注释
        private int drawValue; //这个drawValue推测为x轴的取值
        private Thread SaveThread;
        private bool SaveThreadFlag;

        public GraphicalView()
        {
            InitializeComponent();
        }

        private void GraphicalView_Load(object sender, EventArgs e)
        {
            zGraph1.m_SyStitle = "";
            zGraph1.m_SySnameX = "X";
            zGraph1.m_SySnameY = "Y";
            zGraph1.m_GraphBackColor = Color.FromArgb(255, 227, 227, 227);
            zGraph1.m_iLineShowColor = Color.FromArgb(255, 100, 100, 100);
            zGraph1.m_ControlItemBackColor = Color.White;

            label1.Text = "Time (" + (5/100f).ToString("F2") + "s per division)";

            accFileOperation = new CFileOperation();
            accFileOperation.SetSaveParam("电压", Global.SavePath, TimeSpan.FromMinutes(15), 50, "光纤解调仪数据");
            //保存部分已注释
            SaveThreadFlag = true;
            SaveThread = new Thread(SaveDataFile);
            SaveThread.Start();
        }

        private void SaveDataFile()
        {
            while (SaveThreadFlag)
            {
                if (SaveDataList.Count > 0)
                {
                    accFileOperation.WriteToFile(SaveDataList, SaveDataList.Count, 3);
                    SaveDataList.Clear();
                }
                Thread.Sleep(1000);
            }
        }

        public void SamplesChanged()
        {
            float v = Global.iSamples;
            label1.Text = "Time (" + (5/v).ToString("F2") + "s per division)";
            timer1.Interval = (int) ((5/v)*1000);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (Global.AIDataArr.Count > 0) //仅想表达其中有数据
            {
                if (drawValue/100 > 0)
                {
                    xArr[0].Clear();
                    yArr[0].Clear();
                }
                drawValue = drawValue%100;
                xArr[0].Add(drawValue);
                var arr = new List<float>();
                try
                {
                    arr.Add((float) Global.AIDataArr[0][0, Global.viewSensor]); //现只去第一批0-1数据
                    if (Global.AIDataArr[0][0, Global.viewSensor] != 1500)
                    {
                        label3.Text = "最后一个不是1500值是 " + Global.AIDataArr[0][0, Global.viewSensor];
                    }
                }
                catch (Exception hehe)
                {
                    comboBox2.Text = "1数据最大";
                    MessageBox.Show("这一通道没那么多个传感器,返回显示第一个.", "!");
                }
                yArr[0].AddRange(arr);
                Global.AIDataArr.Clear();
                drawValue++;
                zGraph1.Refresh();
            }
        }

        public void StartDrawWave()
        {
            xArr.Clear();
            yArr.Clear();
            for (var i = 0; i < Global.iChannelCount; i++)
            {
                xArr.Add(new List<float>());
                yArr.Add(new List<float>());
            }

            zGraph1.f_ClearAllPix();
            zGraph1.f_reXY();
            var x0 = xArr[0];
            var y0 = yArr[0];
            zGraph1.f_LoadOnePix(ref x0, ref y0, Color.Red, 2);

            //List<float> x1 = xArr[1];//添加第二条线失败
            //List<float> y1 = yArr[1];
            //zGraph1.f_AddPix(ref x1, ref y1, Color.Green, 2);
            timer1.Start();
        }

        public void StopDrawWave()
        {
            timer1.Stop();
        }

        public void ClearWave()
        {
            xArr[0].Clear();
            yArr[0].Clear();
            zGraph1.f_ClearAllPix();
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            xArr[0].Clear();
            yArr[0].Clear();
            drawValue = 0;
        }

        public void CloseSaveThread()
        {
            SaveThreadFlag = false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        { //选通道

            xArr[0].Clear();
            yArr[0].Clear();
            drawValue = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选传感器
            if (comboBox2.Text == "1数据最大")
            {
                Global.viewSensor = 0;
            }
            if (comboBox2.Text == "2")
            {
                Global.viewSensor = 1;
            }
            if (comboBox2.Text == "3")
            {
                Global.viewSensor = 2;
            }
            if (comboBox2.Text == "4")
            {
                Global.viewSensor = 3;
            }
            if (comboBox2.Text == "5")
            {
                Global.viewSensor = 4;
            }
            if (comboBox2.Text == "6")
            {
                Global.viewSensor = 5;
            }
            if (comboBox2.Text == "7")
            {
                Global.viewSensor = 6;
            }
            if (comboBox2.Text == "8")
            {
                Global.viewSensor = 7;
            }
            if (comboBox2.Text == "9")
            {
                Global.viewSensor = 8;
            }
            if (comboBox2.Text == "10数据最小")
            {
                Global.viewSensor = 9;
            }
            //这里补充
            xArr[0].Clear();
            yArr[0].Clear();
            drawValue = 0;
        }
    }
}