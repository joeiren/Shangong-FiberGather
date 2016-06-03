using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.Common;
using Dapper.Contrib.Extensions;

namespace Corp.ShanGong.FiberInstrument.Model.LocalSelf
{
    /// <summary>
    /// 系统设置
    /// </summary>
    [Table("SYSTEM_PREFERENCE")]
    public class SystemPreference
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        public int LocalPort
        {
            get;
            set;
        }

        public string HostIp
        {
            get;
            set;
        }

        public int HostPort
        {
            get;
            set;
        }
        /// <summary>
        /// 数据采样间隔（基于原设备的频率，如果该值为50，设备频率为100Hz,则采样间隔为:100 / 50 = 2Hz）
        /// </summary>
        public int CollectInterval
        {
            get;
            set;
        }

        public bool EnableAutoRun
        {
            get;
            set;
        }

        /// <summary>
        /// 启用本地数据保存
        /// </summary>
        public bool EnableLocalData
        {
            get;
            set;
        }

        public string LocalRootPath
        {
            get;
            set;
        }

        public int LocalDataInterval
        {
            get;
            set;
        }

        /// <summary>
        /// 启用网络转发数据
        /// </summary>
        public bool EnableNetData
        {
            get;
            set;
        }

        /// <summary>
        /// 网络数据转发本地端口
        /// </summary>
        public int NetDataLocalPort
        {
            get;
            set;
        }

        public string NetDataRemoteIp
        {
            get;
            set;
        }

        public int NetDataRemotePort
        {
            get;
            set;
        }

        public int NetDataInterval
        {
            get;
            set;
        }

        /// <summary>
        /// 启用数据库数据保存
        /// </summary>
        public bool EnableDbData
        {
            get;
            set;
        }

        public int DbDataInterval
        {
            get;
            set;
        }

        public string DbConfigString
        {
            get;
            set;
        }

        public static SystemPreference Parse(DataSet set)
        {
            SystemPreference pre = new SystemPreference();
            if (set != null && set.Tables.Count > 0)
            {
                var row = set.Tables[0].Rows[0];
                if (row != null)
                {
                    pre.Id = row.GetValue<int>("ID", 0);
                    pre.HostIp = row.GetValueRef<string>("HOST_IP", "");
                    pre.HostPort = row.GetValue<int>("HOST_PORT", 0);
                    pre.EnableAutoRun = row.GetValue("ENABLE_AUTORUN", false);
                    pre.EnableLocalData = row.GetValue("ENABLE_LOCAL_DATA", false);
                    pre.LocalRootPath = row.GetValueRef("LOCAL_ROOT_PATH", "");
                    pre.LocalDataInterval = row.GetValue("LOCAL_DATA_INTERVAL", 100);
                    pre.EnableNetData = row.GetValue("ENABLE_NET_DATA", false);
                    pre.NetDataLocalPort = row.GetValue("NET_DATA_LOCAL_PORT", 100);
                    pre.NetDataRemoteIp = row.GetValueRef("NET_DATA_REMOTE_IP", "");
                    pre.NetDataRemotePort = row.GetValue("NET_DATA_REMOTE_PORT", 100);
                    pre.NetDataInterval = row.GetValue("NET_DATA_INTERVAL", 100);
                    pre.EnableDbData = row.GetValue("ENABLE_DB_DATA", false);
                    pre.DbDataInterval = row.GetValue("DB_DATA_INTERVAL", 100);
                }
            }
            return pre;
        }
    }
}
