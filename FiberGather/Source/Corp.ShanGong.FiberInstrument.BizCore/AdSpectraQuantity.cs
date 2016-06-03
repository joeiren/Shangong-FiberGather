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
        public static readonly int MESSAGE_LENGTH = 2 + GlobalStaticSetting.Instance.ChannelWay * (5102 + 2);
        private AdSpectraQuantity()
        {
            ChannelValues = new Dictionary<decimal, long?>[GlobalStaticSetting.Instance.ChannelWay];
            ChannelValues.Init(GlobalStaticSetting.Instance.ChannelWay);
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

                for (var i = 0; i < GlobalStaticSetting.Instance.ChannelWay; i++)
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