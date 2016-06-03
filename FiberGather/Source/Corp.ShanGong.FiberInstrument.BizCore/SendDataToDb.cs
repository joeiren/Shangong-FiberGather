using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.DataPersistence;
using Corp.ShanGong.FiberInstrument.IBizSpec;
using Corp.ShanGong.FiberInstrument.Model.LocalSelf;
using Corp.ShanGong.FiberInstrument.Setting;

namespace Corp.ShanGong.FiberInstrument.BizCore
{
    public class SendDataToDb
    {
        public static void Save(PhysicalQuantity data, IDataPersistence dataStore)
        {
            if (data != null)
            {
                if (!LastSaveDate.HasValue || (LastSaveDate.HasValue && data.CurrentTime.Subtract(LastSaveDate.Value) > TimeSpan.FromSeconds(5)))
                {
                    foreach (var channel in data.ChannelValues)
                    {
                        foreach (var sensor in channel.GratingValues)
                        {
                            dataStore.SaveConfigString = SystemConfigLoader.SystemConfig.DbConfigString;
                            dataStore.SavePhysic(sensor.ExternalId, sensor.PhysicalValue);
                        }
                    }
                    LastSaveDate = data.CurrentTime;
                }
            }
        }


        public static DateTime? LastSaveDate
        {
            get;
            set;
        }
    }
}
