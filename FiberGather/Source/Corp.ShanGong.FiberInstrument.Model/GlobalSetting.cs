using System;

namespace Corp.ShanGong.FiberInstrument.Model
{
    public class GlobalSetting
    {
        public const int CHANNEL_DEFAULT_8 = 8;
        public const int SENSOR_DEFAULT_AMOUNT = 16;
        private static GlobalSetting _setting;

        private GlobalSetting()
        {
        }

        public static GlobalSetting Instance
        {
            get
            {
                if (_setting == null)
                {
                    _setting = new GlobalSetting();
                }
                return _setting;
            }
        }

        /// <summary>
        ///     通道模式
        /// </summary>
        public int ChannelWay
        {
            get
            {
                // read from config file or db
                return CHANNEL_DEFAULT_8;
            }
        }

        /// <summary>
        ///     传感器个数
        /// </summary>
        public int SensorCount
        {
            get
            {
                // load from config file or local
                return SENSOR_DEFAULT_AMOUNT;
            }
        }

        /// <summary>
        ///     默认通道数和传感器（8 * 16）
        /// </summary>
        public bool IsDefaultWay
        {
            get
            {
                return Instance.ChannelWay == CHANNEL_DEFAULT_8
                       && Instance.SensorCount == SENSOR_DEFAULT_AMOUNT;
            }
        }

        /// <summary>
        ///     光速
        /// </summary>
        public long C_Value
        {
            get
            {
                return 299792458L;
            }
        }

        /// <summary>
        ///     数据文件保存路径
        /// </summary>
        public string DataFileLocalPath
        {
            get;
            set;
        }

        /// <summary>
        ///     当前数据文件保存的日期
        /// </summary>
        public DateTime CurrentSaveDate
        {
            get;
            set;
        }
    }
}