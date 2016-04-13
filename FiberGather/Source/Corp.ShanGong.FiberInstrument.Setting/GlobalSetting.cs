using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.ShanGong.FiberInstrument.Setting
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

        private int _channelWay = 0;
        /// <summary>
        ///     通道模式
        /// </summary>
        public int ChannelWay
        {
            get
            {
                return _channelWay == 0 ? CHANNEL_DEFAULT_8 : _channelWay;
            }
            set
            {
                _channelWay = value;
            }
        }

        private int _sensorCount = 0;
        /// <summary>
        ///     传感器个数
        /// </summary>
        public int SensorCount
        {
            get
            {
                return _sensorCount == 0 ? SENSOR_DEFAULT_AMOUNT : _sensorCount;
            }
            set
            {
                _sensorCount = value;
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


        /// <summary>
        ///     当前数据文件保存的日期
        /// </summary>
        public bool EnableSaveTestData
        {
            get
            {
                var enable = ConfigurationManager.AppSettings["enableSaveTestData"];
                return string.IsNullOrEmpty(enable) ? false : (enable == "1");
            }
            
        }

        public int GatherDataFilter
        {
            get
            {
                var filter = ConfigurationManager.AppSettings["gatherDataFilter"];
                return string.IsNullOrEmpty(filter) ? 10 : Convert.ToInt32(filter);
            }
        }
    }
}
