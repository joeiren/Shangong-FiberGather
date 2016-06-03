using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.Model.LocalSelf;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Corp.ShanGong.FiberInstrument.DataPersistence.Test
{
    [TestClass]
    public class SensorBasicPropTest
    {
        [TestMethod]
        public void LoadAllTest()
        {
            SensorBasicPropAccess access = new SensorBasicPropAccess();
            var list = access.LoadAll();
            Assert.AreNotEqual(list.Count,0);

        }


        [TestMethod]
        public void DeleteTest()
        {
            SensorBasicPropAccess access = new SensorBasicPropAccess();
            var result = access.DeleteBy("B07-WD-014");
            Assert.AreEqual(result, true);

        }

        [TestMethod]
        public void InsertTest()
        {
            SensorBasicPropAccess access = new SensorBasicPropAccess();
            SensorBasicProp entity = new SensorBasicProp()
            {
                SensorId = "B07-WD-014",
                SensorIdInServer = 260,
                SensorType = 1,
                DeviceCode = "SQ150503D97",
                OrignalWaveLen1 = 1550.913m,
                OrignalWaveLen2 = decimal.Zero,
                OrignalTemp = 20,
                SensitivityValue = 0,
                TemperatureValue = 0.92m


            };
            var success = access.Insert(entity);
            Assert.AreEqual(success, true);
        }
    }
}
