using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Common
{
    public static class myExtension
    {
      
        public static bool? _ToBoolean(this object gelen)
        {
            bool? nullable;
            try
            {
                if (gelen == null) throw new Exception();
                nullable = new bool?(Convert.ToBoolean(gelen));
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    nullable = new bool?(Convert.ToBoolean(gelen));
                }
                catch (Exception)
                {
                    nullable = null;
                }
            }
            return nullable;
        }

        public static bool _ToBooleanR(this object gelen)
        {
            bool flag3;
            try
            {
                if (gelen == null) throw new Exception();
                flag3 = Convert.ToBoolean(gelen);
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    flag3 = Convert.ToBoolean(gelen);
                }
                catch (Exception)
                {
                    flag3 = false;
                }
            }
            return flag3;
        }

        public static DateTime? _ToDateTime(this object gelen)
        {
            DateTime? nullable;
            try
            {
                if (gelen == null) throw new Exception();
                nullable = new DateTime?(Convert.ToDateTime(gelen));
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    nullable = new DateTime?(Convert.ToDateTime(gelen));
                }
                catch (Exception)
                {
                    nullable = null;
                }
            }
            return nullable;
        }

        public static DateTime _ToDateTimeR(this object gelen)
        {
            DateTime minValue;
            try
            {
                if (gelen == null) throw new Exception();
                minValue = Convert.ToDateTime(gelen);
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    minValue = Convert.ToDateTime(gelen);
                }
                catch (Exception)
                {
                    minValue = DateTime.MinValue;
                }
            }
            return minValue;
        }

        public static DateTime _ToDateTimeOnly(this DateTime gelen)
        {
            DateTime minValue;
            try
            {
                if (gelen == null) throw new Exception();
                minValue = new DateTime(gelen.Year, gelen.Month, gelen.Day);
            }
            catch (Exception)
            {
                try
                {
                    minValue = new DateTime(gelen.Year, gelen.Month, gelen.Day);
                }
                catch (Exception)
                {
                    minValue = DateTime.MinValue;
                }
            }
            return minValue;
        }

        public static decimal? _ToDecimal(this object gelen)
        {
            decimal? nullable;
            try
            {
                if (gelen == null) throw new Exception();
                nullable = new decimal?(Convert.ToDecimal(gelen));
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    nullable = new decimal?(Convert.ToDecimal(gelen));
                }
                catch (Exception)
                {
                    nullable = null;
                }
            }
            return nullable;
        }

        public static decimal _ToDecimalR(this object gelen)
        {
            decimal zero;
            try
            {
                if (gelen == null) throw new Exception();
                zero = Convert.ToDecimal(gelen);
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    zero = Convert.ToDecimal(gelen);
                }
                catch (Exception)
                {
                    zero = decimal.Zero;
                }
            }
            return zero;
        }

        public static double? _ToDouble(this object gelen)
        {
            double? nullable;
            try
            {
                if (gelen == null) throw new Exception();
                nullable = new double?(Convert.ToDouble(gelen));
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    nullable = new double?(Convert.ToDouble(gelen));
                }
                catch (Exception)
                {
                    nullable = null;
                }
            }
            return nullable;
        }

        public static double _ToDoubleR(this object gelen)
        {
            double num2;
            try
            {
                if (gelen == null) throw new Exception();
                num2 = Convert.ToDouble(gelen);
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    num2 = Convert.ToDouble(gelen);
                }
                catch (Exception)
                {
                    num2 = 0.0;
                }
            }
            return num2;
        }

        /// <summary>
        /// Verilen ifadeyi float cinsine dönüştürür.
        /// </summary>
        /// <param name="gelen">Gelen İfadesi Stringe Dönüştürülecektir.</param>
        /// <returns>float</returns>
        public static float? _ToFloat(this object gelen)
        {
            float? nullable;
            try
            {
                if (gelen == null) throw new Exception();
                nullable = new float?(float.Parse(gelen.ToString()));
            }
            catch (Exception)
            {
                try
                {
                    if (string.IsNullOrEmpty(gelen.ToString()) || string.IsNullOrWhiteSpace(gelen.ToString())) throw new Exception();
                    nullable = new float?(float.Parse(gelen.ToString()));
                }
                catch (Exception)
                {
                    nullable = null;
                }
            }
            return nullable;
        }
        /// <summary>
        /// Verilen ifadeyi float cinsine dönüştürür.
        /// </summary>
        /// <param name="gelen">Gelen İfadesi Stringe Dönüştürülecektir.</param>
        /// <returns>float</returns>
        public static float _ToFloatR(this object gelen)
        {
            float num2;
            try
            {
                if (gelen == null) throw new Exception();
                num2 = float.Parse(gelen.ToString());
            }
            catch (Exception)
            {
                try
                {
                    if (string.IsNullOrEmpty(gelen.ToString()) || string.IsNullOrWhiteSpace(gelen.ToString())) throw new Exception();
                    num2 = float.Parse(gelen.ToString());
                }
                catch (Exception)
                {
                    num2 = 0f;
                }
            }
            return num2;
        }

        public static int? _ToInteger(this object gelen)
        {
            int? nullable;
            try
            {
                if (gelen == null) throw new Exception();
                nullable = new int?(Convert.ToInt32(gelen));
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    nullable = new int?(Convert.ToInt32(gelen));
                }
                catch (Exception)
                {
                    nullable = null;
                }
            }
            return nullable;
        }

        public static int _ToIntegerR(this object gelen)
        {
            int num2;
            try
            {
                if (gelen == null) throw new Exception();
                num2 = Convert.ToInt32(gelen);
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    num2 = Convert.ToInt32(gelen);
                }
                catch (Exception)
                {
                    num2 = 0;
                }
            }
            return num2;
        }

        public static string _ToString(this object gelen)
        {
            string str;
            try
            {
                if (gelen == null) throw new Exception();
                str = gelen.ToString();
            }
            catch (Exception)
            {
                try
                {
                    if (gelen == DBNull.Value) throw new Exception();
                    str = gelen.ToString();
                }
                catch (Exception)
                {
                    str = "";
                }
            }
            return str;
        }

        public static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            return (T)attributes[0];
        }

        public static DataTable ListToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor descriptor in properties)
                table.Columns.Add(descriptor.Name, Nullable.GetUnderlyingType(descriptor.PropertyType) ?? descriptor.PropertyType);
            foreach (T local in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor descriptor2 in properties)
                    row[descriptor2.Name] = descriptor2.GetValue(local) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;
        }

        public static void FlushMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            if (Environment.OSVersion.Platform == PlatformID.Win32NT)
                SetProcessWorkingSetSize(Process.GetCurrentProcess().Handle, -1, -1);
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

        public static string OndalikSperator { get { return CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator; } }
        public static string OndalikYanSperator { get { return CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == "." ? "," : "."; } }

      
    }
}
