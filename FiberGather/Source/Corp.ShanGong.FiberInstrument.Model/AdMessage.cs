using System.Linq;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.Setting;

namespace Corp.ShanGong.FiberInstrument.Model
{
    /// <summary>
    ///     光谱报文数据（AD数据）
    /// </summary>
    public class AdMessage : IMessageParse
    {
        public static readonly int AD_DATA_MESSAGE_LENGTH = 2 +
                                                            ChannelMessage.CHANNEL_MESSAGE_LENGTH*
                                                            GlobalSetting.Instance.ChannelWay;

        private int _offset;

        public AdMessage()
        {
            Channels = new ChannelMessage[GlobalSetting.Instance.ChannelWay];
            Channels.Init(GlobalSetting.Instance.ChannelWay);
        }

        public byte DeviceId
        {
            get;
            set;
        }

        public byte FunctionCode
        {
            get;
            set;
        }

        public ChannelMessage[] Channels
        {
            get;
            set;
        }

        public void Parse(byte[] message)
        {
            if (message != null && message.Length >= AD_DATA_MESSAGE_LENGTH)
            {
                DeviceId = message.Take(1).Single();
                _offset += 1;
                FunctionCode = message.Skip(_offset).Take(1).Single();
                _offset += 1;
                Channels = new ChannelMessage[GlobalSetting.Instance.ChannelWay];
                Channels.Init(GlobalSetting.Instance.ChannelWay);
                for (var i = 0; i < Channels.Length; i++)
                {
                    var channelMessage = message.Skip(_offset).Take(ChannelMessage.CHANNEL_MESSAGE_LENGTH).ToArray();
                    Channels[i].Parse(channelMessage);
                    _offset += ChannelMessage.CHANNEL_MESSAGE_LENGTH;
                }
            }
        }

        public class ChannelMessage : IMessageParse
        {
            public const int DATA_STEP = 1; // AD数据步长 
            public const int AD_DATA_PAIR_COUNT = 5101/DATA_STEP; //每个通道包含多少个数据域
            public const int CHANNEL_MESSAGE_LENGTH = 2 + AD_DATA_PAIR_COUNT*2;

            public ChannelMessage()
            {
                ChannelIndex = new byte[2];
                DataRanges = new ADDataPair[AD_DATA_PAIR_COUNT];
                DataRanges.Init(AD_DATA_PAIR_COUNT);
            }

            /// <summary>
            ///     通道号
            /// </summary>
            public byte[] ChannelIndex
            {
                get;
                set;
            }

            public ADDataPair[] DataRanges
            {
                get;
                set;
            }

            public void Parse(byte[] message)
            {
                ChannelIndex = message.Take(2).ToArray();
                var offset = 2;
                for (var i = 0; i < DataRanges.Length; i++)
                {
                    DataRanges[i].Parse(message.Skip(offset).Take(2).ToArray());
                    offset += 2;
                }
            }

            public class ADDataPair : IMessageParse
            {
                public byte H
                {
                    get;
                    set;
                }

                public byte L
                {
                    get;
                    set;
                }

                public void Parse(byte[] message)
                {
                    H = message.Take(1).Single();
                    L = message.Skip(1).Take(1).Single();
                }
            }
        }
    }
}