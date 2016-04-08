using System.Collections.Generic;

namespace FiberMonitor
{
    /// <summary>
    ///     单通道内容,频率
    /// </summary>
    internal class ChannelA
    {
        private static int ID; //通道号                         //数据混乱几率大,故使用字典
        private static Dictionary<int, int> GrathingList; //光栅列表,频率数据 3*16值的列表
        private static int Temp; //管壳温度两个值
    }

    /// <summary>
    ///     另一种单通道内容,数据
    /// </summary>
    internal class ChannelB
    {
        private static int ID;
        private static int Data; //数据
        private static int Step; //步长
    }
}