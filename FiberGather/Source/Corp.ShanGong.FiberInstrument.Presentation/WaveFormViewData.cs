using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.BizCore;

namespace Corp.ShanGong.FiberInstrument.Presentation
{
    public class WaveFormViewData
    {
        public const int WAVE_QUEUE_MAX_CAPCITY = 500;
        public ConcurrentQueue<PhysicalQuantity> DisplayChannelWaveQueue
        {
            get;
            private set;
        }

        public void PushChannelWaveData(PhysicalQuantity item)
        {
            if (item == null)
            {
                return;
            }
            if (DisplayChannelWaveQueue == null)
            {
                DisplayChannelWaveQueue = new ConcurrentQueue<PhysicalQuantity>();
            }
            
            if (DisplayChannelWaveQueue.Count >= WAVE_QUEUE_MAX_CAPCITY)
            {
                PhysicalQuantity quan = null;
                DisplayChannelWaveQueue.TryDequeue(out quan);
            }
            DisplayChannelWaveQueue.Enqueue(item);
        }

        public List<PhysicalQuantity> TakeMoreChannelWaveData(int count)
        {
            if (DisplayChannelWaveQueue == null)
            {
                return null;
            }
            var result = new List<PhysicalQuantity>();
            
            for (var i = 0; i < Math.Min(count, DisplayChannelWaveQueue.Count); i++)
            {
                PhysicalQuantity item = null;
                if (DisplayChannelWaveQueue.TryDequeue(out item))
                {
                    result.Add(item);
                }
            }
            
            return result;
        }


    }
}
