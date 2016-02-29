using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace WebSite.Comman
{
   public  class StringHelper
    {
        /// <summary>
        /// 把数组转换为字符,以逗号分开
        /// </summary>
        /// <param name="strs"></param>
        /// <returns></returns>
        public static string ArrayToString(string[] strs)
        {
            string str = "";
            foreach (string str2 in strs)
            {
                str = str + "," + str2;
            }
            return str.Substring(1);
        }

        /// <summary>
        /// 删除最后结尾的指定字符后的字符
        /// </summary>
        public static string DelLastChar(string str, char lastChar)
        {
            return str.Substring(0, str.LastIndexOf(lastChar));
        }

       /// <summary>
       /// 简单文本过滤sql
       /// </summary>
       /// <param name="str">处理文本</param>
       /// <returns>处理后的文本</returns>
        public static string ChkSQL(string str)
        {
            if (str == null)
            {
                return "";
            }
            str = str.Replace("'", "''");
            return str;
        }

        public static string CleanInput(string strIn)
        {
            return Regex.Replace(strIn.Trim(), @"[^\w\.@-]", "");
        }

        public static string ClearBR(string str)
        {
            Regex regex = null;
            Match match = null;
            regex = new Regex(@"(\r\n)", RegexOptions.IgnoreCase);
            for (match = regex.Match(str); match.Success; match = match.NextMatch())
            {
                str = str.Replace(match.Groups[0].ToString(), "");
            }
            return str;
        }

       /// <summary>
       /// 删除字符串的html标记 如<h1></h1>
       /// </summary>
       /// <param name="strHtml">处理的字符串</param>
       /// <returns></returns>
        public static string ClearHtml(string strHtml)
        {
            if (strHtml != "")
            {
                Regex regex = null;
                Match match = null;
                regex = new Regex(@"<\/?[^>]*>", RegexOptions.IgnoreCase);
                for (match = regex.Match(strHtml); match.Success; match = match.NextMatch())
                {
                    strHtml = strHtml.Replace(match.Groups[0].ToString(), "");
                }
            }
            return strHtml;
        }

       /// <summary>
       /// 字符串截取
       /// </summary>
        /// <param name="str">字符串</param>
       /// <param name="startIndex">开始的位置</param>
       /// <returns></returns>
        public static string CutString(string str, int startIndex)
        {
            return CutString(str, startIndex, str.Length);
        }

        /// <summary>
        /// 字符串截取
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="startIndex">开始的位置</param>
        /// <param name="length">截取的长度</param>
        /// <returns></returns>
        public static string CutString(string str, int startIndex, int length)
        {
            if (startIndex >= 0)
            {
                if (length < 0)
                {
                    length *= -1;
                    if ((startIndex - length) < 0)
                    {
                        length = startIndex;
                        startIndex = 0;
                    }
                    else
                    {
                        startIndex -= length;
                    }
                }
                if (startIndex > str.Length)
                {
                    return "";
                }
            }
            else if ((length >= 0) && ((length + startIndex) > 0))
            {
                length += startIndex;
                startIndex = 0;
            }
            else
            {
                return "";
            }
            if ((str.Length - startIndex) < length)
            {
                length = str.Length - startIndex;
            }
            return str.Substring(startIndex, length);
        }

        public static int GetStringLength(string str)
        {
            return Encoding.Default.GetBytes(str).Length;
        }

        public static bool IsBase64String(string str)
        {
            return Regex.IsMatch(str, @"[A-Za-z0-9\+\/\=]");
        }

        public static bool IsFloat(string strNumber)
        {
            return new Regex(@"^\d+\.{0,1}\d*$").IsMatch(strNumber);
        }

        public static bool IsIncludeChineseCode(string testString)
        {
            return Regex.IsMatch(testString, @"[\u4e00-\u9fa5]+");
        }

        public static bool IsIP(string ip)
        {
            return new Regex(@"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$").IsMatch(ip);
        }

        


        public static bool IsNumber(string strNumber)
        {
            return new Regex(@"^\d+$").IsMatch(strNumber);
        }

        public static bool IsNumberArray(string[] strNumber)
        {
            if (strNumber == null)
            {
                return false;
            }
            if (strNumber.Length < 1)
            {
                return false;
            }
            foreach (string str in strNumber)
            {
                if (!IsNumber(str))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 合并字符
        /// </summary>
        /// <param name="source">要合并的源字符串</param>
        /// <param name="target">要被合并到的目的字符串</param>
        /// <param name="mergechar">合并符</param>
        /// <returns>并到字符串</returns>
        public static string MergeString(string source, string target, string mergechar)
        {
            if (StrIsNullOrEmpty(target))
                target = source;
            else
                target += mergechar + source;

            return target;
        }

        public static bool IsUTF8(FileStream sbInputStream)
        {
            bool flag = true;
            long length = sbInputStream.Length;
            byte num2 = 0;
            for (int i = 0; i < length; i++)
            {
                byte num4 = (byte)sbInputStream.ReadByte();
                if ((num4 & 0x80) != 0)
                {
                    flag = false;
                }
                if (num2 == 0)
                {
                    if (num4 >= 0x80)
                    {
                        do
                        {
                            num4 = (byte)(num4 << 1);
                            num2 = (byte)(num2 + 1);
                        }
                        while ((num4 & 0x80) != 0);
                        num2 = (byte)(num2 - 1);
                        if (num2 == 0)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    if ((num4 & 0xc0) != 0x80)
                    {
                        return false;
                    }
                    num2 = (byte)(num2 - 1);
                }
            }
            if (num2 > 0)
            {
                return false;
            }
            if (flag)
            {
                return false;
            }
            return true;
        }


        /// <summary>
        /// 字段串是否为Null或为""(空)
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool StrIsNullOrEmpty(string str)
        {
            if (str == null || str.Trim() == string.Empty || str.Trim() == "")
                return true;

            return false;
        } 

        public static bool IsSafeSqlString(string str)
        {
            return !Regex.IsMatch(str, @"[-|;|,|\/|\(|\)|\[|\]|\}|\{|%|@|\*|!|\']");
        }

        public static bool IsTime(string timeval)
        {
            return Regex.IsMatch(timeval, "^((([0-1]?[0-9])|(2[0-3])):([0-5]?[0-9])(:[0-5]?[0-9])?)$");
        }

        public static string[] SplitString(string strContent, string strSplit)
        {
            if (strContent.IndexOf(strSplit) < 0)
            {
                return new string[] { strContent };
            }
            return Regex.Split(strContent, strSplit.Replace(".", @"\."), RegexOptions.IgnoreCase);
        }
       /// <summary>
        /// 新闻标题过长加...
       /// </summary>
       /// <param name="text">字符</param>
       /// <param name="maxLength">个数</param>
       /// <param name="Ellipsis">true为加...</param>
       /// <returns></returns>
        public static string subText(string text, int maxLength, bool Ellipsis)
        {
            text = text.Trim();
            if (string.IsNullOrEmpty(text))
                return string.Empty;
            if (maxLength > 0)
            {
                if (text.Length > maxLength)
                {
                    Regex regex = new Regex("<.+?>|&nbsp;|&ldquo;|&rdquo;|(file://r//n)|//s", RegexOptions.IgnoreCase);
                    text = regex.Replace(text, "");
                    text = text.Substring(0, maxLength);
                    text += Ellipsis ? "..." : string.Empty;
                }
            }
            return text;
        }
       /// <summary>
        /// TxtBox内的文字输出换行
       /// </summary>
       /// <param name="str"></param>
       /// <returns></returns>
        public static string TxtBoxBr(string str)
        {
            return str.Replace("\r\n", "<br>");
        }

        public static string subName(string name)
        {
            if (string.IsNullOrEmpty(name))
                return string.Empty;
            if (name.Length < 3)
            {
                name = name.Substring(0, 1);
                name += "*";
            }
            if (name.Length > 2)
            {
                name = name.Substring(0, 1);
                name += "**";
            }
            return name;
        }
    }
}
