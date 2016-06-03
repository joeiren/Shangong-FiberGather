using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OracleClient;
using Corp.ShanGong.FiberInstrument.IBizSpec;

namespace Corp.ShanGong.FiberInstrument.ProjectSpec
{
    public class OracleDataPersistence : IDataPersistence
    {
        public void SavePhysic(long id, decimal? physicVal)
        {
            if (!string.IsNullOrEmpty(SaveConfigString))
            {
                using (OracleConnection conn = new OracleConnection(SaveConfigString))
                {
                    try
                    {
                        conn.Open();

                        OracleCommand cmdOracle = new OracleCommand();
                        cmdOracle.Connection = conn;
                        cmdOracle.CommandType = System.Data.CommandType.StoredProcedure;
                        cmdOracle.CommandText = "whld1";

                        OracleParameter strSensorID = cmdOracle.Parameters.Add("S_id", OracleType.Number);
                        strSensorID.Direction = ParameterDirection.Input;
                        strSensorID.Value = id;

                        OracleParameter strValue = cmdOracle.Parameters.Add("S_data", OracleType.Number);
                        strValue.Direction = ParameterDirection.Input;
                        strValue.Value = physicVal ?? decimal.Zero;

                        cmdOracle.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
        }


        public string SaveConfigString
        {
            get;
            set;
        }
    }
}
