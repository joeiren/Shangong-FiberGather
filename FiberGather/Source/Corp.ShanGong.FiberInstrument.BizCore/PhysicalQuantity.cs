using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.IBizSpec;
using Corp.ShanGong.FiberInstrument.Model;
using Corp.ShanGong.FiberInstrument.Model.LocalSelf;
using Corp.ShanGong.FiberInstrument.Setting;

namespace Corp.ShanGong.FiberInstrument.BizCore
{
    /// <summary>
    ///     从报文（Message）转换到实际波长和物理量数据
    /// </summary>
    public class PhysicalQuantity
    {
        private PhysicalQuantity()
        {
            ChannelValues = new ChannelQuantity[GlobalStaticSetting.Instance.ChannelWay];
            ChannelValues.Init(GlobalStaticSetting.Instance.ChannelWay);
        }

        public DateTime CurrentTime
        {
            get;
            set;
        }

        public ChannelQuantity[] ChannelValues
        {
            get;
            private set;
        }

        public OrignalQuantity OrignalVal
        {
            get;
            set;
        }

        public static PhysicalQuantity LoadFrom(FrequencyMessage message, IPhysicalCalculator calc, DateTime recTime)
        {
            try
            {
                var instance = new PhysicalQuantity();
                instance.CurrentTime = recTime;

                instance.OrignalVal = new OrignalQuantity();
                instance.OrignalVal.Init(message);

                //预先计算温补通道的物理量
                var tempExValuePairs = TempExValuePairs(instance.OrignalVal, calc);
                // 计算各传感器的物理量
                CalcPhysical(calc, instance, tempExValuePairs);
                return instance;
            }
            catch (Exception )
            {
                throw;
            }
        }

        /// <summary>
        /// 计算各传感器的物理量
        /// </summary>
        /// <param name="calc"></param>
        /// <param name="instance"></param>
        /// <param name="tempExValuePairs"></param>
        private static void CalcPhysical(IPhysicalCalculator calc, PhysicalQuantity instance, Dictionary<string, QuantityValuePair> tempExValuePairs)
        {
            for (var i = 0; i < GlobalStaticSetting.Instance.ChannelWay; i++)
            {
                var orignalVal = instance.OrignalVal;
                var orignalSensors = orignalVal.SensorFrequencyDic[i];
                
                for (var j = 0; j < GlobalStaticSetting.Instance.SensorCount; j++)
                {
                    //var config = SensorConfigManager.GetConfigBy(i + 1, j + 1);
                    var config = ChannelInfoManager.GetConfigBy(i + 1, j + 1);
                    if (config != null)
                    {
                        if (tempExValuePairs.ContainsKey(config.SensorId))
                        {
                            instance.ChannelValues[i].GratingValues[j] = tempExValuePairs[config.SensorId];
                        }
                        else
                        {
                            //定位当前传感器与那个原始报文消息对应
                            var indexPair = LocateMessageIndex(config, orignalSensors);
                            if (indexPair.Item1 != -1)
                            {
                                var located = indexPair.Item1;
                                instance.ChannelValues[i].GratingValues[j].Orignal = orignalSensors[located].FrequencyVal;
                                instance.ChannelValues[i].GratingValues[j].WaveLength = orignalSensors[located].WaveLength;
                                var wave = instance.ChannelValues[i].GratingValues[j].WaveLengthExtension = orignalSensors[located].WaveLengthExtension;
                                decimal? exWave = null; // 温补通道的波长
                                decimal? wave2 = null;  // 位移传感器的2波长
                                var extension = ChannelInfoManager.GetTemperatureExtensionConfig(config); // 获取温补通道配置
                                if (extension != null && tempExValuePairs.ContainsKey(extension.SensorId))
                                {
                                    exWave = tempExValuePairs[extension.SensorId].WaveLengthExtension;
                                }

                                if (indexPair.Item2 != -1)
                                {
                                    wave2 = orignalSensors[indexPair.Item2].WaveLengthExtension;
                                }
                                var phys = instance.ChannelValues[i].GratingValues[j].PhysicalValue = QuantityValuePair.CalcPhysicalValue(SensorConfig.Parse(config), wave, calc, SensorConfig.Parse(extension), exWave, wave2);
                                instance.ChannelValues[i].GratingValues[j].ExternalId = config.SensorInfo.SensorIdInServer ?? 0L;

                                if (config.SensorInfo.SensorType == 3 )
                                {
                                    j = j + 1;
                                    if (indexPair.Item2 != -1) // 无法找到位移的第二数据
                                    {
                                        var located2 = indexPair.Item2;
                                        instance.ChannelValues[i].GratingValues[j].Orignal = orignalSensors[located2].FrequencyVal;
                                        instance.ChannelValues[i].GratingValues[j].WaveLength = orignalSensors[located2].WaveLength;
                                        wave = instance.ChannelValues[i].GratingValues[j].WaveLengthExtension = orignalSensors[located].WaveLengthExtension;
                                        instance.ChannelValues[i].GratingValues[j].PhysicalValue = phys;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 预先计算温补通道的物理量
        /// </summary>
        /// <param name="orignalVal"></param>
        /// <param name="calc"></param>
        /// <returns></returns>
        private static Dictionary<string, QuantityValuePair> TempExValuePairs(OrignalQuantity orignalVal, IPhysicalCalculator calc)
        {
            var tempExConfigs = ChannelInfoManager.GetAllIncludedTempExSensor();
            Dictionary<string, QuantityValuePair> tempExValuePairs = new Dictionary<string, QuantityValuePair>();
            foreach (var config in tempExConfigs)
            {
                var i = config.ChannelNo - 1;
                // 先确定通道里具体的数据和传感器的对应关系
                var orignalSensors = orignalVal.SensorFrequencyDic[i];
                var j = LocateTempExMessage(config, orignalSensors);
                
                if (j !=-1)
                {
                    QuantityValuePair pair = new QuantityValuePair();
                    pair.Orignal = orignalSensors[j].FrequencyVal;
                    pair.WaveLength = orignalSensors[j].WaveLength;
                    var wave = pair.WaveLengthExtension = orignalSensors[j].WaveLengthExtension;
                    
                    //var extension = SensorConfigManager.GetTemperatureExtensionConfig(current); // 温补通道本身无需再计算温补后的波长
                    pair.PhysicalValue = QuantityValuePair.CalcPhysicalValue(SensorConfig.Parse(config), wave, calc); // 温补通道本身的物理量（温度）
                    pair.ExternalId = config.SensorInfo.SensorIdInServer??0L;
                    tempExValuePairs.Add(config.SensorId, pair);
                }
                
            }
            return tempExValuePairs;
        }

        /// <summary>
        /// 转换成波长数据
        /// </summary>
        /// <returns></returns>
        public string[] ToWaveDataString()
        {
            var result = new string[ChannelValues.Length];
            for (var i = 0; i < ChannelValues.Length; i++)
            {
                var builder = new StringBuilder();
                builder.Append(CurrentTime.ToString("yyyy MM dd HH mm ss "));
                for (var j = 0; j < ChannelValues[i].GratingValues.Length; j++)
                {
                    var wave = ChannelValues[i].GratingValues[j].WaveLengthExtension ?? decimal.Zero;
                    builder.AppendFormat("{0} ", wave.ToString());
                }
                builder.AppendLine();
                result[i] = builder.ToString();
            }
            return result;
        }


        /// <summary>
        /// 转换成 波长 + 物理量的格式数据 
        /// </summary>
        /// <returns></returns>
        public string[] ToPhysicalWaveDataString()
        {
            var result = new string[ChannelValues.Length];
            for (var i = 0; i < ChannelValues.Length; i++)
            {
                var builder = new StringBuilder();
                builder.Append(CurrentTime.ToString("yyyy-MM-dd HH:mm:ss\t"));
                for (var j = 0; j < ChannelValues[i].GratingValues.Length; j++)
                {
                    var wave = ChannelValues[i].GratingValues[j].WaveLengthExtension ?? decimal.Zero;
                    var phy = ChannelValues[i].GratingValues[j].PhysicalValue ?? decimal.Zero;
                    builder.AppendFormat("{0}\t", wave);
                    builder.AppendFormat("{0}\t", phy);
                }
                builder.AppendLine();
                result[i] = builder.ToString();
            }
            return result;
        }

        /// <summary>
        /// 提供给数据中心的检查数据
        /// </summary>
        /// <returns></returns>
        public string[] ToTestDataString()
        {
            var result = new string[ChannelValues.Length];
            for (var i = 0; i < ChannelValues.Length; i++)
            {
                var builder = new StringBuilder();
                builder.Append(CurrentTime.ToString("yyyy-MM-dd HH:mm:ss\t"));
                for (var j = 0; j < ChannelValues[i].GratingValues.Length; j++)
                {
                    var wave = ChannelValues[i].GratingValues[j].WaveLengthExtension ?? decimal.Zero;
                    //var phy = ChannelValues[i].GratingValues[j].PhysicalValue ?? decimal.Zero;
                    builder.AppendFormat("{0}\t", wave);
                    //builder.AppendFormat("{0} ", phy);
                }
                builder.AppendLine();
                result[i] = builder.ToString();
            }
            return result;
        }


        /// <summary>
        /// 从配置信息（波长的上下限范围）来确定当前配置应匹配那个波长值
        /// </summary>
        /// <param name="config">当前配置</param>
        /// <param name="sensors">一个通道内的采集到的波长（通常应该按从小到大的顺序）</param>
        /// <returns>当前配置对于的顺序号（位移等特殊传感器，对于一个传感器有2个波长值）</returns>
        public static Tuple<int, int> LocateMessageIndex(ChannelSensorConfig config, OrignalQuantity.SensorFrequency[] sensors)
        {
            int first = -1, second = -1;
            if (config != null && sensors != null && sensors.Any())
            {
                if (config.SensorInfo.OrignalWaveLen1.HasValue)
                {
                    var begin = config.WaveLimitLower;
                    var end = config.WaveLimitUpper;
                    for (var i = 0; i < sensors.Length; i++)
                    {
                        var wave = sensors[i].WaveLengthExtension;
                        if (wave.HasValue && wave.Value > begin && wave.Value < end)
                        {
                            first = i;
                            break;
                        }
                    }
                }
                if (config.SensorInfo.OrignalWaveLen2.HasValue && config.SensorInfo.SensorType== 3)
                {
                    var begin = config.WaveLimitLower2;
                    var end = config.WaveLimitUpper2;
                    for (var i = 0; i < sensors.Length; i++)
                    {
                        var wave = sensors[i].WaveLengthExtension;
                        if (wave.HasValue && wave.Value > begin && wave.Value < end)
                        {
                            second = i;
                            break;
                        }
                    }
                }
            }
            return new Tuple<int, int>(first,second);
        }

        /// <summary>
        /// 定位温补通道具体对应的频率的位置
        /// </summary>
        /// <param name="config"></param>
        /// <param name="freqs"></param>
        /// <returns></returns>
        public static int LocateTempExMessage(ChannelSensorConfig config, OrignalQuantity.SensorFrequency[] freqs)
        {
            if (config != null && freqs != null && freqs.Any())
            {
                if (config.SensorInfo.OrignalWaveLen1 != decimal.Zero) // 因为温补通道的为温补传感器，只关心第一个波长
                {
                    var begin = config.WaveLimitLower;
                    var end = config.WaveLimitUpper;
                    for (var i = 0; i < freqs.Length; i++)
                    {
                        var wave = freqs[i].WaveLength;
                        if (wave.HasValue && wave.Value > begin && wave.Value < end)
                        {
                            return i;
                        }
                    }
                }
            }
            return -1;
        }

        /// <summary>
        ///     通道数据
        /// </summary>
        public class ChannelQuantity
        {
            public ChannelQuantity()
            {
                GratingValues = new QuantityValuePair[GlobalStaticSetting.Instance.SensorCount];
                GratingValues.Init(GlobalStaticSetting.Instance.SensorCount);
            }

            /// <summary>
            ///     传感器物理数据
            /// </summary>
            public QuantityValuePair[] GratingValues
            {
                get;
                set;
            }

            public decimal ShellTemperator
            {
                get;
                set;
            }
        }
    }
}