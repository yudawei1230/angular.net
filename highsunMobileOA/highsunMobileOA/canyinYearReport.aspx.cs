using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace highsunMobileOA
{
    public partial class canyinYearReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (string.IsNullOrEmpty(WebSite.Comman.CookieSession.GetCookie("LoginName")))
                {
                    Response.Redirect("login.aspx");
                }
            }
        }
    }
}