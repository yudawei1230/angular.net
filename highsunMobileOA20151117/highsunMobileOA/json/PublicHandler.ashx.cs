using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.SessionState;
using WebSite.Comman;

namespace highsunMobileOA.json
{
    /// <summary>
    /// PublicHandler 的摘要说明
    /// </summary>
    public class PublicHandler : IHttpHandler, IRequiresSessionState
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

        public void UserLogin()
        {
            result r = new result();
            string user = Request["user"];
            string pwd = Request["pwd"];
            string NiceName = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetNiceName(user, pwd);
            if (!string.IsNullOrEmpty(NiceName))
            {
                r.success = true;
                WebSite.Comman.CookieSession.WriteCookie("LoginName", NiceName, 36);
            }
            else
            {
                r.success = false;
                r.msg = "账号或密码有误";
            }
            DataContractJsonSerializer json = new DataContractJsonSerializer(r.GetType());
            json.WriteObject(Response.OutputStream, r);
        }
        public void insertComplain()
        {
            result r = new result();
            if (Request["fullname"].Equals(string.Empty))
            {
                r.success = false;
                r.msg = "真实姓名必填!";
            }
            else
            {
                if (Request["phone"].Equals(string.Empty))
                {
                    r.success = false;
                    r.msg = "手机号必填!";
                }
                else
                {
                    if (new WebSite.BLL.VerifyCode().CheckVerifyCode(Request["code"]))
                    {
                        HttpFileCollection files = HttpContext.Current.Request.Files;
                        WebSite.Models.Complaint complaint = new WebSite.Models.Complaint();
                        complaint.Ask = WebSite.Comman.CookieSession.GetCookie("LoginName");
                        complaint.AskTime = DateTime.Now;
                        complaint.RealName = Request["fullname"];
                        complaint.Phone = Request["phone"];
                        complaint.AskDetail = Request["askdetail"];
                        complaint.IsDel = false;
                        complaint.IsExamine = false;
                        HttpPostedFile img0 = files["fileToUpload0"];
                        if (img0.FileName != string.Empty)
                        {
                            complaint.Img0 = Upload.UploadProductImg(img0, 1);
                        }
                        HttpPostedFile img1 = files["fileToUpload1"];
                        if (img1.FileName != string.Empty)
                        {
                            complaint.Img1 = Upload.UploadProductImg(img1, 1);
                        }
                        HttpPostedFile img2 = files["fileToUpload2"];
                        if (img2.FileName != string.Empty)
                        {
                            complaint.Img2 = Upload.UploadProductImg(img2, 1);
                        }
                        new WebSite.BLL.PublicHandler().InsertAsk(complaint);
                        r.success = true;
                        r.msg = "感谢您的提交!";
                    }
                    else
                    {
                        r.success = false;
                        r.msg = "验证码不正确!";
                    }
                }
            }
            DataContractJsonSerializer json = new DataContractJsonSerializer(r.GetType());
            json.WriteObject(Response.OutputStream, r);
        }
        public void DelItem()
        {
            result r = new result();
            string id = Request["id"];
            int d = new WebSite.BLL.ComplaintBLL().DeleteEntityByKey(Convert.ToInt32(id));

            if (d > 0)
            {
                r.success = true;
                r.msg = "删除成功";
            }
            else
            {
                r.success = false;
                r.msg = "删除失败";
            }
            DataContractJsonSerializer json = new DataContractJsonSerializer(r.GetType());
            json.WriteObject(Response.OutputStream, r);
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