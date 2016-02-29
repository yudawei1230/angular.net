using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;
using System.IO;
using System.Net;
using System.Text;

namespace WebSite.Comman
{


    public class WanInfo
    {
        public static string GetAppPath()
        {
            if (HttpContext.Current.Request.ApplicationPath == "/")
            {
                return string.Empty;
            }
            return HttpContext.Current.Request.ApplicationPath;
        }

        public static string GetDataTablePrefix()
        {
            return ConfigurationSettings.AppSettings["DataTablePrefix"].Trim();
        }

        public static string GetRootPath()
        {
            string appPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            if (HttpCurrent != null)
            {
                return HttpCurrent.Server.MapPath("~");
            }
            appPath = AppDomain.CurrentDomain.BaseDirectory;
            if (Regex.Match(appPath, @"\\$", RegexOptions.Compiled).Success)
            {
                appPath = appPath.Substring(0, appPath.Length - 1);
            }
            return appPath;
        }

        public static string GetRootURI()
        {
            string appPath = "";
            HttpContext HttpCurrent = HttpContext.Current;
            if (HttpCurrent == null)
            {
                return appPath;
            }
            HttpRequest Req = HttpCurrent.Request;
            string UrlAuthority = Req.Url.GetLeftPart(UriPartial.Authority);
            if ((Req.ApplicationPath == null) || (Req.ApplicationPath == "/"))
            {
                return UrlAuthority;
            }
            return (UrlAuthority + Req.ApplicationPath);
        }

        public static string GetServerPath()
        {
            return HttpContext.Current.Request.ServerVariables["APPL_PHYSICAL_PATH"];
        }


        /// <summary>
        /// 发送POST请求,返回值
        /// </summary>
        /// <param name="sUrl">地址</param>
        /// <param name="postData">发送数据</param>
        /// <returns></returns>
        public static string SendPost(string sUrl, string postData)
        {
            return SendPost(sUrl, postData, "utf-8");
        }

        public static string SendPost(string sUrl, string postData, string code)
        {
            string sHtml = "";
            HttpWebRequest request;
            HttpWebResponse response = null;
            Stream stream = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(sUrl);
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";
                Encoding encoding = Encoding.GetEncoding(code);
                byte[] data = encoding.GetBytes(postData);
                request.ContentLength = data.Length;
                Stream _stream = request.GetRequestStream();
                _stream.Write(data, 0, data.Length);
                response = (HttpWebResponse)request.GetResponse();
                stream = response.GetResponseStream();
                sHtml = new StreamReader(stream, encoding).ReadToEnd();
            }
            catch (Exception e)
            {
                string aa = e.Message;
                if (response != null) response.Close();
            }
            if (stream != null) stream.Close();
            if (response != null) response.Close();
            return sHtml;
        }


        /// <summary>
        /// 根据Url获得源文件内容
        /// </summary>
        /// <param name="url">合法的Url地址</param>
        /// <returns></returns>
        public static string GetSourceTextByUrl(string url)
        {
            WebRequest request = WebRequest.Create(url);
            request.Timeout = 20000;//20秒超时
            WebResponse response = request.GetResponse();

            Stream resStream = response.GetResponseStream();
            StreamReader sr = new StreamReader(resStream);
            return sr.ReadToEnd();
        }

        /// <summary>
        /// 得到指定URL html代码
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHtmlString(string url)
        {
            string str = "";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 2.0.50727; .NET CLR 2.0.50727)";
            request.Accept = "*/*";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Encoding encoding = Encoding.Default;
            StreamReader reader = new StreamReader(response.GetResponseStream(), encoding);
            str = reader.ReadToEnd();
            response.Close();
            reader.Close();
            return str;
        }


        public static string GetEmailHostName(string strEmail)
        {
            if (strEmail.IndexOf("@") < 0)
            {
                return "";
            }
            return strEmail.Substring(strEmail.LastIndexOf("@")).ToLower();
        }

        /// <summary>
        /// 得到当前ip
        /// </summary>
        /// <returns></returns>
        public static string GetRealIP()
        {
            return GetIP();
        }

        public static string GetIP()
        {
            string str2;
            string userHostAddress = string.Empty;
            userHostAddress = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (((str2 = userHostAddress) == null) || (str2 == ""))
            {
                userHostAddress = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }
            if ((userHostAddress == null) || (userHostAddress == string.Empty))
            {
                userHostAddress = HttpContext.Current.Request.UserHostAddress;
            }
            if ((userHostAddress != null) && !(userHostAddress == string.Empty))
            {
                return userHostAddress;
            }
            return "0.0.0.0";
        }

        public static string GetTrueForumPath()
        {
            string path = HttpContext.Current.Request.Path;
            if (path.LastIndexOf("/") != path.IndexOf("/"))
            {
                return path.Substring(path.IndexOf("/"), path.LastIndexOf("/") + 1);
            }
            return "/";
        }

        /// <summary>
        /// 得到主机头
        /// </summary>
        /// <returns>网站的域名</returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        public static string UrlDecode(string str)
        {
            return HttpUtility.UrlDecode(str);
        }

        public static string UrlEncode(string str)
        {
            return HttpUtility.UrlEncode(str);
        }
    }
}

