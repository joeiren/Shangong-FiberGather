using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Corp.ShanGong.FiberInstrument.Net.Test
{
    [TestClass]
    public class UdpCommunicationTest
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
        public async Task SendHzStartTest()
        {
            var hexstr = "10040000";
            var senddata = hexstr.ToHexByte();
            var len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);
        }

        [TestMethod]
        public async Task SendStepLengthTest()
        {
            var hexstr = "10050002";
            var senddata = hexstr.ToHexByte();
            var len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);
        }

        [TestMethod]
        public async Task SendHzEndTest()
        {
            var hexstr = "100613ec";
            var senddata = hexstr.ToHexByte();
            var len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);
        }

        [TestMethod]
        public async Task SendLoopGather()
        {
            var hexstr = "10200601";
            var senddata = hexstr.ToHexByte();
            var len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);
        }

        [TestMethod]
        public async Task ReceiveDataTest()
        {
            try
            {
                var result = await _udp.ReceiveDataAsync();
                Assert.IsTrue(result.Length > 0);
            }
            catch (Exception ex)
            {
                var exStr = ex.ToString();
            }
        }

        [TestMethod]
        public async Task IntegrateTest1()
        {
            if (_udp == null)
            {
                Assert.IsTrue(false);
            }

            var hexstr = "10200603"; // 停止
            var senddata = hexstr.ToHexByte();
            var len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);

            hexstr = "10040000";
            senddata = hexstr.ToHexByte();
            len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);

            hexstr = "10050002";
            senddata = hexstr.ToHexByte();
            len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);

            hexstr = "100613ec";
            senddata = hexstr.ToHexByte();
            len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);

            hexstr = "10200601";
            senddata = hexstr.ToHexByte();
            len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);

            var breakCount = 10;
            var i = 0;
            while (i++ < breakCount)
            {
                var result = await _udp.ReceiveDataAsync();
                Assert.IsTrue(result.Length > 0);
                Debug.WriteLine(result.HexToString().DoubleCharOutput());
                //Thread.Sleep(10);
            }

            hexstr = "10200603"; // 停止
            senddata = hexstr.ToHexByte();
            len = await _udp.SendDataAsync(senddata, senddata.Length);
        }
    }
}