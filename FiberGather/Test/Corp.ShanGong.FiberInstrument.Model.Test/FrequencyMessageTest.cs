using System.Diagnostics;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Corp.ShanGong.FiberInstrument.Model.Test
{
    [TestClass]
    public class FrequencyMessageTest
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
        public async Task MessageParse()
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
                var message = new FrequencyMessage();
                message.Parse(result);

                Assert.IsNotNull(message.DeviceId);
                Assert.IsNotNull(message.FunctionCode);
                Assert.IsNotNull(message.Channels);
                Assert.AreNotSame(message.Channels.Length, 0);
                //Thread.Sleep(10);
            }

            hexstr = "10200603"; // 停止
            senddata = hexstr.ToHexByte();
            len = await _udp.SendDataAsync(senddata, senddata.Length);
        }
    }
}