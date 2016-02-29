using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.SessionState;

namespace highsunMobileOA.json
{
    /// <summary>
    /// PublicExtendHandler 的摘要说明
    /// </summary>
    public class PublicExtendHandler : IHttpHandler, IRequiresSessionState
    {
        HttpRequest Request;
        HttpResponse Response;
        HttpSessionState Session;
        HttpServerUtility Server;
        public void ProcessRequest(HttpContext context)
        {
            //不让浏览器缓存
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
            context.Response.AddHeader("pragma", "no-cache");
            context.Response.AddHeader("cache-control", "");
            context.Response.CacheControl = "no-cache";
            context.Response.ContentType = "text/plain";

            Request = context.Request;
            Response = context.Response;
            Session = context.Session;
            Server = context.Server;

            string method = Request["Method"];
            MethodInfo methodInfo = this.GetType().GetMethod(method);
            methodInfo.Invoke(this, null);
        }

        public void SearchWage()
        {
            string name = Request["name"];
            string year = Request["year"];
            string month = Request["month"];
            bool search = Convert.ToBoolean(Request["search"]);
            string str = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadSalaryByMonth("VYbSBDuFOPVd3452222", name, year, month);

            if (!search && string.IsNullOrEmpty(str))
            {
                DateTime d1 = DateTime.Now.AddMonths(-1);
                str = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadSalaryByMonth("VYbSBDuFOPVd3452222", name, d1.Year.ToString(), d1.Month.ToString());
                if (string.IsNullOrEmpty(str))
                {
                    DateTime d2 = DateTime.Now.AddMonths(-2);
                    str = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadSalaryByMonth("VYbSBDuFOPVd3452222", name, d2.Year.ToString(), d2.Month.ToString());
                }
            }
            Response.Write(str);
            Response.End();
        }

      

        /// <summary>
        /// Name,BrushCardTime,Balance,Charge4 （用户姓名、刷卡日期，消费金额，剩余金额）
        /// </summary>
        public void BuyLog()
        {
            string name = Request["name"];
            result rlt = new result();

            DataTable dt = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadPersonConsume("VYbSBDuFOPVd3452222", name);
            if (dt.Rows.Count != 0)
            {
                rlt.success = true;
                rlt.msg += "<div class=\"ui-block-a treven\" style='width:60%;'><span>刷卡日期</span></div>";
                rlt.msg += "<div class=\"ui-block-b treven\" style='width:40%;'><span>消费金额</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    rlt.msg += "<div class=\"ui-block-a trodd\" style='width:60%;'><span>" + dt.Rows[j]["BrushCardTime"] + "</span></div>";
                    rlt.msg += "<div class=\"ui-block-b trodd\"  style='width:40%;'><span>" + dt.Rows[j]["Charge4"] + "</span></div>";
                }
                rlt.msg += "<div class=\"ui-block-a treven\" style='width:60%;'><span>" + dt.Rows[0]["Name"] + "</span></div>";
                rlt.msg += "<div class=\"ui-block-b treven\" style='width:40%;'><span>余额：" + dt.Rows[0]["Balance"] + "</span></div>";
            }
            else
                rlt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(rlt.GetType());
            json.WriteObject(Response.OutputStream, rlt);
        }

        public void SearchCanyinReportByMonth()
        {
            string year = Request["year"];
            string month = Request["month"];
            result lt = new result();
            DataTable dt = new com.hiooy.canyin.WS_CanYingAnalysis().CYAnalysisMonthReport("VYbSBDuFOPVd3452222", year,month);

            float totalXSE = 0;
            int totalKeDanShu = 0;
            float averagePrice = 0;

            if (dt.Rows.Count != 0)
            {
                lt.msg += "<div class=\"ui-block-a treven\" style='width:10%;'><span>行</span></div>";
                lt.msg += "<div class=\"ui-block-b treven\" style='width:30%;'><span>店铺</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>客单数</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>客单价</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:20%;'><span>销售额</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-a trodd\" style='width:10%;'><span>" + dt.Rows[j]["行号"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:30%;'><span>" + dt.Rows[j]["店铺"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>" + dt.Rows[j]["客单数"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + dt.Rows[j]["客单价"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:20%;'><span>" + dt.Rows[j]["销售额"] + "</span></div>";
                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    averagePrice += float.Parse(dt.Rows[j]["客单价"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["客单数"].ToString());

                }
                lt.msg += "<div class=\"ui-block-a trodd\" style='width:10%;'><span>合计数:</span></div>";
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:30%;'><span>" + "店铺共：" + dt.Rows.Count + "家</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>" + totalKeDanShu + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + (averagePrice / dt.Rows.Count).ToString("#0.0") + "</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:20%;'><span>" + totalXSE + "</span></div>";

            }

        }
       
        public class result
        {
            public bool success { get; set; }
            public string msg { get; set; }
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}