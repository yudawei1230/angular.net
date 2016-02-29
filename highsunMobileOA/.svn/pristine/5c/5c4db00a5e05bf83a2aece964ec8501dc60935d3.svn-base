using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace WebSite.BLL.Base
{
    public class CheckLoginState : System.Web.UI.Page
    {
        protected CheckLoginState()
        {
            InitUser();
        }
        private static string CurrentUser = WebSite.Comman.CookieSession.GetCookie("memberPhone");
        /// <summary>
        /// 如果用户未登录将返回登录页面
        /// </summary>
        public void InitUser()
        {
            if (string.IsNullOrEmpty(CurrentUser))
            {
                System.Web.HttpContext.Current.Response.Redirect("/login.html?returnUrl=" + System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
            }
        }
        public static WebSite.Models.Member CurUser
        {
            get
            {
                return new WebSite.BLL.PublicHandler().MemberByPhone(CurrentUser);
            }
        }
    }
}
