using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.BizCore;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Corp.ShanGong.FiberInstrument.Model.Test
{
    [TestClass]
    public class PhysicalQuantityTest
    {
        private UdpCommunication _udp;

        [TestInitialize]
        public void Init()
        {
            _udp = new UdpCommunication(8001, "192.168.0.19", 4567);
        }

        [TestCleanup]
        public void Close()
        {
            _udp.SendChanel.Close();
        }

        [TestMethod]
        public async Task PhysicalQuantityConvert()
        {
            if (_udp == null)
            {
                Assert.IsTrue(false);
            }

            var hexstr = "1020060300"; // 停止
            var senddata = hexstr.ToHexByte();
            var len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);

            hexstr = "1004000000";
            senddata = hexstr.ToHexByte();
            len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);

            hexstr = "1005000200";
            senddata = hexstr.ToHexByte();
            len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);

            hexstr = "100613ec00";
            senddata = hexstr.ToHexByte();
            len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);

            hexstr = "1020060100";
            senddata = hexstr.ToHexByte();
            len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);

            var list = new List<PhysicalQuantity>();
            var breakCount = 1010;
            var i = 0;
            while (i++ < breakCount)
            {
                var result = await _udp.ReceiveDataAsync();
                Assert.IsTrue(result.Length > 0);
                Debug.WriteLine(result.HexToString().DoubleCharOutput());
                var message = new FrequencyMessage();
                message.Parse(result);

                Assert.IsNotNull(message.DeviceId);
                Assert.IsNotNull(message.FunctionCode);
                Assert.IsNotNull(message.Channels);
                Assert.AreNotSame(message.Channels.Length, 0);
                //Thread.Sleep(10);

                //var quantity = PhysicalQuantity.LoadFrom(message);
                //list.Add(quantity);
            }

            hexstr = "10200603"; // 停止
            senddata = hexstr.ToHexByte();
            len = await _udp.SendDataAsync(senddata, senddata.Length);
        }
    }
}