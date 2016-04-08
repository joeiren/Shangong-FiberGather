using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.BizCore;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Corp.ShanGong.FiberInstrument.Model.Test
{
    [TestClass]
    public class FrequencyAdMessageTest
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

            hexstr = "1020060200"; //读取一次，调试模式
            senddata = hexstr.ToHexByte();
            len = await _udp.SendDataAsync(senddata, senddata.Length);
            Assert.IsTrue(len > 0);

            var buffer = new byte[FrequencyAdMessage.MESSAGE_LENGTH];
            //Queue<int> q = new Queue<int>();
            var offset = 0;
            {
                while (offset < buffer.Length)
                {
                    var result = await _udp.ReceiveDataAsync();
                    Array.Copy(result, 0, buffer, offset, result.Length);
                    offset += result.Length;
                    //q.Enqueue(result.Length);
                    Debug.WriteLine("offset = " + offset);
                }

                if (offset == FrequencyAdMessage.MESSAGE_LENGTH)
                {
                    var message = new FrequencyAdMessage();
                    message.Parse(buffer);

                    AdSpectraQuantity.LoadForm(message.Message2);
                }
            }

            hexstr = "1020060300"; // 停止
            senddata = hexstr.ToHexByte();
            len = await _udp.SendDataAsync(senddata, senddata.Length);
        }
    }
}