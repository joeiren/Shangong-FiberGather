using System.Collections.Generic;
using System.Data;
using Corp.ShanGong.FiberInstrument.Common;
using Dapper.Contrib.Extensions;

namespace Corp.ShanGong.FiberInstrument.Model.LocalSelf
{
    [Table("SENSOR_BASIC_PROP")]
    public class SensorBasicProp
    {
        [Key]
        public string SensorId
        {
            get;
            set;
        }

        /// <summary>
        ///     数据库服务器中的id
        /// </summary>
        public int? SensorIdInServer
        {
            get;
            set;
        }

        /// <summary>
        ///     1:温度； 2：应变；3：位移
        /// </summary>
        public int SensorType
        {
            get;
            set;
        }

        /// <summary>
        ///     设备编号
        /// </summary>
        public string DeviceCode
        {
            get;
            set;
        }

        public decimal? OrignalWaveLen1
        {
            get;
            set;
        }

        public decimal? OrignalWaveLen2
        {
            get;
            set;
        }

        /// <summary>
        ///     出厂温度
        /// </summary>
        public decimal? OrignalTemp
        {
            get;
            set;
        }

        /// <summary>
        ///     灵敏度系数
        /// </summary>
        public decimal? SensitivityValue
        {
            get;
            set;
        }

        /// <summary>
        ///     温度灵敏度系数
        /// </summary>
        public decimal? TemperatureValue
        {
            get;
            set;
        }

        /// <summary>
        ///     位移灵敏度系数
        /// </summary>
        public decimal? DisplaceValue
        {
            get;
            set;
        }

        /// <summary>
        /// </summary>
        public decimal GfrpCte
        {
            get;
            set;
        }

        /// <summary>
        ///     结构热膨胀系数
        /// </summary>
        public decimal StructuralCte
        {
            get;
            set;
        }

        public static List<SensorBasicProp> ParseMulti(DataSet set)
        {
            var list = new List<SensorBasicProp>();
            if (set != null && set.Tables.Count > 0)
            {
                foreach (DataRow row in set.Tables[0].Rows)
                {
                    var item = new SensorBasicProp();
                    item.SensorId = row.GetValueRef("SENSOR_ID", "");
                    item.DeviceCode = row.GetValueRef("DEVICE_CODE", "");
                    item.DisplaceValue = row.GetValue("DISPLACE_VALUE", decimal.Zero);
                    item.GfrpCte = row.GetValue("GFRP_CTE", decimal.Zero);
                    item.OrignalTemp = row.GetValue("ORIGNAL_TEMP", decimal.Zero);
                    item.OrignalWaveLen1 = row.GetValue("ORIGNAL_WAVE_LEN1", decimal.Zero);
                    item.OrignalWaveLen2 = row.GetValue("ORIGNAL_WAVE_LEN2", decimal.Zero);
                    item.SensitivityValue = row.GetValue("SENSITIVITY_VALUE", decimal.Zero);
                    item.SensorIdInServer = row.GetValue("SENSOR_ID_IN_SERVER", 0);
                    item.SensorType = row.GetValue("SENSOR_TYPE", 1);
                    item.StructuralCte = row.GetValue("STRUCTURAL_CTE", decimal.Zero);
                    item.TemperatureValue = row.GetValue("TEMPERATURE_VALUE", decimal.Zero);
                    list.Add(item);
                }
            }
            return list;
        }
    }
}