using System;
using System.Web;
using System.Collections;

namespace WebSite.Comman
{
    public class SRequest
    {

        #region  获取input值，如果获取失败取url值

        /// <summary>
        /// 获取input传送的值，如果获取失败取URL传送的值
        /// </summary>
        /// <param name="strName">参数名</param>
        /// <returns></returns>
        public static string GetString(string strName)
        {
            if (GetQueryString(strName).Equals(string.Empty))
            {
                return GetFormString(strName);
            }
            return GetQueryString(strName);
        }

        /// <summary>
        /// 获取input传送的Float型值，如果获取失败取URL传送的值
        /// </summary>
        /// <param name="strName">参数名</param>
        /// <param name="defValue">默认值</param>
        /// <returns></returns>
        public static float GetFloat(string strName, float defValue)
        {
            if (GetQueryFloat(strName, defValue) == defValue)
            {
                return GetFormFloat(strName, defValue);
            }
            return GetQueryFloat(strName, defValue);
        }
        

        /// <summary>
        /// 获取input传送的Int型值，如果获取失败取URL传送的值
        /// </summary>
        /// <param name="strName">参数名</param>
        /// <param name="defValue">默认值</param>
        /// <returns></returns>
        public static int GetInt(string strName, int defValue)
        {
            if (GetQueryInt(strName, defValue) == defValue)
            {
                return GetFormInt(strName, defValue);
            }
            return GetQueryInt(strName, defValue);
        }

        /// <summary>
        /// 获取参数哈希集合，如果URL为空则取input的名称与值
        /// </summary>
        /// <returns></returns>
        public static Hashtable GetPara()
        {
            if (HttpContext.Current.Request.RequestType.ToLower().Equals("get"))
            {
                return GetQueryPara();
            }
            return GetFormPara();
        }

        /// <summary>
        /// 获取URL中以w_、q_、_Serch、for_为前缀的参数名与参数值哈希集合
        /// </summary>
        /// <returns></returns>
        public static Hashtable GetQueryPara()
        {
            int paraCount = HttpContext.Current.Request.QueryString.Count;
            string queryKey = "";
            string queryValue = "";
            Hashtable para = new Hashtable();
            for (int i = 0; i < paraCount; i++)
            {
                queryKey = HttpContext.Current.Request.QueryString.Keys[i].ToString();
                queryValue = HttpContext.Current.Request.QueryString[i].ToString();
                if (!(((queryKey.IndexOf("w_") < 0) && (queryKey.IndexOf("q_") < 0) && (queryKey.IndexOf("_Serch") < 0) && (queryKey.IndexOf("for_") < 0))) || queryValue.Equals(""))
                {
                    para.Add(queryKey, queryValue);
                }
            }
            return para;
        }

        /// <summary>
        /// 获取input中以w_、q_、_Serch、for_为前缀的名称与值哈希集合
        /// </summary>
        public static Hashtable GetFormPara()
        {
            int paraCount = HttpContext.Current.Request.Form.Count;
            string formKey = "";
            string formValue = "";
            Hashtable para = new Hashtable();
            for (int i = 0; i < paraCount; i++)
            {
                formKey = HttpContext.Current.Request.Form.Keys[i].ToString();
                formValue = HttpContext.Current.Request.Form[i].ToString();
                if (!(((formKey.IndexOf("w_") < 0) && (formKey.IndexOf("q_") < 0) && (formKey.IndexOf("_Serch") < 0) && (formKey.IndexOf("for_") < 0)) || formValue.Equals("")))
                {
                    para.Add(formKey, formValue);
                }
            }
            return para;
        }

        #endregion  获取input值，如果获取失败取url值

        #region  获取post参数值

        /// <summary>
        /// 以post方式，根据form表单中input控件name名称得到值
        /// </summary>
        /// <param name="strName">form表单中input控件name名称</param>
        /// <returns></returns>
        public static string GetFormString(string strName)
        {
            if (HttpContext.Current.Request.Form[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.Form[strName];
        }

        /// <summary>
        /// 以post方式，根据form表单中input控件name名称得到值并转换为Float类型，如果转换失败取默认值
        /// </summary>
        /// <param name="strName">form表单中input控件name名称</param>
        /// <param name="defValue">默认值</param>
        /// <returns></returns>
        public static float GetFormFloat(string strName, float defValue)
        {
            return MyConvert.StrToFloat(HttpContext.Current.Request.Form[strName], defValue);
        }

        /// <summary>
        /// 以post方式，根据form表单中input控件name名称得到值并转换为Int类型，如果转换失败取默认值
        /// </summary>
        /// <param name="strName">form表单中input控件name名称</param>
        /// <param name="defValue">默认值</param>
        /// <returns></returns>
        public static int GetFormInt(string strName, int defValue)
        {
            return MyConvert.StrToInt(HttpContext.Current.Request.Form[strName], defValue);
        }

        #endregion  获取post参数值

        #region  获取get参数值

        /// <summary>
        /// 以get方式，根据Url链接中的参数名得到值
        /// </summary>
        /// <param name="strName">Url链接中的参数名称</param>
        /// <returns></returns>
        public static string GetQueryString(string strName)
        {
            if (HttpContext.Current.Request.QueryString[strName] == null)
            {
                return string.Empty;
            }
            return HttpContext.Current.Request.QueryString[strName].ToString().Trim();
        }

        /// <summary>
        /// 以get方式，根据Url链接中的参数名得到值并转换为Float类型，如果转换失败取默认值
        /// </summary>
        /// <param name="strName">Url链接中的参数名称</param>
        /// <param name="defValue">默认值，如：0F</param>
        /// <returns></returns>
        public static float GetQueryFloat(string strName, float defValue)
        {
            return MyConvert.StrToFloat(HttpContext.Current.Request.QueryString[strName], defValue);
        }

        /// <summary>
        /// 以get方式，根据Url链接中的参数名得到值并转换为Int类型，如果转换失败取默认值
        /// </summary>
        /// <param name="strName">Url链接中的参数名称</param>
        /// <param name="defValue">默认值，如：0</param>
        /// <returns></returns>
        public static int GetQueryInt(string strName, int defValue)
        {
            return MyConvert.StrToInt(HttpContext.Current.Request.QueryString[strName], defValue);
        }

        /// <summary>
        /// 以get方式，根据Url链接中的参数名得到值并转换为Int64类型，如果转换失败取默认值
        /// </summary>
        /// <param name="strName">Url链接中的参数名称</param>
        /// <param name="defValue">默认值，如：0</param>
        /// <returns></returns>
        public static long GetQueryInt64(string strName, int defValue)
        {
            return MyConvert.StrToInt64(HttpContext.Current.Request.QueryString[strName], defValue);
        }

        #endregion  获取get参数值

        #region  返回URL路径各部分信息
        /// <summary>
        /// 如：http://www.test.com/default.aspx?id=1结果是/default.aspx?id=1
        /// </summary>
        /// <returns></returns>
        public static string GetRawUrl()
        {
            return HttpContext.Current.Request.RawUrl;
        }

        /// <summary>
        /// 如：http://www.test.com/default.aspx?id=1结果是default.aspx
        /// </summary>
        /// <returns></returns>
        public static string GetPageName()
        {
            string[] strArray = HttpContext.Current.Request.Url.AbsolutePath.Split(new char[] { '/' });
            return strArray[strArray.Length - 1].ToLower();
        }

        /// <summary>
        /// 如：http://www.test.com/default.aspx?id=1结果是http://www.test.com/default.aspx?id=1
        /// </summary>
        /// <returns></returns>
        public static string GetUrl()
        {
            return HttpContext.Current.Request.Url.ToString();
        }

        /// <summary>
        /// 如：http://www.test.com/default.aspx?id=1结果是http://www.test.com/default.aspx
        /// </summary>
        /// <returns></returns>
        public static string GetUrlReferrer()
        {
            if (HttpContext.Current.Request.UrlReferrer == null)
            {
                return "";
            }
            return HttpContext.Current.Request.UrlReferrer.ToString().Trim();
        }

        /// <summary>
        /// 如：http://www.test.com/default.aspx?id=1结果是www.test.com
        /// </summary>
        /// <returns></returns>
        public static string GetHost()
        {
            return HttpContext.Current.Request.Url.Host;
        }

        #endregion  返回URL路径各部分信息

        /// <summary>
        /// 检索预定的环境变量
        /// </summary>
        /// <param name="strName">一些变量值，如当前用户IP：REMOTE_ADDR</param>
        /// <returns></returns>
        public static string GetServerString(string strName)
        {
            if (HttpContext.Current.Request.ServerVariables[strName] == null)
            {
                return "";
            }
            return HttpContext.Current.Request.ServerVariables[strName].ToString();
        }        

        /// <summary>
        /// 获取用户浏览器如果是ie,opera,netscape,mozilla则为真，否则为假
        /// </summary>
        /// <returns></returns>
        public static bool IsBrowserGet()
        {
            string[] strArray = new string[] { "ie", "opera", "netscape", "mozilla" };
            string str = HttpContext.Current.Request.Browser.Type.ToLower();
            for (int i = 0; i < strArray.Length; i++)
            {
                if (str.IndexOf(strArray[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 是否为GET方式传送
        /// </summary>
        /// <returns></returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("GET");
        }

        /// <summary>
        /// 是否为POST方式传送
        /// </summary>
        /// <returns></returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod.Equals("POST");
        }

        /// <summary>
        /// 获取用户是否从搜索引擎搜的本站点
        /// </summary>
        /// <returns></returns>
        public static bool IsSearchEnginesGet()
        {
            string[] strArray = new string[] { "google", "yahoo", "msn", "baidu", "sogou", "sohu", "sina", "163", "lycos", "tom" };
            string str = HttpContext.Current.Request.UrlReferrer.ToString().ToLower();
            for (int i = 0; i < strArray.Length; i++)
            {
                if (str.IndexOf(strArray[i]) >= 0)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 保存上传文件
        /// </summary>
        /// <param name="path"></param>
        public static void SaveRequestFile(string path)
        {
            if (HttpContext.Current.Request.Files.Count > 0)
            {
                HttpContext.Current.Request.Files[0].SaveAs(path);
            }
        }

        /// <summary>
        /// 返回当前页面是否是跨站提交
        /// </summary>
        /// <returns>当前页面是否是跨站提交</returns>
        public static bool IsCrossSitePost()
        {

            // 如果不是提交则为true
            if (!IsPost())
            {
                return true;
            }
            return IsCrossSitePost(GetUrlReferrer(), GetHost());
        }

        /// <summary>
        /// 判断是否是跨站提交
        /// </summary>
        /// <param name="urlReferrer">上个页面地址</param>
        /// <param name="host">论坛url</param>
        /// <returns>bool</returns>
        public static bool IsCrossSitePost(string urlReferrer, string host)
        {
            if (urlReferrer.Length < 7)
            {
                return true;
            }
            // 移除http://
            //			string tmpReferrer = urlReferrer.Remove(0, 7);
            //			if (tmpReferrer.IndexOf(":") > -1)
            //				tmpReferrer = tmpReferrer.Substring(0, tmpReferrer.IndexOf(":"));
            //			else
            //				tmpReferrer = tmpReferrer.Substring(0, tmpReferrer.IndexOf('/'));

            Uri u = new Uri(urlReferrer);
            return u.Host != host;
        }
    }
}

