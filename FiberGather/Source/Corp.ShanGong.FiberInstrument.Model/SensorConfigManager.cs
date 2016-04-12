using System;
using System.Collections.Generic;
using System.Linq;
using Corp.ShanGong.FiberInstrument.Common;
using LinqToExcel;
using LinqToExcel.Query;

namespace Corp.ShanGong.FiberInstrument.Model
{
    public class SensorConfigManager
    {
        private static List<SensorConfig> _sensorConfigList;

        public static List<SensorConfig> SensorConfigs
        {
            get
            {

                try
                {
                    if (_sensorConfigList == null)
                    {
                        var excelConfig = new ExcelQueryFactory("SensorConfig.xlsx")
                        {
                            ReadOnly = true,
                            StrictMapping = StrictMappingType.WorksheetStrict
                        };
                        excelConfig.AddTransformation<SensorConfig>(it => it.SensorType,
                            cellValue => SensonTypeConverter(cellValue));
                        excelConfig.AddTransformation<SensorConfig>(it => it.InitWaveLength,
                            cellValue => cellValue.ToDecimalNullable());
                        excelConfig.AddTransformation<SensorConfig>(it => it.InitTemperature,
                            cellValue => cellValue.ToDecimalNullable());
                        excelConfig.AddTransformation<SensorConfig>(it => it.FirstWave,
                            cellValue => cellValue.ToDecimalNullable());
                        excelConfig.AddTransformation<SensorConfig>(it => it.SensitivityValue,
                            cellValue => cellValue.ToDecimalNullable());
                        excelConfig.AddTransformation<SensorConfig>(it => it.TemperatureValue,
                            cellValue => cellValue.ToDecimalNullable());
                        excelConfig.AddTransformation<SensorConfig>(it => it.GfrpCTE,
                            cellValue => cellValue.ToDecimalNullable());
                        excelConfig.AddTransformation<SensorConfig>(it => it.StructuralCTE,
                            cellValue => cellValue.ToDecimalNullable());
                        _sensorConfigList = (from config in excelConfig.WorksheetRange<SensorConfig>("A2", "M5000")
                                             where config.SensorId > 0
                                             select config).ToList();
                    }
                    return _sensorConfigList;
                }
                catch (Exception ex)
                {
                    throw new BoundaryException("读取excel配置文件发生错误！请检查是否安装了Office 2010版本以上的Excel软件,或检查是否正确配置了SensorConfig.xlsx文件！", ex);
                }
            }
        }

        public static SensorConfig GetConfigBy(int channelIndex, int sensorIndex)
        {
            var config = (from c in SensorConfigs
                where c.ChannelIndex == channelIndex && sensorIndex == c.SensorIndex
                select c).SingleOrDefault();
            return config;
        }

        public static SensorConfig GetTemperatureExtensionConfig(SensorConfig config)
        {
            if (config != null && !string.IsNullOrEmpty(config.TemperatureExtensionString))
            {
                var idString = config.TemperatureExtensionString.FirstSplitVal();
                if (!string.IsNullOrEmpty(idString))
                {
                    var id = Convert.ToInt32(idString);
                    var con = (from c in SensorConfigs
                        where c.SensorId == id
                        select c).SingleOrDefault();
                    return con;
                }
            }
            return null;
        }

        /// <summary>
        /// 获取所有温补通道的配置
        /// </summary>
        /// <returns></returns>
        public static List<SensorConfig> GetAllIncludedTempExSensor()
        {
            var tempExs = (from c in SensorConfigs
                          where c.TemperatureExtensionString.FirstSplitVal().IsNumber()
                          select Convert.ToInt32(c.TemperatureExtensionString.FirstSplitVal())).ToList();
            var result = (from c in SensorConfigs
                where tempExs.Contains(c.SensorId)
                select c).ToList();
            return result;
        }

        private static int? SensonTypeConverter(string cellValue)
        {
            if (!string.IsNullOrWhiteSpace(cellValue))
            {
                var typeString = cellValue.TrimStart();

                if (typeString.StartsWith("应变"))
                {
                    return 1;
                }
                if (typeString.StartsWith("温度"))
                {
                    return 2;
                }
                return null;
            }
            return null;
        }
    }
}