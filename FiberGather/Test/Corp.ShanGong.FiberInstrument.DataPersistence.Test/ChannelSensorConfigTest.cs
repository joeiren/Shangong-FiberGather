using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Corp.ShanGong.FiberInstrument.DataPersistence.Test
{
    [TestClass]
    public class ChannelSensorConfigTest
    {
        [TestMethod]
        public void LoadWithSensorBySensorIdTest()
        {
            ChannelSensorConfigAccess access = new ChannelSensorConfigAccess();
            access.LoadWithSensorBySensorId("B01-YB-001");
        }

        [TestMethod]
        public void UpdateTest()
        {
            ChannelSensorConfigAccess access = new ChannelSensorConfigAccess();
            var config = access.LoadWithSensorBySensorId("B01-YB-001");
            Assert.IsNotNull(config);
            var success = access.Update(config);
            Assert.IsTrue(success);
        }
        [TestMethod]
        public void LoadBySensorIdTest()
        {
            ChannelSensorConfigAccess access = new ChannelSensorConfigAccess();
            var instance = access.LoadBySensorId("B01-YB-001");
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void LoadTest()
        {
            ChannelSensorConfigAccess access = new ChannelSensorConfigAccess();
            var instance = access.Load(1);
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void LoadGroupByChannelTest()
        {
            ChannelSensorConfigAccess access = new ChannelSensorConfigAccess();
            var instance = access.LoadGroupByChannel(1);
            Assert.AreNotEqual(instance.Count,0);
        }
        [TestMethod]
        public void CalcuteWaveWithUpdateTest()
        {
            ChannelSensorConfigAccess access = new ChannelSensorConfigAccess();
            var instance = access.LoadGroupByChannel(2);
            foreach (var s in instance)
            {
                var config = access.LoadWithSensorBySensorId(s.SensorId);
  
                var success = access.Update(config);
                Assert.IsTrue(success);
            }
        }
    }
}
