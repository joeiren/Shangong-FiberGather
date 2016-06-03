using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.Model.LocalSelf;
using Dapper;
using Dapper.Contrib.Extensions;

namespace Corp.ShanGong.FiberInstrument.DataPersistence
{
    public class SensorBasicPropAccess
    {
        public bool Insert(SensorBasicProp entity)
        {
            using (var conn = SqliteHelper.GetLocalConnection())
            {
                try
                {
                    var rowNum = conn.Insert(entity);
                    return rowNum > 0;
                }
                catch (SQLiteException )
                {
                    throw;
                }
                catch (Exception )
                {
                    throw;
                }
            }
        }

        public bool Update(SensorBasicProp entity)
        {
            using (var conn = SqliteHelper.GetLocalConnection())
            {
                try
                {
                    var dbInstance = conn.Get<SensorBasicProp>(entity.SensorId);
                    return dbInstance != null && conn.Update<SensorBasicProp>(entity);
//                    string sql = "udpate SENSOR_BASIC_PROP set Sensor_ID_IN_SERVER=@SENSOR_ID_IN_SERVER," +
//                                 "SENSOR_TYPE=@SENSOR_TYPE," +
//                                 "DEVICE_CODE=@DEVICE_CODE," +
//                                 "ORIGNAL_WAVE_LEN1=@ORIGNAL_WAVE_LEN1," +
//                                 "ORIGNAL_WAVE_LEN2=@ORIGNAL_WAVE_LEN2," +
//                                 "ORIGNAL_TEMP=@ORIGNAL_TEMP," +
//                                 "SENSITIVITY_VALUE=@SENSITIVITY_VALUE," +
//                                 "TEMPERATURE_VALUE=@TEMPERATURE_VALUE," +
//                                 "DISPLACE_VALUE=@DISPLACE_VALUE," +
//                                 "GFRP_CTE=@GFRP_CTE," +
//                                 "STRUCTURAL_CTE=@STRUCTURAL_CTE " +
//                                 "where SENSOR_ID=@SENSOR_ID";
//
//                    object[] sqlParams = new object[]
//                    {
//                        entity.SensorIdInServer,
//                        entity.SensorType,
//                        entity.DeviceCode,
//                        entity.OrignalWaveLen1,
//                        entity.OrignalWaveLen2,
//                        entity.OrignalTemp,
//                        entity.SensitivityValue,
//                        entity.TemperatureValue,
//                        entity.DisplaceValue,
//                        entity.GfrpCte,
//                        entity.StructuralCte,
//                        entity.SensorId
//                    };
//                    SqliteHelper.ExecuteNonQuery(conn, sql, sqlParams);
                }
                catch (SQLiteException )
                {
                    throw;
                }
                catch (Exception )
                {
                    throw;
                }
            }
        }

        public bool DeleteBy(string sensorId)
        {
            using (var conn = SqliteHelper.GetLocalConnection())
            {
                try
                {
                    string command = "delete from SENSOR_BASIC_PROP where SensorId=@SensorId ";
                    var success = conn.Execute(command, new { SensorId = sensorId });
                   return success == 1;
//                    object[] sqlParams = new object[]
//                    {
//                        sensorId
//                    };
//                    SqliteHelper.ExecuteNonQuery(conn, command, sqlParams);
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

        public void ImportFromExcel(string path)
        {
            
        }

        public List<SensorBasicProp> LoadAll()
        {
            using (var conn = SqliteHelper.GetLocalConnection())
            {
                try
                {
                    var list = conn.Query<SensorBasicProp>("select * from SENSOR_BASIC_PROP").ToList();

//                    SQLiteCommand command = new SQLiteCommand(conn);
//                    command.CommandText = "select * from SENSOR_BASIC_PROP ";
//                    var set = SqliteHelper.ExecuteDataset(command);
//                    return SensorBasicProp.ParseMulti(set);
                    return list;
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
