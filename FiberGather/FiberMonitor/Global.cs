using System.Collections.Generic;

namespace FiberMonitor
{
    public static class Global
    {
        public static MainForm s_Main = null;
        public static string SavePath = "D:\\";
        public static bool bConnect = true;
        public static int iSamples = 100;
        public static string Ip = "见DataTCPClient.cs"; //显示
        public static int iChannelCount = 8;
        public static int iChannelArray = 13;
        public static List<double[,]> AIDataArr = new List<double[,]>(); //图形显示之用
        public static List<double[,]> AIDataArr2 = new List<double[,]>(); //列表显示之用
        public static int viewChannelG = 0; //供选取通道图形
        public static int viewSensor = 0; //供选取传感器
        public static int viewChannelN = 0; //供选取通道列表
    }
}