using System.Collections.Generic;

namespace FiberMonitor
{
    /// <summary>
    ///     存储返回的数据的类
    /// </summary>
    internal class ModeData
    {
        private static int ID; //设备id 
        private static int FCode; //功能码
        private static List<ChannelA> ChanAList;
        private static List<ChannelB> ChanBList; //两种可能出现的数据
    }
}