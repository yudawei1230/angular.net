using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WebSite.BLL
{
    public class VerifyCode
    {
        /// <summary>
        /// 检查验证码是否正确
        /// </summary>
        /// <param name="verifyCode"></param>
        /// <returns></returns>
        public bool CheckVerifyCode(string verifyCode)
        {
            HttpContext Context = HttpContext.Current;
            try
            {
                if (string.Compare((string)Context.Session["ValiDate"], verifyCode, false) == 0)
                {
                    Context.Session.Remove("ValiDate");
                    return true;
                }
                Context.Session.Remove("ValiDate");
                return false;
            }
            catch
            {
                Context.Session.Remove("ValiDate");
                return false;
            }
        }

        public bool CheckVerifyCode(string verifyCode, string version)
        {
            HttpContext Context = HttpContext.Current;
            try
            {
                if (string.Compare((string)Context.Session["ValiDate" + version], verifyCode, false) == 0)
                {
                    Context.Session.Remove("ValiDate" + version);
                    return true;
                }
                Context.Session.Remove("ValiDate" + version);
                return false;
            }
            catch
            {
                Context.Session.Remove("ValiDate");
                return false;
            }
        }
        //FormsAuthentication.SignOut();
    }
}
