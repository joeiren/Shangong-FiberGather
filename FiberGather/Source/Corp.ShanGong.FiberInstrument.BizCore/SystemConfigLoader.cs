using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.DataPersistence;
using Corp.ShanGong.FiberInstrument.Model.LocalSelf;

namespace Corp.ShanGong.FiberInstrument.BizCore
{
    public class SystemConfigLoader
    {
        private static SystemPreference _systemConfig;
        public static SystemPreference SystemConfig
        {
            get
            {
                if (_systemConfig == null)
                {
                    _systemConfig = SystemPreferenceAccess.LoadSystemPreference();
                }
                return _systemConfig;
            }
            set
            {
                _systemConfig = value;
                SystemPreferenceAccess.SaveSystemPreference(_systemConfig);
            }
        }

    }
}
