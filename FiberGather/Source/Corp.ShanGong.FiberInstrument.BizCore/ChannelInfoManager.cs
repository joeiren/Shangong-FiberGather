using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.DataPersistence;
using Corp.ShanGong.FiberInstrument.Model.LocalSelf;

namespace Corp.ShanGong.FiberInstrument.BizCore
{
    public class ChannelInfoManager
    {
        private static List<ChannelSensorConfig> _channelInfos;

        public static List<ChannelSensorConfig> ChannelInfos
        {
            get
            {
                if (_channelInfos == null || !_channelInfos.Any())
                {
                    ChannelSensorConfigAccess access = new ChannelSensorConfigAccess();
                    _channelInfos = access.LoadAll(true);
                }
                return _channelInfos;
            }
        }

        /// <summary>
        /// 按通道号和传感器序号
        /// </summary>
        /// <param name="channelNo"></param>
        /// <param name="sensorIndex"></param>
        /// <returns></returns>
        public static ChannelSensorConfig GetConfigBy(int channelNo, int sensorIndex)
        {
            if (ChannelInfos != null)
            {
                return ChannelInfos.SingleOrDefault(it => it.ChannelNo == channelNo && it.SensorIndex == sensorIndex);
            }
            return null;
        }

        /// <summary>
        /// 获取当前通道的（如果有）温补通道配置信息
        /// </summary>
        /// <param name="info">当前通道</param>
        /// <returns></returns>
        public static ChannelSensorConfig GetTemperatureExtensionConfig(ChannelSensorConfig info)
        {
            if (info != null && !string.IsNullOrEmpty(info.TempExSensor))
            {
                return ChannelInfos.SingleOrDefault(it => it.SensorId == info.TempExSensor);
            }
            return null;
        }

        /// <summary>
        /// 获取所有温补通道的配置
        /// </summary>
        /// <returns></returns>
        public static List<ChannelSensorConfig> GetAllIncludedTempExSensor()
        {
            var exSensorIds = ChannelInfos.Where(it => !string.IsNullOrEmpty(it.TempExSensor)).Select(it=>it.TempExSensor).Distinct().ToList();
            return ChannelInfos.Where(it => exSensorIds.Contains(it.SensorId)).ToList();
        }
    }
}
