using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Contrib.Extensions;

namespace Corp.ShanGong.FiberInstrument.Model.LocalSelf
{
    [Table("CHANNEL_SENSOR_CONFIG")]
    public class ChannelSensorConfig
    {
        [Key]
        public int ConfigId
        {
            get;
            set;
        }

        public int ChannelNo
        {
            get;
            set;
        }

        public string SensorId
        {
            get;
            set;
        }

        public int SensorIndex
        {
            get;
            set;
        }

        /// <summary>
        /// 温补通道传感器
        /// </summary>
        public string TempExSensor
        {
            get;
            set;
        }

        /// <summary>
        /// 波长相邻间隔
        /// </summary>
        public decimal WaveGap
        {
            get;
            set;
        }

        /// <summary>
        /// 波长活动区间
        /// </summary>
        public decimal WaveWidth
        {
            get;
            set;
        }

        public decimal WaveLimitLower
        {
            get;
            set;
        }

        public decimal WaveLimitUpper
        {
            get;
            set;
        }

        /// <summary>
        /// 波长相邻间隔2
        /// </summary>
        public decimal WaveGap2
        {
            get;
            set;
        }

        /// <summary>
        /// 波长活动区间2
        /// </summary>
        public decimal WaveWidth2
        {
            get;
            set;
        }

        /// <summary>
        /// 波长下限2
        /// </summary>
        public decimal WaveLimitLower2
        {
            get;
            set;
        }
        /// <summary>
        /// 波长上限2
        /// </summary>
        public decimal WaveLimitUpper2
        {
            get;
            set;
        }

        [Computed]
        public SensorBasicProp SensorInfo
        {
            get;
            set;
        }

    }
}
