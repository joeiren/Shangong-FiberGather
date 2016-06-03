using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Corp.ShanGong.FiberInstrument.IBizSpec;

namespace Corp.ShanGong.FiberInstrument.ProjectSpec
{
    /// <summary>
    /// 按访问Url方式传输，最终存储到数据库
    /// </summary>
    public class UrlServiceTransfer : IDataPersistence
    {
      
        public void SavePhysic(long id, decimal? physicVal)
        {
            if (!string.IsNullOrEmpty(SaveConfigString) && id > 0 && physicVal.HasValue)
            {
                string url = SaveConfigString + "SENSOR_ID=" + id + "&DATA=" + physicVal.Value;
                HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(url);
                webRequest.Method = "GET";
                HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
                StreamReader sr = new StreamReader(webResponse.GetResponseStream(), Encoding.Unicode);
                var result = sr.ReadToEnd(); 
            }
        }

        /// <summary>
        /// 服务URL地址(http://112.16.169.54:8888/LegendData/Ming?)
        /// </summary>
        public string SaveConfigString
        {
            get;
            set;
        }
    }
}
