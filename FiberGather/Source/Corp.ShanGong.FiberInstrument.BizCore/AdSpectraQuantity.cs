using System;
using System.Collections.Generic;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.Model;
using Corp.ShanGong.FiberInstrument.Setting;

namespace Corp.ShanGong.FiberInstrument.BizCore
{
    /// <summary>
    ///     光谱 AD数据量
    /// </summary>
    public class AdSpectraQuantity
    {
        private AdSpectraQuantity()
        {
            ChannelValues = new Dictionary<decimal, long?>[GlobalSetting.Instance.ChannelWay];
            ChannelValues.Init(GlobalSetting.Instance.ChannelWay);
        }

        public Dictionary<decimal, long?>[] ChannelValues
        {
            get;
            private set;
        }

        public static AdSpectraQuantity LoadForm(AdMessage message)
        {
            try
            {
                var instance = new AdSpectraQuantity();

                for (var i = 0; i < GlobalSetting.Instance.ChannelWay; i++)
                {
                    instance.ChannelValues[i] = QuantityValuePair.CalcAdOrignal(message.Channels[i].DataRanges);
                }
                return instance;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public class ChannelQuantity
        {
            /// <summary>
            ///     传感器物理数据
            /// </summary>
            public QuantityValuePair[] SpectraValues
            {
                get;
                set;
            }
        }
    }
}