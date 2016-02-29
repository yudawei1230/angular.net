using System;
using System.Web.Security;
using System.Text.RegularExpressions;

namespace WebSite.Comman
{
    public class MyConvert
    {
        /// <summary>
        /// 强制转换为Bool
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static bool GetBoolean(string value)
        {
            bool result = false;
            bool.TryParse(value, out result);
            return result;
        }

        /// <summary>
        /// 强制转换为DateTime
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static DateTime GetDateTime(string value)
        {
            DateTime now = DateTime.Now;
            return DateTime.TryParse(value, out now) ? now : DateTime.Now;            
        }

        /// <summary>
        /// 强制转换为decimal
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static decimal GetDecimal(string num)
        {
            decimal result = 0M;
            decimal.TryParse(num, out result);
            return result;
        }

        /// <summary>
        /// 强制转换为double
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static double GetDouble(string num)
        {
            double result = 0.0;
            double.TryParse(num, out result);
            return result;
        }

        /// <summary>
        /// 强制转换为float
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static float GetFloat(string num)
        {
            float result = 0f;
            float.TryParse(num, out result);
            return result;
        }

        /// <summary>
        /// 强制转换为short
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static short GetInt16(string num)
        {
            short result = 0;
            short.TryParse(num, out result);
            return result;
        }

        /// <summary>
        /// 强制转换为int
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static int GetInt32(string num)
        {
            int result = 0;
            int.TryParse(num, out result);
            return result;
        }

        /// <summary>
        /// 强制转换为long
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static long GetInt64(string num)
        {
            long result = 0L;
            long.TryParse(num, out result);
            return result;
        }

        /// <summary>
        /// 字符串转换为哈希密码，可把生成密码存储在配置文件中
        /// </summary>
        /// <param name="value">字符串</param>
        /// <returns></returns>
        public static string GetMD5(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5");
        }

        /// <summary>
        /// 转换String为Float，如果转换失败取默认值
        /// </summary>
        /// <param name="strValue">为整形的字符串</param>
        /// <param name="defValue">默认值，如：0F</param>
        /// <returns></returns>
        public static float StrToFloat(object strValue, float defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }
            float num = defValue;
            if ((strValue != null) && new Regex(@"^([-]|[0-9])[0-9]*(\.\w*)?$").IsMatch(strValue.ToString()))
            {
                num = System.Convert.ToSingle(strValue);
            }
            return num;
        }
        /// <summary>
        /// 转换String为Long，如果转换失败取默认值
        /// </summary>
        /// <param name="strValue">为整形的字符串</param>
        /// <param name="defValue">默认值，如：0L</param>
        /// <returns></returns>
        public static long StrToLong(object strValue, long defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 10))
            {
                return defValue;
            }
            long num = defValue;
            if ((strValue != null) && new Regex(@"^([-]|[0-9])[0-9]*(\.\w*)?$").IsMatch(strValue.ToString()))
            {
                num = System.Convert.ToInt64(strValue);
            }
            return num;
        }
        /// <summary>
        /// 转换String为Int，如果转换失败取默认值
        /// </summary>
        /// <param name="strValue">为整形的字符串</param>
        /// <param name="defValue">默认值，如：0</param>
        /// <returns></returns>
        public static int StrToInt(object strValue, int defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 9))
            {
                return defValue;
            }
            int num = defValue;
            if ((strValue != null) && new Regex("^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString()))
            {
                num = System.Convert.ToInt32(strValue);
            }
            return num;
        }
        /// <summary>
        /// 转换String为Int64，如果转换失败取默认值
        /// </summary>
        /// <param name="strValue">为整形的字符串</param>
        /// <param name="defValue">默认值，如：0</param>
        /// <returns></returns>
        public static long StrToInt64(object strValue, int defValue)
        {
            if ((strValue == null) || (strValue.ToString().Length > 9))
            {
                return (long)defValue;
            }
            long num = defValue;
            if ((strValue != null) && new Regex("^([-]|[0-9])[0-9]*$").IsMatch(strValue.ToString()))
            {
                num = System.Convert.ToInt64(strValue);
            }
            return num;
        }

        /// <summary>
        /// 得到价格
        /// </summary>
        /// <param name="P_Price"></param>
        /// <returns></returns>
        public static string GetMoney(string P_Price)
        {
            int index = P_Price.IndexOf(".");
            if ((index > 0) && (P_Price.Length > (index + 2)))
            {
                return P_Price.Substring(0, index + 3);
            }
            return P_Price;
        }

    }
}

