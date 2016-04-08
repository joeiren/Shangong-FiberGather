using LinqToExcel.Attributes;

namespace Corp.ShanGong.FiberInstrument.Model
{
    public class SensorConfig
    {
        /// <summary>
        ///     传感器序号
        /// </summary>
        [ExcelColumn("SensorId")]
        public int SensorId
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
        ///     传感器类型 1:应变 2：温度
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
    }
}