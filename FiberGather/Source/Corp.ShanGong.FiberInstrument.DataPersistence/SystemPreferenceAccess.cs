using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.Model.LocalSelf;
using Dapper.Contrib.Extensions;

namespace Corp.ShanGong.FiberInstrument.DataPersistence
{
    public class SystemPreferenceAccess
    {
        public static SystemPreference LoadSystemPreference()
        {
            using (var conn = SqliteHelper.GetLocalConnection())
            {
                try
                {
                    return conn.Get<SystemPreference>(1);
//                    SQLiteCommand command = new SQLiteCommand(conn);
//                    command.CommandText = "select * from SYSTEM_PREFERENCE where ID=1";
//                    var set = SqliteHelper.ExecuteDataset(command);
//                    return SystemPreference.Parse(set);
                }
                catch (SQLiteException sqlEx)
                {
                    throw;
                }
                catch (Exception )
                {
                    throw;
                }
            }
        }

        public static bool SaveSystemPreference(SystemPreference pre)
        {
            using (var conn = SqliteHelper.GetLocalConnection())
            {
                bool reuslt = false;
                try
                {
                    if (pre != null)
                    {
                        pre.Id = 1;
                        SystemPreference instance = conn.Get<SystemPreference>(1);
                        if (instance != null)
                        {
                            reuslt = conn.Update<SystemPreference>(pre);
                        }
                        else
                        {
                            reuslt = conn.Insert(pre) > 0;
                        }
                    }
                    return reuslt;
//                    SQLiteCommand command = new SQLiteCommand(conn);
//                    command.CommandText = "select count(1) from SYSTEM_PREFERENCE where ID=1";
//                    var set = SqliteHelper.ExecuteDataset(command);
//                    var single = set.SingleVale();
//                    if (single != null)
//                    {
//                        object [] sqlParams = new object[]
//                        {
//                            pre.HostIp,
//                            pre.HostPort,
//                            pre.EnableAutoRun ? 1: 0,
//                            pre.EnableLocalData ? 1:0,
//                            pre.LocalRootPath,
//                            pre.LocalDataInterval,
//                            pre.EnableNetData ? 1:0,
//                            pre.NetDataLocalPort,
//                            pre.NetDataRemoteIp,
//                            pre.NetDataRemotePort,
//                            pre.NetDataInterval,
//                            pre.EnableDbData?1:0,
//                            pre.DbDataInterval
//                        }; 
//                        bool existed = Convert.ToInt32(single) > 0;
//                        string sql = "";
//                        if (existed)
//                        {
//                            sql = "update SYSTEM_PREFERENCE set HOST_IP=@HOST_IP,"+
//                                "HOST_PORT=@HOST_PORT,"+
//                                "ENABLE_AUTORUN=@ENABLE_AUTORUN,"+
//                                "ENABLE_LOCAL_DATA=@ENABLE_LOCAL_DATA,"+
//                                "LOCAL_ROOT_PATH=@LOCAL_ROOT_PATH,"+
//                                "LOCAL_DATA_INTERVAL=@LOCAL_DATA_INTERVAL,"+
//                                "ENABLE_NET_DATA=@ENABLE_NET_DATA,"+
//                                "NET_DATA_LOCAL_PORT=@NET_DATA_LOCAL_PORT,"+
//                                "NET_DATA_REMOTE_IP=@NET_DATA_REMOTE_IP,"+
//                                "NET_DATA_REMOTE_PORT=@NET_DATA_REMOTE_PORT,"+
//                                "NET_DATA_INTERVAL=@NET_DATA_INTERVAL,"+
//                                "ENABLE_DB_DATA=@ENABLE_DB_DATA,"+
//                                "DB_DATA_INTERVAL=@DB_DATA_INTERVAL " +
//                                "where ID=1";
//                            
//                        }
//                        else
//                        {
//                            sql ="insert into SYSTEM_PREFERENCE(1,@HOST_IP,@HOST_PORT,@ENABLE_AUTORUN,@ENABLE_LOCAL_DATA," +
//                                "@LOCAL_ROOT_PATH,@LOCAL_DATA_INTERVAL,@ENABLE_NET_DATA,@NET_DATA_LOCAL_PORT,@NET_DATA_REMOTE_IP," +
//                                "NET_DATA_REMOTE_PORT,@NET_DATA_INTERVAL,@ENABLE_DB_DATA,@DB_DATA_INTERVAL)";
//                        }
//
//                        var result = SqliteHelper.ExecuteNonQuery(conn, sql, sqlParams);
//                    }
                    
                }
                catch (SQLiteException sqlEx)
                {
                    throw;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }
    }
}
