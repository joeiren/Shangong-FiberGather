using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.ShanGong.FiberInstrument.IBizSpec
{
    public interface IDataPersistence
    {
        string SaveConfigString
        {
            get;
            set;
        }
        void SavePhysic(long id, decimal? physicVal);
    }
}
