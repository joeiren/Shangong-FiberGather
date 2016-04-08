using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace FiberMonitor
{
    internal class UDP
    {
        //长度刚好530
        private string sendString1 = "1001"
                                     + "00010203" + "01021203" + "02010203" + "03010203" + "04010203" + "05010203" +
                                     "06010203" + "07010203"
                                     + "08010203" + "09021203" + "0a010203" + "0b010203" + "0c010203" + "0d010203" +
                                     "0e010203" + "0f010203"
                                     + "0002"
                                     + "00010203" + "01021203" + "02010203" + "03010203" + "04010203" + "05010203" +
                                     "06010203" + "07010203"
                                     + "08010203" + "09021203" + "0a010203" + "0b010203" + "0c010203" + "0d010203" +
                                     "0e010203" + "0f010203"
                                     + "0002"
                                     + "00010203" + "01021203" + "02010203" + "03010203" + "04010203" + "05010203" +
                                     "06010203" + "07010203"
                                     + "08010203" + "09021203" + "0a010203" + "0b010203" + "0c010203" + "0d010203" +
                                     "0e010203" + "0f010203"
                                     + "0002"
                                     + "00010203" + "01021203" + "02010203" + "03010203" + "04010203" + "05010203" +
                                     "06010203" + "07010203"
                                     + "08010203" + "09021203" + "0a010203" + "0b010203" + "0c010203" + "0d010203" +
                                     "0e010203" + "0f010203"
                                     + "0002"
                                     + "00010203" + "01021203" + "02010203" + "03010203" + "04010203" + "05010203" +
                                     "06010203" + "07010203"
                                     + "08010203" + "09021203" + "0a010203" + "0b010203" + "0c010203" + "0d010203" +
                                     "0e010203" + "0f010203"
                                     + "0002"
                                     + "00010203" + "01021203" + "02010203" + "03010203" + "04010203" + "05010203" +
                                     "06010203" + "07010203"
                                     + "08010203" + "09021203" + "0a010203" + "0b010203" + "0c010203" + "0d010203" +
                                     "0e010203" + "0f010203"
                                     + "0002"
                                     + "00010203" + "01021203" + "02010203" + "03010203" + "04010203" + "05010203" +
                                     "06010203" + "07010203"
                                     + "08010203" + "09021203" + "0a010203" + "0b010203" + "0c010203" + "0d010203" +
                                     "0e010203" + "0f010203"
                                     + "0002"
                                     + "00010203" + "01021203" + "02010203" + "03010203" + "04010203" + "05010203" +
                                     "06010203" + "07010203"
                                     + "08010203" + "09021203" + "0a010203" + "0b010203" + "0c010203" + "0d010203" +
                                     "0e010203" + "0f010203"
                                     + "0002";

        private string sendString2 = "1005"
                                     + "0001" + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" +
                                     "11111113" + "11111314" + "11111121"
                                     + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" + "11111113" +
                                     "11111314" + "11111121" + "0001"
                                     + "0002" + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" +
                                     "11111113" + "11111314" + "11111121"
                                     + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" + "11111113" +
                                     "11111314" + "11111121" + "0001"
                                     + "0003" + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" +
                                     "11111113" + "11111314" + "11111121"
                                     + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" + "11111113" +
                                     "11111314" + "11111121" + "0001"
                                     + "0004" + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" +
                                     "11111113" + "11111314" + "11111121"
                                     + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" + "11111113" +
                                     "11111314" + "11111121" + "0001"
                                     + "0005" + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" +
                                     "11111113" + "11111314" + "11111121"
                                     + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" + "11111113" +
                                     "11111314" + "11111121" + "0001"
                                     + "0006" + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" +
                                     "11111113" + "11111314" + "11111121"
                                     + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" + "11111113" +
                                     "11111314" + "11111121" + "0001"
                                     + "0007" + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" +
                                     "11111113" + "11111314" + "11111121"
                                     + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" + "11111113" +
                                     "11111314" + "11111121" + "0001"
                                     + "0008" + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" +
                                     "11111113" + "11111314" + "11111121"
                                     + "12341111" + "11115413" + "11114534" + "11111343" + "11115431" + "11111113" +
                                     "11111314" + "11111121" + "0001";

        /// <summary>
        ///     发送(16)string的方法
        /// </summary>
        public static void Send(string SendStr)
        {
            byte[] sendData = null; //要发送的字节数组 
            // byte[] sendData2 = null;//要发送的字节数组 
            UdpClient client = null;
            //暂发本地
            var remoteIP = IPAddress.Parse(GetAddressIP()); //IPAddress.Parse("192.168.1.127");
            var remotePort = 8001;
            var remotePoint = new IPEndPoint(remoteIP, remotePort); //实例化一个远程端点 

            //while (true)
            //{

            sendData = HexToByte(SendStr);
            //   sendData2 = HexToByte(sendString2);

            client = new UdpClient();
            // client.Send(sendData, sendData.Length, remotePoint);//将数据发送到远程端点 
            client.Send(sendData, sendData.Length, remotePoint);
            client.Close(); //关闭连接 

            //  }
        }

        /// <summary>
        ///     发送byte[]法
        /// </summary>
        public static void Send(byte[] sendData)
        {
            UdpClient client = null;
            var remoteIP = //IPAddress.Parse("192.168.0.19"); //模块地址
                IPAddress.Parse(GetAddressIP());
            var remotePort = 4567;
            var remotePoint = new IPEndPoint(remoteIP, remotePort);

            client = new UdpClient();
            client.Send(sendData, sendData.Length, remotePoint);
            client.Close(); //关闭连接 
        }

        /// <summary>
        ///     获取本地的IP地址(4),测试阶段使用
        /// </summary>
        /// <returns></returns>
        public static string GetAddressIP()
        {
            var AddressIP = string.Empty;
            foreach (var _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }

        /// <summary>
        ///     16位 的 字符串 转为byte[]
        /// </summary>
        /// <returns></returns>
        private static byte[] HexToByte(string hexString)
        {
            var returnBytes = new byte[hexString.Length/2];
            for (var i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i*2, 2), 16);
            }
            return returnBytes;
        }

        /// <summary>
        ///     收
        /// </summary>
        private static string Rec()
        {
            UdpClient client = null;
            var remotePoint = new IPEndPoint(IPAddress.Any, 0);
            try
            {
                client = new UdpClient(8001);
                var receiveData = client.Receive(ref remotePoint); //接收数据 
                var receiveString = ToHexString(receiveData);
                MessageBox.Show(receiveString);
                client.Close(); //关闭连接 
            }
            catch (Exception e)
            {
                client.Close();
            }
            return "";
        }

        /// <summary>
        ///     byte转字符串(16)
        /// </summary>
        /// <returns></returns>
        public static string ToHexString(byte[] bytes)
        {
            var hexString = string.Empty;
            if (bytes != null)
            {
                var strB = new StringBuilder();
                for (var i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("X2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }
    }
}