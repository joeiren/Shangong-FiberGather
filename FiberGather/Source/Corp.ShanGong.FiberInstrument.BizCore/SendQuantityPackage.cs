using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.Net;

namespace Corp.ShanGong.FiberInstrument.BizCore
{
    /// <summary>
    ///     物理量数据发送包
    /// </summary>
    public class SendQuantityPackage
    {
        private static UdpCommunication _udp;

        public SendQuantityPackage(int localPort, string remote, int remotePort, PhysicalQuantity data)
        {
            QuantityData = data;
            LocalPort = localPort;
            RemoteIp = remote;
            RemotePort = remotePort;
        }

        public int LocalPort
        {
            get;
            private set;
        }

        public string RemoteIp
        {
            get;
            private set;
        }

        public int RemotePort
        {
            get;
            private set;
        }

        public PhysicalQuantity QuantityData
        {
            get;
            private set;
        }

        public byte[] Build()
        {
            var result = new List<byte>();
            result.AddRange(QuantityData.CurrentTime.ToString("yyyyMMddHHmmssfff").ToAsciiByte());
            for (var i = 0; i < QuantityData.ChannelValues.Length; i++)
            {
                result.AddRange((i + 1).ToString().PadLeft(2, ' ').ToAsciiByte());
                for (var j = 0; j < QuantityData.ChannelValues[i].GratingValues.Length; j++)
                {
                    result.AddRange((j + 1).ToString().PadLeft(2, ' ').ToAsciiByte());
                    var wave = (QuantityData.ChannelValues[i].GratingValues[j].WaveLengthExtension ?? decimal.Zero);
                    result.AddRange(wave.ToString().PadLeft(15, ' ').ToAsciiByte());
                    var physicalVal = (QuantityData.ChannelValues[i].GratingValues[j].PhysicalValue ?? decimal.Zero);
                    result.AddRange(physicalVal.ToString().PadLeft(15, ' ').ToAsciiByte());
                }
            }
            return result.ToArray();
        }

        public async Task SendData()
        {
            var comm = GetUdpInstance();
            var data = Build();
            var offset = 0;
            while (offset < data.Length)
            {
                var buf = data.Skip(offset).Take(1000).ToArray();
                await comm.SendDataAsync(buf, buf.Length);
                offset += buf.Length;
            }
        }

        private UdpCommunication GetUdpInstance()
        {
            if (_udp == null || !_udp.SendChanel.Client.IsBound)
            {
                _udp = new UdpCommunication(LocalPort, RemoteIp, RemotePort);
            }
            return _udp;
        }
    }
}