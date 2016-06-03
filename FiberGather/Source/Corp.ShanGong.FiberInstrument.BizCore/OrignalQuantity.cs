using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.Model;

namespace Corp.ShanGong.FiberInstrument.BizCore
{
    /// <summary>
    /// 采集后的频率波长数据，按解调仪返回顺序的数据
    /// </summary>
    public class OrignalQuantity
    {

        public void Init(FrequencyMessage message)
        {
            SensorFrequencyDic = new Dictionary<int, SensorFrequency[]>();
            if (message != null && message.Channels.Length > 0)
            {
                SensorFrequencyDic = new Dictionary<int, SensorFrequency[]>();
                ShellTempDic = new Dictionary<int, decimal>(); // 各通道的管壳温度,一个通道一个管壳温度
                var tempCache = new ShellTemperatureCache();
                for (var i = 0; i < message.Channels.Length; i++)
                {
                    var shellTemp = QuantityValuePair.CalcShellTemperature(message.Channels[i].ShellTemperature);
                    tempCache.Push(i, shellTemp);
                    ShellTempDic.Add(i, tempCache.AverageTemperature(i));
                }

                for (var i = 0; i < message.Channels.Length; i++)
                {
                    var channel = message.Channels[i];
                    SensorFrequency[] sensors = new SensorFrequency[channel.Gratings.Length];
                    sensors.Init(channel.Gratings.Length);
                    for (var j = 0; j < channel.Gratings.Length; j++)
                    {
                        sensors[j].Index = j;
                        sensors[j].FrequencyVal = QuantityValuePair.CalculateFrequency(channel.Gratings[j]);
                        sensors[j].WaveLength = QuantityValuePair.FrequencyToWavelength(sensors[j].FrequencyVal);
                        sensors[j].WaveLengthExtension = QuantityValuePair.CalcFrequencyExtension(sensors[j].WaveLength, ShellTempDic[i]);
                    }
                    SensorFrequencyDic.Add(i,sensors);
                }
            }
        }

        public Dictionary<int,SensorFrequency[]> SensorFrequencyDic
        {
            get;
            set;
        }

        /// <summary>
        /// 各通道的管壳温度,一个通道一个管壳温度
        /// </summary>
        public Dictionary<int, decimal> ShellTempDic
        {
            get;
            set;
        }

        public class SensorFrequency
        {
            /// <summary>
            /// 频率数据在数据返回报文中位置，不会具体对应到传感器位置
            /// </summary>
            public int Index
            {
                get;
                set;
            }

            public decimal? FrequencyVal
            {
                get;
                set;
            }

            public decimal? WaveLength
            {
                get;
                set;
            }

            /// <summary>
            /// 追加管壳温度后波长
            /// </summary>
            public decimal? WaveLengthExtension
            {
                get;
                set;
            }
        }
    }
}
