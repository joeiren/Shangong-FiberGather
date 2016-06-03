using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.Common;
using Corp.ShanGong.FiberInstrument.IBizSpec;
using Corp.ShanGong.FiberInstrument.Model;
using Corp.ShanGong.FiberInstrument.Net;
using Corp.ShanGong.FiberInstrument.Setting;

namespace Corp.ShanGong.FiberInstrument.BizCore
{
    public class InstrumentOperation
    {
        private const string ReadSn = "1003060000";

        public InstrumentOperation(int localPort, string remoteIp, int remotePort)
        {
            Communication = new UdpCommunication(localPort, remoteIp, remotePort);
        }

        public UdpCommunication Communication
        {
            get;
            private set;
        }

        public async Task<bool> TestConnection()
        {
            try
            {
                var sendData = ReadSn.ToHexByte();
                var len = await Communication.SendDataAsync(sendData, sendData.Length);

                if (Communication.RecvChanel.Client.Available > 0)
                {
                    await Communication.ReceiveDataAsync();
                    return true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return false;
        }

        public async Task<Tuple<bool, string>> Start()
        {
            if (Communication == null)
            {
                return new Tuple<bool, string>(false, "The object Communication is null!");
            }
//
//            string hexstr = "1020060300";  // 停止
//            var senddata = hexstr.ToHexByte();
//            var len = await Communication.SendDataAsync(senddata, senddata.Length);

            try
            {
                var hexstr = "1004000000";
                var senddata = hexstr.ToHexByte();
                var len = await Communication.SendDataAsync(senddata, senddata.Length);

                hexstr = "1005000200";
                senddata = hexstr.ToHexByte();
                len = await Communication.SendDataAsync(senddata, senddata.Length);

                hexstr = "100613ec00";
                senddata = hexstr.ToHexByte();
                len = await Communication.SendDataAsync(senddata, senddata.Length);

                hexstr = "1020060100";
                senddata = hexstr.ToHexByte();
                len = await Communication.SendDataAsync(senddata, senddata.Length);
                Thread.Sleep(200);
                var result = Communication.RecvChanel.Client.Available > 0;
                return new Tuple<bool, string>(result, result ? "" : "网络无响应");
            }
            catch (Exception ex)
            {
                var bex = new BoundaryException(ex);
                return new Tuple<bool, string>(false, bex.Display);
            }
        }

        /// <summary>
        /// 调试模式（用来获取光谱）
        /// </summary>
        /// <returns></returns>
        public async Task<Tuple<bool, string>> StartWithDebug()
        {
            if (Communication == null)
            {
                return new Tuple<bool, string>(false, "The object Communication is null!");
            }

            try
            {
                var hexstr = "1004000000";
                var senddata = hexstr.ToHexByte();
                var len = await Communication.SendDataAsync(senddata, senddata.Length);

                hexstr = "1005000200";
                senddata = hexstr.ToHexByte();
                len = await Communication.SendDataAsync(senddata, senddata.Length);

                hexstr = "100613ec00";
                senddata = hexstr.ToHexByte();
                len = await Communication.SendDataAsync(senddata, senddata.Length);

                hexstr = "1020060200"; // 发送调试指令
                senddata = hexstr.ToHexByte();
                len = await Communication.SendDataAsync(senddata, senddata.Length);
                Thread.Sleep(200);
                var result = Communication.RecvChanel.Client.Available > 0;
                return new Tuple<bool, string>(result, result ? "" : "网络无响应");
            }
            catch (Exception ex)
            {
                var bex = new BoundaryException(ex);
                return new Tuple<bool, string>(false, bex.Display);
            }
        }

        public async Task<bool> Stop()
        {
            var hexstr = "1020060300"; // 停止
            var senddata = hexstr.ToHexByte();
            var len = await Communication.SendDataAsync(senddata, senddata.Length);
            var avilable = Communication.RecvChanel.Client.Available;
            while (avilable != 0)
            {
                await Communication.ReceiveDataAsync();
                avilable = Communication.RecvChanel.Client.Available;
            }
            return true;
        }



        public async Task<List<PhysicalQuantity>> ReadLoop(IPhysicalCalculator calc)
        {
            try
            {
                var list = new List<PhysicalQuantity>();
                var breakCount =SystemConfigLoader.SystemConfig.CollectInterval;

                var i = 0;
                while (i < breakCount)
                {
                    var result = await Communication.ReceiveDataAsync();
                    if (result.Length < 530)  // 
                    {
                        continue;
                    }
                    if (i == breakCount - 1)
                    {
                        var recTime = DateTime.Now;

                        var message = new FrequencyMessage();
                        message.Parse(result);

                        var quantity = PhysicalQuantity.LoadFrom(message, calc, recTime);
                        list.Add(quantity);
                    }
                    i++;
                }
                return list;
            }
            catch (BoundaryException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new BoundaryException(ex);
            }
        }

        public async Task<AdSpectraQuantity> ReadLoopAd()
        {
            var adData = AdDataRead();
            var message = new AdMessage();
            message.Parse(adData.Result);
            var adQuantity = AdSpectraQuantity.LoadForm(message);
            return adQuantity;
        }

        public async Task<byte[]> AdDataRead()
        {
             int _offset = 0;
            byte[]  _adData = new byte[AdSpectraQuantity.MESSAGE_LENGTH];
            _offset -= FrequencyMessage.MESSAGE_LENGTH;
            var result = await Communication.ReceiveDataAsync();

            while (_offset < AdSpectraQuantity.MESSAGE_LENGTH)
            {
                if (_offset + result.Length > 0)
                {
                    if (_offset < 0)
                    {
                        Array.Copy(result, 0 - _offset, _adData, 0, _offset + result.Length);
                    }
                    else
                    {
                        Array.Copy(result, 0, _adData, _offset, result.Length);
                    }
                }
                _offset += result.Length;
                if (_offset >= AdSpectraQuantity.MESSAGE_LENGTH)
                {
                    break;
                }
                result = await Communication.ReceiveDataAsync();
            }
            return _adData;
        }
    }
}