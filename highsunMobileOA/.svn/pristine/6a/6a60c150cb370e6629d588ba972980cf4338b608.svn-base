using System;
using System.Configuration;
using System.IO;
using System.Web;
using System.Xml;
using System.Reflection;
using System.Web.SessionState;
using System.Web.Caching;
using System.Text;
/// <summary>
///ImageAshxPageHandler 的摘要说明
/// </summary>
public sealed class CommonAshxPageHandler : IHttpHandler, IRequiresSessionState
{
    #region IHttpHandler 成员

    public bool IsReusable
    {
        get { return true; }
    }

    public void ProcessRequest(HttpContext context)
    {
        HttpRequest request = HttpContext.Current.Request;
        string path = request.Url.AbsolutePath.ToLower();
        string page = new FileInfo(path).Name;
        switch (page)
        {
            //图片读取，用于跳转到目标图片，兼容页面路径
            case "imageget.ashx":
                string queryString = context.Server.UrlDecode(request.QueryString.ToString());
                if (!string.IsNullOrEmpty(queryString))
                {
                    if (queryString.StartsWith("/"))
                    {
                        queryString = "~" + queryString;
                    }
                    context.Response.Redirect(queryString);
                }
                break;

        }
    }

    #endregion
}
