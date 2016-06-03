using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Corp.ShanGong.FiberInstrument.Common
{
    public static class DataRowExtension
    {
        public static T GetValue<T>(this DataRow row, string itemName, T defaultVal) where T : struct
        {
            if (row != null && row[itemName] != null)
            {
                return (T)Convert.ChangeType(row[itemName], typeof (T));
            }
            return defaultVal;
        }

        public static T GetValueRef<T>(this DataRow row, string itemName, T defaultVal) where T : class 
        {
            if (row != null && row[itemName] != null)
            {
                return (T)Convert.ChangeType(row[itemName], typeof(T));
            }
            return defaultVal;
        }

        public static object SingleVale(this DataSet set)
        {
            if (set != null && set.Tables.Count > 0)
            {
                var table = set.Tables[0];
                if (table != null && table.Rows.Count > 0 && table.Columns.Count > 0)
                {
                    return table.Rows[0][0];
                }
            }
            return null;
        }
    }
}
