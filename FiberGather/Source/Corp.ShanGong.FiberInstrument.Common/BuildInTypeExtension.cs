using System;
using System.IO;

namespace Corp.ShanGong.FiberInstrument.Common
{
    public static class BuildInTypeExtension
    {
        public static bool IsNumber(this string orignal)
        {
            if (string.IsNullOrWhiteSpace(orignal))
            {
                return false;
            }
            var isNumber = true;
            Array.ForEach(orignal.ToCharArray(), it => isNumber &= char.IsNumber(it));
            return isNumber;
        }

        public static string FirstSplitVal(this string orignal)
        {
            if (!string.IsNullOrWhiteSpace(orignal))
            {
                var value = orignal.Split(':');
                if (value.Length > 0 && value[0].IsNumber())
                {
                    return value[0];
                }
            }
            return null;
        }

        public static decimal? ToDecimalNullable(this string orignal)
        {
            if (string.IsNullOrWhiteSpace(orignal))
            {
                return null;
            }
            return Convert.ToDecimal(orignal);
        }

        public static string StartWithDateStamp(this string orignal)
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff") + " : " + orignal;
        }

        public static string ToFilePathString(this DateTime now)
        {
            return Path.Combine(now.Year.ToString(), now.Month.ToString().PadLeft(2, '0'),
                now.Day.ToString().PadLeft(2, '0'));
        }
    }
}