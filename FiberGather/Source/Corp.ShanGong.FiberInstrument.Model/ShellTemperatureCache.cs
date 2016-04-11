using System.Collections.Generic;
using System.Linq;
using Corp.ShanGong.FiberInstrument.Setting;

namespace Corp.ShanGong.FiberInstrument.Model
{
    /// <summary>
    ///     管壳温度缓存，滚动1000个后可精确计算管壳温度
    /// </summary>
    public class ShellTemperatureCache
    {
//        static ShellTemperatureCache()
//        {
//            TempQueueDic = new Dictionary<int, Queue<decimal>>();
//            for(int i=0; i<GlobalSetting.Instance.ChannelWay; i++)
//            {
//                Queue<decimal> q = new Queue<decimal>(1000);
//                TempQueueDic.Add(i, q);
//            }
//        }

        public ShellTemperatureCache()
        {
            TempQueueDic = new Dictionary<int, Queue<decimal>>();
            for (var i = 0; i < GlobalSetting.Instance.ChannelWay; i++)
            {
                var q = new Queue<decimal>(1000);
                TempQueueDic.Add(i, q);
            }
        }

        public Dictionary<int, Queue<decimal>> TempQueueDic
        {
            get;

            private set;
        }

        public void Push(int index, decimal temp)
        {
            var q = TempQueueDic[index];
            if (q.Count == 1000)
            {
                q.Dequeue();
            }
            q.Enqueue(temp);
        }

        public decimal AverageTemperature(int index)
        {
            if (!TempQueueDic.ContainsKey(index))
            {
                return default(decimal);
            }
            var q = TempQueueDic[index];
            return q.Average();
        }
    }
}