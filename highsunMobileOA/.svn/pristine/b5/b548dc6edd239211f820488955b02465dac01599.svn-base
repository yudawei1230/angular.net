using System;
using System.Text;
using System.Web;

namespace WebSite.WebPage
{


    public class Script
    {
        public static void Alert(string message)
        {
            ResponseScript("    alert('" + message + "');");
        }

        public static void AlertAndCloseThisOpenWindow(string message)
        {
            StringBuilder script = new StringBuilder();
            script.AppendFormat("    alert('{0}');\n", message);
            script.AppendLine("    window.opener.reload();");
            script.AppendLine("    window.close();");
            ResponseScript(script.ToString());
        }

        public static void AlertAndGoBack(string message)
        {
            StringBuilder script = new StringBuilder();
            script.AppendFormat("    alert('{0}');\n", message);
            script.AppendLine("    window.history.back();");
            ResponseScript(script.ToString());
            HttpContext.Current.Response.End();
        }

        public static void AlertAndRedirect(string message, string url)
        {
            StringBuilder script = new StringBuilder();
            script.AppendFormat("    alert('{0}');\n", message);
            script.AppendFormat("    window.location.href='{0}'\n", url);
            ResponseScript(script.ToString());
            HttpContext.Current.Response.End();
        }

        public static void AlertAndReload(string message)
        {
            StringBuilder script = new StringBuilder();
            script.AppendFormat("    alert('{0}');\n", message);
            script.AppendLine("    window.location.reload();");
            ResponseScript(script.ToString());
            HttpContext.Current.Response.End();
        }

        public static void GoBack()
        {
            ResponseScript("    window.history.back();");
            HttpContext.Current.Response.End();
        }

        public static void ParentPageRedirect(string url)
        {
            ResponseScript("    parent.location.href='" + url + "';");
            HttpContext.Current.Response.End();
        }

        public static void Redirect(string url)
        {
            HttpContext.Current.Response.Redirect(url);
        }

        public static void ResponseScript(string script)
        {
            HttpContext.Current.Response.Write("<script language=\"javascript\" type=\"text/javascript\" defer>\n" + script + "\n</script>\n");
        }
    }
}

