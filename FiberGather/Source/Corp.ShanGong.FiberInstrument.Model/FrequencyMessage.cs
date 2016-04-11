using System;
using System.Linq;
using System.Net;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.Setting;

namespace Corp.ShanGong.FiberInstrument.Model
{
    /// <summary>
    ///     频率报文数据
    /// </summary>
    public class FrequencyMessage : IMessageParse
    {
        public static readonly int MESSAGE_LENGTH = 2 + GlobalSetting.Instance.ChannelWay*ChannelMessage.MESSAGE_LENGTH;
        private int _offset;

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
            if (message != null && message.Length > 0)
            {
                if (GlobalSetting.Instance.IsDefaultWay)
                {
                    if (message.Length >= 530)
                    {
                        DeviceId = message.Take(1).Single();
                        _offset += 1;
                        FunctionCode = message.Skip(_offset).Take(1).Single();
                        _offset += 1;
                        Channels = new ChannelMessage[GlobalSetting.Instance.ChannelWay];
                        Channels.Init(GlobalSetting.Instance.ChannelWay);
                        for (var i = 0; i < Channels.Length; i++)
                        {
                            var channelMessage = message.Skip(_offset).Take(ChannelMessage.MESSAGE_LENGTH).ToArray();
                            Channels[i].Parse(channelMessage);
                            _offset += ChannelMessage.MESSAGE_LENGTH;
                        }
                    }
                    else
                    {
                        
                    }
                }
            }
        }

        /// <summary>
        ///     光栅数据（传感器）
        /// </summary>
        public class ChannelMessage : IMessageParse
        {
            public static readonly int MESSAGE_LENGTH = GlobalSetting.Instance.SensorCount*4 + 2;

            public ChannelMessage()
            {
                Gratings = new GratingData[GlobalSetting.Instance.SensorCount];
                Gratings.Init(GlobalSetting.Instance.SensorCount);
                ShellTemperature = new AdShellTemp();
            }

            /// <summary>
            ///     光栅传感器数据
            /// </summary>
            public GratingData[] Gratings
            {
                get;
                set;
            }

            /// <summary>
            ///     管壳温度
            /// </summary>
            public AdShellTemp ShellTemperature
            {
                get;
                set;
            }

            public void Parse(byte[] message)
            {
                var offset = 0;
                for (var i = 0; i < Gratings.Length; i++)
                {
                    Gratings[i].Parse(message.Skip(offset).Take(4).ToArray());
                    offset += 4;
                }
                ShellTemperature.Parse(message.Skip(offset).Take(2).ToArray());
                offset += 2;
            }

            /// <summary>
            ///     光栅传感器
            /// </summary>
            public class GratingData : IMessageParse
            {
                public byte GratingIndex
                {
                    get;
                    private set;
                }

                public byte X1
                {
                    get;
                    private set;
                }

                public byte X2
                {
                    get;
                    private set;
                }

                public byte X3
                {
                    get;
                    private set;
                }

                public void Parse(byte[] message)
                {
                    var offset = 0;
                    GratingIndex = message.Take(1).Single();
                    offset += 1;
                    X1 = message.Skip(offset).Take(1).Single();
                    offset += 1;
                    X2 = message.Skip(offset).Take(1).Single();
                    offset += 1;
                    X3 = message.Skip(offset).Take(1).Single();
                    offset += 1;
                }
            }

            public class AdShellTemp : IMessageParse
            {
                public byte T1
                {
                    get;
                    set;
                }

                public byte T2
                {
                    get;
                    set;
                }

                public void Parse(byte[] message)
                {
                    var offset = 0;
                    T1 = message.Take(1).Single();
                    offset += 1;
                    T2 = message.Skip(offset).Take(1).Single();
                    offset += 1;
                }
            }
        }
    }
}