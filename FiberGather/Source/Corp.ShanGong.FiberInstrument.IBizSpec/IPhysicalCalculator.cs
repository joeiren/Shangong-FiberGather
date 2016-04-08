using System.Collections.Generic;
using Corp.ShanGong.FiberInstrument.Model;

namespace Corp.ShanGong.FiberInstrument.IBizSpec
{
    public interface IPhysicalCalculator
    {
        List<SensorConfig> Configs
        {
            get;
            set;
        }

        /// <summary>
        ///     结构温度计算
        /// </summary>
        /// <param name="config"></param>
        /// <param name="waveLength"></param>
        /// <returns></returns>
        decimal? CalculateTemperature(SensorConfig config, decimal? waveLength);

        /// <summary>
        ///     结构应变计算
        /// </summary>
        /// <param name="config"></param>
        /// <param name="waveLength"></param>
        /// <param name="tempChanged"></param>
        /// <returns></returns>
        decimal? CalculateStructuralStrain(SensorConfig config, decimal? waveLength, decimal? tempChanged);

        /// <summary>
        ///     结构应力计算
        /// </summary>
        /// <param name="config"></param>
        /// <param name="waveLength"></param>
        /// <param name="strainChanged"></param>
        /// <returns></returns>
        decimal? CalculateStructuralStress(SensorConfig config, decimal? waveLength, decimal? strainChanged);
    }
}