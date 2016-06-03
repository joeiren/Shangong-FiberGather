using Corp.ShanGong.FiberInstrument.Model.LocalSelf;
using LinqToExcel.Attributes;

namespace Corp.ShanGong.FiberInstrument.Model
{
    public class SensorConfig
    {
        /// <summary>
        ///     传感器序号
        /// </summary>
        [ExcelColumn("SensorId")]
        public string SensorId
        {
            get;
            set;
        }

        /// <summary>
        ///     通道号
        /// </summary>
        [ExcelColumn("ChannelIndex")]
        public int ChannelIndex
        {
            get;
            set;
        }

        /// <summary>
        ///     传感器序号（通道内）
        /// </summary>
        [ExcelColumn("SensorIndex")]
        public int SensorIndex
        {
            get;
            set;
        }

        /// <summary>
        ///     传感器编号
        /// </summary>
        [ExcelColumn("SensorCode")]
        public string SensorCode
        {
            get;
            set;
        }

        /// <summary>
        ///     传感器类型 1:应变 2：温度 3：位移
        /// </summary>
        [ExcelColumn("SensorType")]
        public int? SensorType
        {
            get;
            set;
        }

        /// <summary>
        ///     出厂波长
        /// </summary>
        [ExcelColumn("InitWave")]
        public decimal? InitWaveLength
        {
            get;
            set;
        }

        /// <summary>
        ///     出厂温度
        /// </summary>
        [ExcelColumn("InitTemperature")]
        public decimal? InitTemperature
        {
            get;
            set;
        }
        /// <summary>
        /// 初始波长
        /// </summary>
        [ExcelColumn("FirstWave")]
        public decimal? FirstWave
        {
            get;
            set;
        }

        /// <summary>
        /// 初始波长2
        /// </summary>
        [ExcelColumn("FirstWave2")]
        public decimal? FirstWave2
        {
            get;
            set;
        }

        /// <summary>
        ///     灵敏度系数
        /// </summary>
        [ExcelColumn("SensitivityValue")]
        public decimal? SensitivityValue
        {
            get;
            set;
        }

        /// <summary>
        ///     温度系数
        /// </summary>
        [ExcelColumn("TemperatureValue")]
        public decimal? TemperatureValue
        {
            get;
            set;
        }

        /// <summary>
        ///     位移灵敏度系数
        /// </summary>
        [ExcelColumn("DisplaceValue")]
        public decimal? DisplaceValue
        {
            get;
            set;
        }

        /// <summary>
        ///     波长间隔下限
        /// </summary>
        [ExcelColumn("WaveLowerLimit")]
        public decimal? WaveLowerLimit
        {
            get;
            set;
        }

        /// <summary>
        ///     波长间隔上限
        /// </summary>
        [ExcelColumn("WaveUpperLimit")]
        public decimal? WaveUpperLimit
        {
            get;
            set;
        }
        /// <summary>
        ///     波长间隔下限
        /// </summary>
        [ExcelColumn("WaveLowerLimit")]
        public decimal? WaveLowerLimit2
        {
            get;
            set;
        }

        /// <summary>
        ///     波长间隔上限
        /// </summary>
        [ExcelColumn("WaveUpperLimit")]
        public decimal? WaveUpperLimit2
        {
            get;
            set;
        }
        /// <summary>
        ///     温补编号
        /// </summary>
        [ExcelColumn("TemperatureExtensionId")]
        public string TemperatureExtensionString
        {
            get;
            set;
        }

        /// <summary>
        ///     GFRP的热膨胀系数
        /// </summary>
        [ExcelColumn("GfrpCTE")]
        public decimal? GfrpCTE
        {
            get;
            set;
        }

        /// <summary>
        ///     结构热膨胀系数
        /// </summary>
        [ExcelColumn("StructuralCTE")]
        public decimal? StructuralCTE
        {
            get;
            set;
        }


        public static SensorConfig Parse(ChannelSensorConfig channelInfo)
        {
            if (channelInfo == null ||channelInfo.SensorInfo == null)
            {
                return null;
            }

            SensorConfig config = new SensorConfig();
            config.SensorId = channelInfo.SensorId;
            config.SensorCode = channelInfo.SensorInfo.DeviceCode;
            config.ChannelIndex = channelInfo.ChannelNo;
            config.SensorIndex = channelInfo.SensorIndex;
            config.SensorType = channelInfo.SensorInfo.SensorType;
            config.FirstWave = channelInfo.SensorInfo.OrignalWaveLen1;
            config.FirstWave2 = channelInfo.SensorInfo.OrignalWaveLen2;
            config.TemperatureExtensionString = channelInfo.TempExSensor;
            config.SensitivityValue = channelInfo.SensorInfo.SensitivityValue;
            config.TemperatureValue = channelInfo.SensorInfo.TemperatureValue;
            config.DisplaceValue = channelInfo.SensorInfo.DisplaceValue;
            config.InitTemperature = channelInfo.SensorInfo.OrignalTemp;
            config.WaveLowerLimit = channelInfo.WaveLimitLower;
            config.WaveUpperLimit = channelInfo.WaveLimitUpper;
            config.WaveLowerLimit2 = channelInfo.WaveLimitLower2;
            config.WaveUpperLimit2 = channelInfo.WaveLimitUpper2;
            config.GfrpCTE = channelInfo.SensorInfo.GfrpCte;
            config.StructuralCTE = channelInfo.SensorInfo.StructuralCte;
            return config;
        }
    }
}