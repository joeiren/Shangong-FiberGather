using System;
using System.Collections.Generic;
using Corp.ShanGong.FiberInstrument.IBizSpec;
using Corp.ShanGong.FiberInstrument.Model;

namespace Corp.ShanGong.FiberInstrument.ProjectSpec
{
    public class PhysicalCalculatorSpecCSJM : IPhysicalCalculator
    {
        public decimal? CalculateTemperature(SensorConfig config, decimal? waveLength)
        {
            if (waveLength == null || config == null || !config.FirstWave.HasValue ||
                (!config.TemperatureValue.HasValue || config.TemperatureValue.Value == decimal.Zero))
            {
                return null;
            }

            var waveChanged = (waveLength.Value - config.FirstWave.Value)*1000;

            var tempChanged = waveChanged/config.TemperatureValue;
            return tempChanged;
        }

        public decimal? CalculateStructuralStrain(SensorConfig config, decimal? waveLength, decimal? tempChanged)
        {
            if (waveLength == null || config == null || !config.FirstWave.HasValue ||
                (!config.TemperatureValue.HasValue || config.TemperatureValue.Value == decimal.Zero))
            {
                return null;
            }
            var waveChanged = (waveLength.Value - config.FirstWave.Value) * 1000;

            var gfrpCte = config.GfrpCTE ?? 8;
            var structCte = config.StructuralCTE ?? 12;
            var strainChanged = (waveChanged - config.TemperatureValue*tempChanged)/config.SensitivityValue +
                                (gfrpCte - structCte)*(tempChanged ?? decimal.Zero);
            return strainChanged;
        }

        public decimal? CalculateStructuralStress(SensorConfig config, decimal? waveLength, decimal? strainChanged)
        {
            var e = (long) (2.06*Math.Pow(10, 6));
            var stressChanged = e*strainChanged*(decimal) Math.Pow(10, -6);
            return stressChanged;
        }

        public List<SensorConfig> Configs
        {
            get;
            set;
        }
    }
}