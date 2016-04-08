using System.Net;

namespace Corp.ShanGong.FiberInstrument.Net
{
    public static class Common
    {
        public static string GetLocalHost()
        {
            var AddressIP = string.Empty;
            foreach (var _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                    break;
                }
            }
            return AddressIP;
        }
    }
}