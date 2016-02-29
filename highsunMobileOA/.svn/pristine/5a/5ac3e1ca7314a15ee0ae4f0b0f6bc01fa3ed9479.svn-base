using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Net;
using System.Data;

namespace WebSite.Comman
{
    public class Utils
    {
        //*******sql注入检查*******//
        public static string Filter(string sInput)
        {
            if ((sInput == null) || (sInput == ""))
            {
                return null;
            }
            string sInput1 = sInput.ToLower();
            string output = sInput;
            string pattern = "*|and|exec|insert|select|delete|update|count|master|truncate|declare|char(|mid(|chr(|'";
            if (Regex.Match(sInput1, Regex.Escape(pattern), RegexOptions.IgnoreCase).Success)
            {
                output = output.Replace(sInput, "''");
            }
            else
            {
                output = output.Replace("'", "''");
            }
            return output;
        }

        //*******sql注入检查*******//


        //*********分页***********//

        /// <summary>
        /// 得到分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <param name="sub"></param>
        /// <returns></returns>
        /// <summary>
        /// 得到分页
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="count"></param>
        /// <param name="sub"></param>
        /// <returns></returns>
        public static string GetPager(int page, int pageSize, int count, string pageurl)
        {
            int pageLine = 10;
            int pageCount = (int)Math.Ceiling((double)count / pageSize);
            int start = ((page - 1) / pageLine) * pageLine + 1;
            StringBuilder sb = new StringBuilder();
            sb.Append("<div class=\"page\">");
            if (pageCount > 1)
            {
                if (page == 1)
                {
                    sb.Append("<p class=\"page_bg2\"></p>");
                }
                if (page > 1)
                {
                    //sb.Append("<a href=\"" + pageurl.Replace("{p}", "1") + "\" title=\"首页\" class=\"a19\">首页</a>");
                    sb.Append("<p class=\"page_bg\"><a href=\"" + pageurl.Replace("{p}", (page - 1).ToString()) + "\" title=\"第" + (page - 1).ToString() + "页\">上一页</a></p>");
                }
                sb.Append("<ul>");
                for (int i = start; i <= pageCount && i < start + pageLine; i++)
                {
                    if (i == page)
                        sb.Append("<li><a href=\"" + pageurl.Replace("{p}", i.ToString()) + "\" title=\"第" + i.ToString() + "页\"  class=\"page_a\" >" + i.ToString() + "</a></li>");
                    else
                        sb.Append("<li><a href=\"" + pageurl.Replace("{p}", i.ToString()) + "\" title=\"第" + i.ToString() + "页\" >" + i.ToString() + "</a></li>");
                }
                if (page < pageCount)
                {
                    sb.Append("</ul><p class=\"page_bg_a\"><a href=\"" + pageurl.Replace("{p}", (page + 1).ToString()) + "\" title=\"第" + (page + 1).ToString() + "页\">下一页</a></p>");
                    //sb.Append("<a href=\"" + pageurl.Replace("{p}", pageCount.ToString()) + "\" title=\"第" + pageCount.ToString() + "页(尾页)\" class=\"a19\">尾页</a>");
                }
                if (page == pageCount)
                {
                    sb.Append("</ul><p class=\"page_bg2_a\"></p>");
                }
            }
            sb.Append("</div>");
            return sb.ToString();
        }


        /// <summary>
        /// 获得分页代码
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="pageSize">每页显示多少条数据</param>
        /// <param name="count">数据总量</param>
        /// <returns>StringBuilder</returns>
        public static string GenPager(int page, int pageSize, int count, string sub)
        {
            int pageLine = 5;
            int pageCount = (int)Math.Ceiling((double)count / pageSize);
            int start = ((page - 1) / pageLine) * pageLine + 1;
            StringBuilder sb = new StringBuilder();
            sb.Append("<br><table width=\"229\" border=\"0\" align=\"center\" cellpadding=\"0\" cellspacing=\"0\" class=\"p4\" style=\"madding-top:6px;\">");
            sb.Append("                  <tr>");
            sb.Append("                     <td align=\"center\"><span class=\"font9\" >分页:" + page.ToString() + "/" + pageCount.ToString());
            if (start > 1)
            {
                sb.Append("<a href=\"javascript:" + sub + "(" + (start - 1).ToString() + ")\" title=\"第" + (start - 1).ToString() + "页\" class=\"a19\">&nbsp;&lt;&nbsp;</a>");
                sb.Append("<a href=\"javascript:" + sub + "(" + (1).ToString() + ")\" title=\"首页\" class=\"a19\">&lt;&lt;</a>");
            }
            sb.Append("&nbsp;<strong>");
            for (int i = start; i <= pageCount && i < start + pageLine; i++)
            {
                if (i == page)
                    sb.Append("<span title=\"当前第" + i.ToString() + "页\" class=\"a19\">[<font color=red>" + i.ToString() + "</font>]</span>");
                else
                    sb.Append("<a href=\"javascript:" + sub + "(" + i + ")\" title=\"第" + i.ToString() + "页\" class=\"a19\">[" + i.ToString() + "]</a>");
            }
            sb.Append("</strong>");

            if (start + pageLine < pageCount)
            {
                sb.Append("<a href=\"javascript:" + sub + "(" + (start + pageLine).ToString() + ")\" title=\"第" + (start + pageLine).ToString() + "页\" class=\"a19\">&nbsp;&gt;</a>&nbsp;");
                sb.Append("<a href=\"javascript:" + sub + "(" + pageCount.ToString() + ")\" title=\"第" + pageCount.ToString() + "页(末页)\" class=\"a19\">&gt;&gt;</a>");
            }
            sb.Append("                     </span></td>");
            sb.Append("                 </tr>");
            sb.Append("</Table>");
            return sb.ToString();
        }

        //*********分页***********//


        //*********日期和时间**********//
        public static string GetDate()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }

        public static string GetDate(string datetimestr, string replacestr)
        {
            if (datetimestr == null)
            {
                return replacestr;
            }
            if (datetimestr.Equals(""))
            {
                return replacestr;
            }
            try
            {
                datetimestr = System.Convert.ToDateTime(datetimestr).ToString("yyyy-MM-dd").Replace("1900-01-01", replacestr);
            }
            catch
            {
                return replacestr;
            }
            return datetimestr;
        }

        public static string GetDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static string GetDateTimeF()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fffffff");
        }

        public static string Gettime(string date)
        {
            if (date.ToString() != "")
            {
                return System.Convert.ToDateTime(date).ToString("yyyy-MM-dd");
            }
            return "";
        }

        public static string GetTime()
        {
            return DateTime.Now.ToString("HH:mm:ss");
        }

        public static string GetYear(DateTime begin, DateTime end)
        {
            if (end.Year == begin.Year)
            {
                if (end.Month == begin.Month)
                {
                    if ((end.Day - begin.Day) > 0)
                    {
                        return "1";
                    }
                    return "0";
                }
                if ((end.Month - begin.Month) > 0)
                {
                    return "1";
                }
                if ((end.Day - begin.Day) > 0)
                {
                    return "1";
                }
                return "0";
            }
            if ((end.Year - begin.Year) > 0)
            {
                if (end.Month == begin.Month)
                {
                    if ((end.Day - begin.Day) > 0)
                    {
                        return System.Convert.ToString((int)((end.Year - begin.Year) + 1));
                    }
                    return System.Convert.ToString((int)(end.Year - begin.Year));
                }
                if ((end.Day - begin.Day) > 0)
                {
                    return System.Convert.ToString((int)((end.Year - begin.Year) + 1));
                }
                return System.Convert.ToString((int)(end.Year - begin.Year));
            }
            return "0";
        }

        //*********日期和时间**********//


        /// <summary>
        /// 输出文件提供下载功能
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="filename"></param>
        /// <param name="filetype"></param>
        public static void ResponseFile(string filepath, string filename, string filetype)
        {
            Stream stream = null;
            byte[] buffer = new byte[0x2710];
            try
            {
                stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
                long length = stream.Length;
                HttpContext.Current.Response.ContentType = filetype;
                HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + WanInfo.UrlEncode(filename.Trim()));
                while (length > 0L)
                {
                    if (HttpContext.Current.Response.IsClientConnected)
                    {
                        int count = stream.Read(buffer, 0, 0x2710);
                        HttpContext.Current.Response.OutputStream.Write(buffer, 0, count);
                        HttpContext.Current.Response.Flush();
                        buffer = new byte[0x2710];
                        length -= count;
                    }
                    else
                    {
                        length = -1L;
                    }
                }
            }
            catch (Exception exception)
            {
                HttpContext.Current.Response.Write("Error : " + exception.Message);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
            }
            HttpContext.Current.Response.End();
        }

        //*******分割符数组处理*******//

        public static int GetInArrayID(string strSearch, string[] stringArray)
        {
            return GetInArrayID(strSearch, stringArray, true);
        }

        public static int GetInArrayID(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            for (int i = 0; i < stringArray.Length; i++)
            {
                if (caseInsensetive)
                {
                    if (strSearch.ToLower() == stringArray[i].ToLower())
                    {
                        return i;
                    }
                }
                else if (strSearch == stringArray[i])
                {
                    return i;
                }
            }
            return -1;
        }

        public static bool InArray(string str, string stringarray)
        {
            return InArray(str, StringHelper.SplitString(stringarray, ","), false);
        }

        public static bool InArray(string str, string stringarray, string strsplit)
        {
            return InArray(str, StringHelper.SplitString(stringarray, strsplit), false);
        }

        public static bool InArray(string strSearch, string[] stringArray, bool caseInsensetive)
        {
            return (GetInArrayID(strSearch, stringArray, caseInsensetive) >= 0);
        }

        public static bool InArray(string str, string stringarray, string strsplit, bool caseInsensetive)
        {
            return InArray(str, StringHelper.SplitString(stringarray, strsplit), caseInsensetive);
        }

        public static bool InIPArray(string ip, string[] iparray)
        {
            string[] strArray = StringHelper.SplitString(ip, ".");
            for (int i = 0; i < iparray.Length; i++)
            {
                string[] strArray2 = StringHelper.SplitString(iparray[i], ".");
                int num2 = 0;
                for (int j = 0; j < strArray2.Length; j++)
                {
                    if (strArray2[j] == "*")
                    {
                        return true;
                    }
                    if ((strArray.Length <= j) || (strArray2[j] != strArray[j]))
                    {
                        break;
                    }
                    num2++;
                }
                if (num2 == 4)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool InArray(string str, string[] stringarray)
        {
            return InArray(str, stringarray, false);
        }

        //*******分割符数组处理*******//

        public static string[] RepaceSpilthItem(string[] str)
        {
            ArrayList list = new ArrayList();
            foreach (string str2 in str)
            {
                if (!list.Contains(str2))
                {
                    list.Add(str2);
                }
            }
            return (string[])list.ToArray(typeof(string));
        }

        /// <summary>
        /// 将全角数字转换为数字
        /// </summary>
        /// <param name="SBCCase"></param>
        /// <returns></returns>
        public static string SBCCaseToNumberic(string SBCCase)
        {
            char[] c = SBCCase.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
                if (b.Length == 2)
                {
                    if (b[1] == 255)
                    {
                        b[0] = (byte)(b[0] + 32);
                        b[1] = 0;
                        c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
                    }
                }
            }
            return new string(c);
        }

        /// <summary>
        /// 执行DataTable中的查询返回新的DataTable
        /// </summary>
        /// <param name="dt">源数据DataTable</param>
        /// <param name="condition">查询条件</param>
        /// <returns></returns>
        public static DataTable GetNewDataTable(DataTable dt, string condition)
        {
            DataTable newdt = new DataTable();
            newdt = dt.Clone();
            DataRow[] dr = dt.Select(condition);
            for (int i = 0; i < dr.Length; i++)
            {
                newdt.ImportRow((DataRow)dr[i]);
            }
            return newdt;//返回的查询结果
        }
    }
}

