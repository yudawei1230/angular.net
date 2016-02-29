using System;
using System.Text.RegularExpressions;

namespace WebSite.Comman
{
    public class Validator
    {
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$");
        private static Regex RegEmail = new Regex(@"^[\w-]+@[\w-]+\.(com|net|org|edu|mil|tv|biz|info)$");
        private static Regex RegMobilePhone = new Regex("^(13[0-9]|15[0|3|6|7|8|9]|18[8|9])\\d{8}$");
        private static Regex RegMoney = new Regex("^[0-9]+|[0-9]+[.]?[0-9]+$");
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegSend = new Regex("[0-9]{1}([0-9]+){5}");
        private static Regex RegTell = new Regex(@"\d{3}-\d{8}|\d{4}-\d{7}|\d{8}|\d{7}");
        private static Regex RegUrl = new Regex(@"^[a-zA-z]+://(\w+(-\w+)*)(\.(\w+(-\w+)*))*(\?\S*)?|[a-zA-z]+://((?:(?:25[0-5]|2[0-4]\d|[01]?\d?\d)\.){3}(?:25[0-5]|2[0-4]\d|[01]?\d?\d))$");
        private static Regex RegIp = new Regex(@"^(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5]).(0|[1-9]\d?|[0-1]\d{2}|2[0-4]\d|25[0-5])$");
        private static Regex RegZipCode = new Regex(@"^[1-9]\d{5}$");
        private static Regex RegQQ = new Regex(@"^[1-9]\d{4,10}$");
        private static Regex RegUser = new Regex(@"^([\u4e00-\u9fa5]|[\ufe30-\uffa0]|[a-zA-Z0-9_])*$");
        public static bool IsDateTime(string inputData)
        {
            try
            {
                Convert.ToDateTime(inputData);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDecimal(string inputData)
        {
            return RegDecimal.Match(inputData).Success;
        }

        public static bool IsUser(string inputData)
        {
            return RegUser.Match(inputData).Success;
        }

        public static bool IsDecimalSign(string inputData)
        {
            return RegDecimalSign.Match(inputData).Success;
        }

        public static bool IsEmail(string inputData)
        {
            return RegEmail.Match(inputData).Success;
        }

        public static bool IsMobilePhone(string inputDate)
        {
            return RegMobilePhone.Match(inputDate).Success;
        }

        public static bool IsMoney(string inputDate)
        {
            return RegMoney.Match(inputDate).Success;
        }

        public static bool IsNumber(string inputData)
        {
            return (!string.IsNullOrEmpty(inputData) && RegNumber.Match(inputData).Success);
        }

        public static bool IsNumberSign(string inputData)
        {
            return RegNumberSign.Match(inputData).Success;
        }

        public static bool IsPhone(string inputDate)
        {
            return (!string.IsNullOrEmpty(inputDate) && RegTell.Match(inputDate).Success);
        }

        public static bool IsSend(string inputDate)
        {
            return (!string.IsNullOrEmpty(inputDate) && RegSend.Match(inputDate).Success);
        }

        public static bool IsUrl(string inputDate)
        {
            return RegUrl.Match(inputDate).Success;
        }

        public static bool IsQQ(string inputDate)
        {
            return RegQQ.Match(inputDate).Success;
        }

        public static bool IsZipCode(string inputDate)
        {
            return RegZipCode.Match(inputDate).Success;
        }
    }
}

