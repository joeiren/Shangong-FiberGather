using System;
using System.Collections.Generic;
using System.Text;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.IBizSpec;
using Corp.ShanGong.FiberInstrument.Model;
using Corp.ShanGong.FiberInstrument.Setting;

namespace Corp.ShanGong.FiberInstrument.BizCore
{
    /// <summary>
    ///     物理量数据
    /// </summary>
    public class PhysicalQuantity
    {
        private PhysicalQuantity()
        {
            ChannelValues = new ChannelQuantity[GlobalSetting.Instance.ChannelWay];
            ChannelValues.Init(GlobalSetting.Instance.ChannelWay);
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

        public static PhysicalQuantity LoadFrom(FrequencyMessage message, IPhysicalCalculator calc, DateTime recTime)
        {
            try
            {
                var instance = new PhysicalQuantity();
                instance.CurrentTime = recTime;
                //计算各通道的管壳温度
                var shellTempDic = ShellTempDic(message, instance.ChannelValues.Length);
                //预先计算温补通道的物理量
                var tempExValuePairs = TempExValuePairs(message, calc, shellTempDic);
                // 计算各传感器的物理量
                CalcPhysical(message, calc, instance, tempExValuePairs, shellTempDic);
                return instance;
            }
            catch (Exception )
            {
                throw;
            }
        }

        private static void CalcPhysical(FrequencyMessage message, IPhysicalCalculator calc, PhysicalQuantity instance,
            Dictionary<int, QuantityValuePair> tempExValuePairs, Dictionary<int, decimal> shellTempDic)
        {
            for (var i = 0; i < instance.ChannelValues.Length; i++)
            {
                for (var j = 0; j < instance.ChannelValues[i].GratingValues.Length; j++)
                {
                    var current = SensorConfigManager.GetConfigBy(i + 1, j + 1);
                   
                    if (current != null && tempExValuePairs.ContainsKey(current.SensorId))
                    {
                        instance.ChannelValues[i].GratingValues[j] = tempExValuePairs[current.SensorId];
                    }
                    else
                    {
                        instance.ChannelValues[i].GratingValues[j].Orignal =
                            QuantityValuePair.CalculateFrequency(message.Channels[i].Gratings[j]);
                        instance.ChannelValues[i].GratingValues[j].WaveLength =
                            QuantityValuePair.FrequencyToWavelength(instance.ChannelValues[i].GratingValues[j].Orignal);
                        var wave =
                            instance.ChannelValues[i].GratingValues[j].WaveLengthExtension =
                                QuantityValuePair.CalcFrequencyExtension(
                                    instance.ChannelValues[i].GratingValues[j].WaveLength, shellTempDic[i]);

                        var extension = SensorConfigManager.GetTemperatureExtensionConfig(current);
                        decimal? exWave = null;
                        if (extension != null && tempExValuePairs.ContainsKey(extension.SensorId))
                        {
                            exWave = tempExValuePairs[extension.SensorId].WaveLengthExtension;
                        }
                        instance.ChannelValues[i].GratingValues[j].PhysicalValue =
                            QuantityValuePair.CalcPhysicalValue(current, wave, calc, extension, exWave);
                    }
                }
            }
        }

        private static Dictionary<int, QuantityValuePair> TempExValuePairs(FrequencyMessage message, IPhysicalCalculator calc, 
            Dictionary<int, decimal> shellTempDic)
        {
            var tempExConfigs = SensorConfigManager.GetAllIncludedTempExSensor();
            Dictionary<int, QuantityValuePair> tempExValuePairs = new Dictionary<int, QuantityValuePair>();
            foreach (var config in tempExConfigs)
            {
                var i = config.ChannelIndex - 1;
                var j = config.SensorIndex - 1;
                QuantityValuePair pair = new QuantityValuePair();
                pair.Orignal = QuantityValuePair.CalculateFrequency(message.Channels[i].Gratings[j]);
                pair.WaveLength = QuantityValuePair.FrequencyToWavelength(pair.Orignal);
                var wave = pair.WaveLengthExtension = QuantityValuePair.CalcFrequencyExtension(
                    pair.WaveLength, shellTempDic[i]);
                var current = SensorConfigManager.GetConfigBy(i + 1, j + 1);
                //var extension = SensorConfigManager.GetTemperatureExtensionConfig(current);
                pair.PhysicalValue = QuantityValuePair.CalcPhysicalValue(current, wave, calc); // 温补通道
                tempExValuePairs.Add(config.SensorId, pair);
            }
            return tempExValuePairs;
        }

        private static Dictionary<int, decimal> ShellTempDic(FrequencyMessage message, int length)
        {
            var tempCache = new ShellTemperatureCache();
            Dictionary<int, decimal> shellTempDic = new Dictionary<int, decimal>(); // 各通道的管壳温度
            for (var i = 0; i < length; i++)
            {
                var shellTemp = QuantityValuePair.CalcShellTemperature(message.Channels[i].ShellTemperature);
                tempCache.Push(i, shellTemp);
                shellTempDic.Add(i, tempCache.AverageTemperature(i));
            }
            return shellTempDic;
        }

        public string[] ToDataString()
        {
            var result = new string[ChannelValues.Length];
            for (var i = 0; i < ChannelValues.Length; i++)
            {
                var builder = new StringBuilder();
                builder.Append(CurrentTime.ToString("yyyy MM dd HH mm ss "));
                for (var j = 0; j < ChannelValues[i].GratingValues.Length; j++)
                {
                    //var wave = ChannelValues[i].GratingValues[j].WaveLengthExtension ?? decimal.Zero;
                    var phy = ChannelValues[i].GratingValues[j].PhysicalValue ?? decimal.Zero;
                    //builder.AppendFormat("{0} ", wave.ToString());
                    builder.AppendFormat("{0} ", phy);
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
                builder.Append(CurrentTime.ToString("yyyy MM dd HH mm ss "));
                for (var j = 0; j < ChannelValues[i].GratingValues.Length; j++)
                {
                    var wave = ChannelValues[i].GratingValues[j].WaveLengthExtension ?? decimal.Zero;
                    var phy = ChannelValues[i].GratingValues[j].PhysicalValue ?? decimal.Zero;
                    builder.AppendFormat("{0} ", wave);
                    builder.AppendFormat("{0} ", phy);
                }
                builder.AppendLine();
                result[i] = builder.ToString();
            }
            return result;
        }

        /// <summary>
        ///     通道数据
        /// </summary>
        public class ChannelQuantity
        {
            public ChannelQuantity()
            {
                GratingValues = new QuantityValuePair[GlobalSetting.Instance.SensorCount];
                GratingValues.Init(GlobalSetting.Instance.SensorCount);
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