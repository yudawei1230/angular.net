using SdShop.Comman;
using System;
using System.Collections;
using System.Web;

namespace SdShop.WebPage
{


    public class PageRequest
    {
        public static int GetFormInt(string para)
        {
            int formInt = -1;
            string tempFormString = GetFormString(para);
            if (Validator.IsNumeric(tempFormString))
            {
                formInt = int.Parse(tempFormString);
            }
            return formInt;
        }

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
                if (!(((formKey.IndexOf("w_") < 0) && (formKey.IndexOf("q_") < 0)) || formValue.Equals("")))
                {
                    para.Add(formKey, formValue);
                }
            }
            return para;
        }

        public static string GetFormString(string para)
        {
            string formString = "";
            if (HttpContext.Current.Request.Form[para] != null)
            {
                formString = HttpContext.Current.Request.Form[para].ToString();
            }
            else
            {
                formString = "";
            }
            return Utils.InputTexts(formString.Trim());
        }

        public static int GetInt(string para)
        {
            string tempInt = GetString(para);
            int intReturn = -1;
            if (Validator.IsNumeric(tempInt))
            {
                intReturn = int.Parse(tempInt);
            }
            return intReturn;
        }

        public static Hashtable GetPara()
        {
            if (HttpContext.Current.Request.RequestType.ToLower().Equals("get"))
            {
                return GetQueryPara();
            }
            return GetFormPara();
        }

        public static int GetQueryInt(string para)
        {
            int queryInt = -1;
            string tempQueryString = GetQueryString(para);
            if (Validator.IsNumeric(tempQueryString))
            {
                queryInt = int.Parse(tempQueryString);
            }
            return queryInt;
        }

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
                if (!(((queryKey.IndexOf("w_") < 0) && (queryKey.IndexOf("q_") < 0)) || queryValue.Equals("")))
                {
                    para.Add(queryKey, queryValue);
                }
            }
            return para;
        }

        public static string GetQueryString(string para)
        {
            string queryString = "";
            if (HttpContext.Current.Request.QueryString[para] != null)
            {
                queryString = HttpContext.Current.Request.QueryString[para].ToString();
            }
            else
            {
                queryString = "";
            }
            return Utils.InputTexts(queryString.Trim());
        }

        public static string GetString(string para)
        {
            if (HttpContext.Current.Request.RequestType.ToLower().Equals("get"))
            {
                return GetQueryString(para);
            }
            return GetFormString(para);
        }
    }
}

