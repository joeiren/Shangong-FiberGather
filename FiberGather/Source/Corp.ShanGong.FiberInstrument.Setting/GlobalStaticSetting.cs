using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.ShanGong.FiberInstrument.Setting
{
    public class GlobalStaticSetting
    {
        public const int CHANNEL_DEFAULT_8 = 8;
        public const int SENSOR_DEFAULT_AMOUNT = 16;
        private static GlobalStaticSetting _setting;

        private GlobalStaticSetting()
        {
        }

        public static GlobalStaticSetting Instance
        {
            get
            {
                if (_setting == null)
                {
                    _setting = new GlobalStaticSetting();
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
        ///     单通道最大传感器个数
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
        /// 设备原始频率
        /// </summary>
        public int DeviceFrequency
        {
            get
            {
                var device = ConfigurationManager.AppSettings["deviceFrequency"];
                if (string.IsNullOrWhiteSpace(device))
                {
                    throw new Exception("解调仪设备原始频率未配置");
                }
                else
                {
                    return Convert.ToInt32(device);
                }
            }
        }

        /// <summary>
        ///     测试数据保存（提供给数据中心）
        /// </summary>
        public bool EnableSaveTestData
        {
            get
            {
                var enable = ConfigurationManager.AppSettings["enableSaveTestData"];
                return string.IsNullOrEmpty(enable) ? false : (enable == "1");
            }

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
