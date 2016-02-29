using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WebSite.BLL
{
    public class BasePage : AdminBase
    {
        protected BasePage()
        {
            InitUser();
        }

        /// <summary>
        /// 如果用户未登录将返回登录页面
        /// </summary>
        public void InitUser()
        {
            if (!System.Web.HttpContext.Current.User.Identity.IsAuthenticated)
            {
                HttpContext.Current.Response.Redirect("/Login.aspx");
            }
        }       
    }
}
