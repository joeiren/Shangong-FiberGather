using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace Corp.ShanGong.FiberInstrument.Net
{
    public class UdpCommunication
    {
        public UdpCommunication(string local, int localPort, string server, int serverPort)
            : this(localPort, server, serverPort)
        {
            LocalIp = local;
        }

        public UdpCommunication(int localPort, string server, int serverPort)
        {
            if (string.IsNullOrEmpty(LocalIp))
            {
                LocalIp = Common.GetLocalHost();
            }
            var address = IPAddress.Parse(LocalIp);
            Local = new IPEndPoint(address, localPort);
            RecvChanel = new UdpClient(Local);
            RecvChanel.Client.ReceiveBufferSize = 1024*200;
            //RecvChanel.Client.SetSocketOption(SocketOptionLevel.IP, SocketOptionName.PacketInformation, true);
            //SendChanel = new UdpClient(Local);
            SendChanel = RecvChanel;
            var serverAddress = IPAddress.Parse(server);
            Remote = new IPEndPoint(serverAddress, serverPort);
        }

        public string LocalIp
        {
            get;
            set;
        }

        public IPEndPoint Local
        {
            get;
            private set;
        }

        public IPEndPoint Remote
        {
            get;
            set;
        }

        public UdpClient RecvChanel
        {
            get;
            private set;
        }

        public UdpClient SendChanel
        {
            get;
            private set;
        }

        public async Task<int> SendDataAsync(byte[] data, int length)
        {
            if (SendChanel == null)
            {
                throw new SocketException();
            }
            if (data == null)
            {
                throw new ArgumentNullException();
            }

            return await SendChanel.SendAsync(data, data.Length, Remote);
        }

        public async Task<byte[]> ReceiveDataAsync()
        {
            if (RecvChanel == null)
            {
                throw new SocketException();
            }
            var result = await RecvChanel.ReceiveAsync();
            return result.Buffer;
        }

        public void Reset()
        {
            if (SendChanel != null)
            {
                SendChanel.Close();
                SendChanel = null;
            }
        }
    }
}