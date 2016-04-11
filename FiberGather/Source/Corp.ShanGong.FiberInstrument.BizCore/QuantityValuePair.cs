using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.IBizSpec;
using Corp.ShanGong.FiberInstrument.Model;
using Corp.ShanGong.FiberInstrument.Setting;

namespace Corp.ShanGong.FiberInstrument.BizCore
{
    public class QuantityValuePair
    {
        private const int _hzFrom = 191150;
        private const int _hzTo = 196250;
        private const int _baseValue = 8000;

        /// <summary>
        ///     原始频率
        /// </summary>
        public decimal? Orignal
        {
            get;
            set;
        }

        /// <summary>
        ///     转换后的波长
        /// </summary>
        public decimal? WaveLength
        {
            get;
            set;
        }

        /// <summary>
        ///     补偿后的值
        /// </summary>
        public decimal? WaveLengthExtension
        {
            get;
            set;
        }

        /// <summary>
        ///     物理值
        /// </summary>
        public decimal? PhysicalValue
        {
            get;
            set;
        }

        /// <summary>
        ///     光栅报文信息转频率
        /// </summary>
        /// <param name="grating"></param>
        /// <returns></returns>
        public static decimal CalculateFrequency(FrequencyMessage.ChannelMessage.GratingData grating)
        {
            var result = ((Convert.ToInt16(grating.X1) << 16) + (Convert.ToInt16(grating.X2) << 8) +
                          Convert.ToInt16(grating.X3))/10M;
            return result;
        }

        /// <summary>
        ///     频率转换成波长
        /// </summary>
        /// <param name="frequency"></param>
        /// <returns></returns>
        public static decimal? FrequencyToWavelength(decimal? frequency)
        {
            if (frequency == null || frequency.Value == decimal.Zero)
            {
                return null;
            }
            var waveLen = GlobalSetting.Instance.C_Value/(decimal) frequency;
            return Math.Round(waveLen, 3, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        ///     计算管壳温度
        /// </summary>
        /// <param name="shellTemp"></param>
        /// <returns></returns>
        public static decimal CalcShellTemperature(FrequencyMessage.ChannelMessage.AdShellTemp shellTemp)
        {
            //long t = Convert.ToInt16(shellTemp.T1) * 256 + Convert.ToInt16(shellTemp.T2);
            long t = (Convert.ToInt16(shellTemp.T1) << 8) + Convert.ToInt16(shellTemp.T2);
            var result = (decimal) (-0.000000011342*Math.Pow(t, 3)) + (decimal) (0.000056304871*Math.Pow(t, 2)) -
                         0.124444503134M*t + 123.066087843208M;
            return Math.Round(result, 1, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        ///     补偿后的波长计算       公式：补偿后的波长=原始波长+a*(T-25)2+b*(T-25)+c
        /// </summary>
        /// <returns></returns>
        public static decimal? CalcFrequencyExtension(decimal? origanlWave, decimal averageTemp)
        {
            if (origanlWave == null)
            {
                return null;
            }
            var result =
                (decimal)
                    (origanlWave + (decimal) ((-0.00000385)*Math.Pow((double) (averageTemp - 25.0M), 2)) +
                     (-0.00017548M)*(averageTemp - 25.0M) + 0.00742321M);
            return Math.Round(result, 3, MidpointRounding.AwayFromZero);
        }

        /// <summary>
        ///     转换光谱AD值
        /// </summary>
        /// <param name="adPairs"></param>
        /// <returns></returns>
        public static Dictionary<decimal, long?> CalcAdOrignal(AdMessage.ChannelMessage.ADDataPair[] adPairs)
        {
            if (adPairs == null || adPairs.Length == 0)
            {
                return null;
            }
            var curDic = new ConcurrentDictionary<decimal, long?>();

            Parallel.For(0, _hzTo - _hzFrom + 1, i =>
            {
                var val = (Convert.ToInt16(adPairs[i].H) << 8) + Convert.ToInt16(adPairs[i].L) - _baseValue;
                if (val >= 0)
                {
                    var key = FrequencyToWavelength(_hzFrom + i);
                    if (key.HasValue)
                    {
                        curDic.TryAdd(key.Value, val);
                    }
                }
            });

            return curDic.OrderBy(it => it.Key).ToDictionary(c => c.Key, c => c.Value);
        }

        /// <summary>
        ///     计算物理量
        /// </summary>
        /// <param name="orignalConfig"></param>
        /// <param name="wave"></param>
        /// <param name="calculator"></param>
        /// <param name="extensionConfig"></param>
        /// <param name="exWave"></param>
        /// <returns></returns>
        public static decimal CalcPhysicalValue(SensorConfig orignalConfig, decimal? wave,
            IPhysicalCalculator calculator, SensorConfig extensionConfig = null, decimal? exWave = null)
        {
            var midPoint = 2; // 小数点几位 
            var result = decimal.Zero;
            if (orignalConfig != null && orignalConfig.SensorType.HasValue)
            {
                switch (orignalConfig.SensorType.Value)
                {
                    case 1:
                        midPoint = 2;
                        var tempEx = calculator.CalculateTemperature(extensionConfig, exWave);
                        var val = calculator.CalculateStructuralStrain(orignalConfig, wave, tempEx);
                        result = val ?? decimal.Zero;
                        break;
                    case 2:
                        midPoint = 1;
                        var temp = calculator.CalculateTemperature(orignalConfig, wave);
                        result = temp ?? decimal.Zero;
                        break;
                }
            }
            return Math.Round(result, midPoint, MidpointRounding.AwayFromZero);
        }
    }
}