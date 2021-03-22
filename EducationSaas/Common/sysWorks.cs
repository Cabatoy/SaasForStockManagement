using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class SysWorks
    {
        public enum DurumTip
        {
            Ok = 1,
            Null = 2,
            Err = 3,
            NoData = 4,
            ConflictKey = 5,
            AskQuestion = 6
        }
        public static string ToStringExact(this Object obj)
        {
            string result = "";
            try
            {
                if (obj != null)
                {
                    result = obj.ToString();
                }
            }
            catch (Exception exc)
            {

            }
            return result.Trim();
        }
    }


}
