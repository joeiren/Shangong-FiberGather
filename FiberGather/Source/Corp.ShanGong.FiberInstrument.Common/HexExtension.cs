using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Corp.ShanGong.FiberInstrument.Common
{
    public static class HexExtension
    {
        public static string HexToString(this byte[] bytes)
        {
            var hexString = string.Empty;
            if (bytes != null)
            {
                var strB = new StringBuilder();
                for (var i = 0; i < bytes.Length; i++)
                {
                    strB.Append(bytes[i].ToString("x2"));
                }
                hexString = strB.ToString();
            }
            return hexString;
        }

        public static byte[] ToHexByte(this string hexString)
        {
            if (string.IsNullOrEmpty(hexString))
            {
                return default(byte[]);
            }
            var returnBytes = new byte[hexString.Length/2];
            for (var i = 0; i < returnBytes.Length; i++)
            {
                returnBytes[i] = Convert.ToByte(hexString.Substring(i*2, 2), 16);
            }
            return returnBytes;
        }

        /// <summary>
        ///     字节转ASCII
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string AsciiToString(this byte[] bytes)
        {
            var asciiString = string.Empty;
            if (bytes != null)
            {
                asciiString = Encoding.ASCII.GetString(bytes);
            }
            return asciiString;
        }

        public static byte[] ToAsciiByte(this string asciiString)
        {
            byte[] byteArray = null;
            if (!string.IsNullOrEmpty(asciiString))
            {
                byteArray = Encoding.ASCII.GetBytes(asciiString);
            }
            return byteArray;
        }

        /// <summary>
        ///     字符串2位一组 中间加空格
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string DoubleCharOutput(this string source)
        {
            if (string.IsNullOrEmpty(source))
            {
                return source;
            }

            return Regex.Replace(source, @"(?<=[0-9A-F]{2})[0-9A-F]{2}", " $0");
        }
    }
}