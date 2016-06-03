using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                        excelConfig.AddTransformation<SensorConfig>(it => it.FirstWave2,
                            cellValue => cellValue.ToDecimalNullable());
                        excelConfig.AddTransformation<SensorConfig>(it => it.SensitivityValue,
                            cellValue => cellValue.ToDecimalNullable());
                        excelConfig.AddTransformation<SensorConfig>(it => it.TemperatureValue,
                            cellValue => cellValue.ToDecimalNullable());
                        excelConfig.AddTransformation<SensorConfig>(it => it.DisplaceValue,
                            cellValue => cellValue.ToDecimalNullable());
                        excelConfig.AddTransformation<SensorConfig>(it => it.WaveLowerLimit,
                            cellValue =>
                            {
                                var ret = cellValue.ToDecimalNullable();
                                if (ret == null || ret.Value == decimal.Zero)
                                {
                                    return -2.5m;
                                }
                                return ret;
                            });
                        excelConfig.AddTransformation<SensorConfig>(it => it.WaveUpperLimit,
                            cellValue =>
                            {
                                var ret = cellValue.ToDecimalNullable();
                                if (ret == null || ret.Value == decimal.Zero)
                                {
                                    return 2.5m;
                                }
                                return ret;
                            });
                        excelConfig.AddTransformation<SensorConfig>(it => it.GfrpCTE,
                            cellValue => cellValue.ToDecimalNullable());
                        excelConfig.AddTransformation<SensorConfig>(it => it.StructuralCTE,
                            cellValue => cellValue.ToDecimalNullable());
                        _sensorConfigList = (from config in excelConfig.WorksheetRange<SensorConfig>("A2", "Q5000")
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

        public static void ResetSensorConfig()
        {
            _sensorConfigList = null;
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
                if (typeString.StartsWith("位移"))
                {
                    return 3;
                }
                return null;
            }
            return null;
        }

        private static Dictionary<int, List<SensorConfig>> _channelSensorsDic;

        public static Dictionary<int, List<SensorConfig>> ChannelSensorDic
        {
            get
            {
                return _channelSensorsDic;
            }
            set
            {
                _channelSensorsDic = value;
            }
        }

        /// <summary>
        /// 检查配置文件的波长区域
        /// </summary>
        /// <returns></returns>
        public static string ValidateChannelSensor()
        {
            ChannelSensorDic = new Dictionary<int, List<SensorConfig>>();
            foreach (var sensor in SensorConfigs)
            {
                List<SensorConfig> list;
                if (ChannelSensorDic.ContainsKey(sensor.ChannelIndex))
                {
                    list = ChannelSensorDic[sensor.ChannelIndex];
                }
                else
                {
                    list = new List<SensorConfig>();
                }
                list.Add(sensor);
            }
            StringBuilder builder = new StringBuilder();
            foreach (var itemList in ChannelSensorDic)
            {
                var valList = itemList.Value;
                for (int i = 0; i < valList.Count; i++)
                {
                    var item = valList[i];
                    if (item.FirstWave.HasValue)
                    {
                        var begin = item.FirstWave + item.WaveLowerLimit;
                        var end = item.FirstWave + item.WaveUpperLimit;
                        for (int j = 0; j < valList.Count; j++)
                        {
                            if (i != j)
                            {
                                var otherItem = valList[j];
                                if (otherItem.FirstWave != null)
                                {
                                    if (begin >= otherItem.FirstWave + otherItem.WaveUpperLimit
                                        || end <= otherItem.FirstWave + otherItem.WaveLowerLimit)
                                    {
                                        
                                    }
                                    else
                                    {
                                        // 配置有重叠
                                        builder.AppendFormat("通道{0}, 传感器{1},与传感器{2}的波长区域配置有重叠",item.ChannelIndex,item.SensorId,otherItem.SensorId);
                                        builder.AppendLine();
                                    }
                                }
                            }
                        }
                    }

                    if (item.FirstWave2.HasValue)
                    {
                        var begin = item.FirstWave2 + item.WaveLowerLimit;
                        var end = item.FirstWave2 + item.WaveUpperLimit;
                        for (int j = 0; j < valList.Count; j++)
                        {
                            if (i != j)
                            {
                                var otherItem = valList[j];
                                if (otherItem.FirstWave2 != null)
                                {
                                    if (begin >= otherItem.FirstWave2 + otherItem.WaveUpperLimit
                                        || end <= otherItem.FirstWave2 + otherItem.WaveLowerLimit)
                                    {

                                    }
                                    else
                                    {
                                        // 配置有重叠
                                        builder.AppendFormat("通道{0}, 传感器{1},与传感器{2}的波长区域配置有重叠", item.ChannelIndex, item.SensorId, otherItem.SensorId);
                                    }
                                }
                            }
                        }
                    }

                }
                
            }
            return builder.ToString();
        }

        /// <summary>
        /// 从波长数据定位归属传感器
        /// </summary>
        /// <param name="channelIndex"></param>
        /// <param name="wave"></param>
        /// <returns></returns>
        public static Tuple<SensorConfig,int> LookupSensor(int channelIndex, decimal? wave)
        {
            if (wave.HasValue && wave.Value != decimal.Zero)
            {
                if (ChannelSensorDic.ContainsKey(channelIndex))
                {
                    var sensorList = ChannelSensorDic[channelIndex];
                    foreach (var sensor in sensorList)
                    {
                        if (sensor.FirstWave.HasValue)
                        {
                            var begin = sensor.FirstWave + sensor.WaveLowerLimit;
                            var end = sensor.FirstWave + sensor.WaveUpperLimit;
                            if (begin < wave && wave < end)
                            {
                                return new Tuple<SensorConfig, int>(sensor,1);
                            }
                        }
                        if (sensor.FirstWave2.HasValue)
                        {
                            var begin = sensor.FirstWave2 + sensor.WaveLowerLimit;
                            var end = sensor.FirstWave2 + sensor.WaveUpperLimit;
                            if (begin < wave && wave < end)
                            {
                                return new Tuple<SensorConfig, int>(sensor, 2);
                            }
                        }
                    }
                }
            }
            return null;
        }


        
    }
}