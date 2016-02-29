using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace WebSite.Comman
{
    public class SiteUser
    {

        public SiteUser()
        {

        }

        // 添加自定义的值，然后导航到来到此页面之前的位置
        /// <summary>
        /// login
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userData">自定义数据(string),可空</param>
        public static void SetUserDataAndRedirect(string userName, string userData, string domain)
        {
            // 获得Cookie
            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(userName, false);

            // 得到ticket凭据
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            // 根据之前的ticket凭据创建新ticket凭据，然后加入自定义信息
            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(
                ticket.Version, ticket.Name, ticket.IssueDate,
                ticket.Expiration, ticket.IsPersistent, userData);

            // 将新的Ticke转变为Cookie值，然后添加到Cookies集合中
            authCookie.Value = FormsAuthentication.Encrypt(newTicket);
            HttpContext.Current.Response.Cookies.Add(authCookie);


            //获得 来到登录页之前的页面，即url中return参数的值
            if (!string.IsNullOrEmpty(SRequest.GetQueryString("ReturnUrl")))
            {
                //string url = FormsAuthentication.GetRedirectUrl(userName, false);
                HttpContext.Current.Response.Redirect(WanInfo.UrlDecode(SRequest.GetQueryString("ReturnUrl")));
            }
            else
            {
                HttpContext.Current.Response.Redirect("~/Member/UserMains.aspx");
            }
        }

        // 添加自定义的值，然后导航到来到此页面之前的位置
        /// <summary>
        /// login
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="userData">自定义数据(string),可空</param>
        public static void SetUserData(string userName, string userData, bool admin)
        {
            // 获得Cookie
            HttpCookie authCookie = FormsAuthentication.GetAuthCookie(userName, false);

            // 得到ticket凭据
            FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(authCookie.Value);

            // 根据之前的ticket凭据创建新ticket凭据，然后加入自定义信息
            FormsAuthenticationTicket newTicket = new FormsAuthenticationTicket(
                ticket.Version, ticket.Name, ticket.IssueDate,
                ticket.Expiration, ticket.IsPersistent, userData);

            // 将新的Ticke转变为Cookie值，然后添加到Cookies集合中
            authCookie.Value = FormsAuthentication.Encrypt(newTicket);
            HttpContext.Current.Response.Cookies.Add(authCookie);
            if (admin)
                HttpContext.Current.Response.Redirect("/Control/index.html");
            else
                HttpContext.Current.Response.Redirect("/UserControl/index.html");
        }
    }
}