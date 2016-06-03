using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Corp.ShanGong.FiberInstrument.DataPersistence.Test
{
    [TestClass]
    public class SystemPreferenceTest
    {
        [TestMethod]
        public void LoadTest()
        {
            var setting = SystemPreferenceAccess.LoadSystemPreference();
            Assert.IsNotNull(setting);
            var ip = setting.NetDataRemoteIp;
        }


        [TestMethod]
        public void SaveTest()
        {
            var setting = SystemPreferenceAccess.LoadSystemPreference();
            setting.LocalRootPath = "D://";
            setting.EnableDbData = true;
            setting.EnableAutoRun = true;
            bool success = SystemPreferenceAccess.SaveSystemPreference(setting);
            Assert.IsTrue(success);
        }
    }
}
