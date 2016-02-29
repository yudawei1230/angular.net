using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WebSite.Comman
{
    public class CookieSession
    {
        //********cookie操作********//
        public static void WriteCookie(string strName, string strValue)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            strValue = JSEscape(strValue);
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void WriteCookie(string strName, string strValue, int expires)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
            }
            cookie.Value = JSEscape(strValue);
            cookie.Expires = DateTime.Now.AddMonths(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void WriteCookie(string strName, string strValue, string domain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
                if (!domain.Trim().Equals(""))
                {
                    cookie.Domain = domain;
                }
            }
            strValue = JSEscape(strValue);
            cookie.Value = strValue;
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static void WriteCookie(string strName, string strValue, int expires, string domain)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie == null)
            {
                cookie = new HttpCookie(strName);
                if (!domain.Trim().Equals(""))
                {
                    cookie.Domain = domain;
                }
            }
            cookie.Value = JSEscape(strValue);
            cookie.Expires = DateTime.Now.AddMonths(expires);
            HttpContext.Current.Response.AppendCookie(cookie);
        }

        public static string GetCookie(string strName)
        {
            if ((HttpContext.Current.Request.Cookies != null) && (HttpContext.Current.Request.Cookies[strName] != null))
            {
                return JSunescape(HttpContext.Current.Request.Cookies[strName].Value.ToString());
            }
            return "";
        }

        public static void ClearCookie(string strName, string domainName)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[strName];
            if (cookie != null)
            {
                if (!domainName.Trim().Equals(""))
                {
                    cookie.Domain = domainName;
                }
                cookie.Value = null;
                cookie.Expires = DateTime.Now.AddDays(-1.0);
                cookie.Values.Clear();
                HttpContext.Current.Response.Cookies.Set(cookie);
            }
        }

        public static void SetCookies(string domain, string type, IList<Dictionary<string, string>> map)
        {
            HttpCookie cookie = new HttpCookie(type);//定义cookie对象
            DateTime dt = DateTime.Now;//定义时间对象
            TimeSpan ts = new TimeSpan(1, 0, 0, 0);//cookie有效作用时间，具体查msdn
            cookie.Expires = dt.Add(ts);//添加作用时间
            cookie.Domain = domain;
            for (int i = 0; i < map.Count; i++)
            {
                cookie.Values.Add(map[i]["key"], map[i]["value"]);//增加属性
            }
            HttpContext.Current.Response.AppendCookie(cookie);//确定写入cookie中 
        }

        public static void AppendCookies(string domain, string type, string key, string value)
        {
            HttpCookie cookie = null;
            if ((HttpContext.Current.Request.Cookies != null) && (HttpContext.Current.Request.Cookies[type] != null))
            {
                cookie = HttpContext.Current.Request.Cookies[type];
            }
            else
            {
                cookie = new HttpCookie(type);//定义cookie对象
            }
            DateTime dt = DateTime.Now;//定义时间对象
            TimeSpan ts = new TimeSpan(30, 0, 0, 0);//cookie有效作用时间，具体查msdn
            cookie.Expires = dt.Add(ts);//添加作用时间
            if (!domain.Trim().Equals(""))
            {
                cookie.Domain = domain;
            }
            cookie.Values.Add(JSunescape(key), JSunescape(value));//增加属性
            HttpContext.Current.Response.AppendCookie(cookie);//确定写入cookie中 

        }

        public static void OverWriteCookies(string domain, string type, string key, string value)
        {
            HttpCookie cookie = null;
            if ((HttpContext.Current.Request.Cookies != null) && (HttpContext.Current.Request.Cookies[type] != null))
            {
                cookie = HttpContext.Current.Request.Cookies[type];
                cookie.Values[key] += value;
            }
            else
            {
                cookie = new HttpCookie(type);
                cookie.Values.Add(key, value);
            }
            DateTime dt = DateTime.Now;//定义时间对象
            TimeSpan ts = new TimeSpan(30, 0, 0, 0);//cookie有效作用时间，具体查msdn
            cookie.Expires = dt.Add(ts);//添加作用时间
            cookie.Domain = domain;
            HttpContext.Current.Response.AppendCookie(cookie);//确定写入cookie中 
        }

        public static string GetCookies(string type, string name)
        {
            if (HttpContext.Current.Request.Cookies[type] != null)
            {
                if (HttpContext.Current.Request.Cookies[type].Values[name] != null)
                {
                    return HttpContext.Current.Request.Cookies[type].Values[name].ToString();
                }
                else
                {
                    return "0";
                }
            }
            return "0";
        }


        //********cookie操作********//


        //*******session操作********//

        public static void SetSession(string sessionName, object value)
        {
            if (HttpContext.Current.Session[sessionName] == null)
            {
                HttpContext.Current.Session.Add(sessionName, value);
            }
            else
            {
                HttpContext.Current.Session[sessionName] = value;
            }
        }

        public static string GetSession(string sessionName)
        {
            object sessionObj = GetSessionObj(sessionName);
            if (sessionObj == null)
            {
                return "";
            }
            return sessionObj.ToString();
        }

        public static object GetSessionObj(string sessionName)
        {
            return HttpContext.Current.Session[sessionName];
        }

        public static void ClearSession(string sessionName)
        {
            HttpContext.Current.Session.Remove(sessionName);
        }

        //*******session操作********//

        public static string JSEscape(string str)
        {
            return Microsoft.JScript.GlobalObject.escape(str);
        }

        public static string JSunescape(string str)
        {
            return Microsoft.JScript.GlobalObject.unescape(str);
        }
    }
}
