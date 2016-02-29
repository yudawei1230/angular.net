using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Web.Script.Serialization;
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

        #region 移动门户
        #region 新闻
        public void HighsunPortal_GetCenterNews()       //新闻列表
        {
            string newsType = Request["newsType"];
            int newsSum = int.Parse(Request["newsSum"]);
            DataTable dt = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetCenterNews("VYbSBDuFOPVd3452222", newsType, newsSum);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> newsID = new List<object>();
            List<object> newsImg = new List<object>();
            List<object> newsTitle = new List<object>();
            List<object> createUser = new List<object>();
            List<object> createTime = new List<object>();
            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<div class=\"everyNewsContent\">" +
            "<a onclick=\"forward(this)\" class=\"link\" id=\"" + dt.Rows[j]["NewsID"] + "\"> " +
             "<div class=\"newsImg\"><img width=\"80px\" height=\"80px\" src=\"images/03.png\"></div>" +
             "<div class=\"newsCon\">" +
              "<div class=\"newsTitle\">" + dt.Rows[j]["NewsTitle"] + "</div>" +
             " <div class=\"newsAuthor\">创建者：" + dt.Rows[j]["CreateUser"] + "</div><div class=\"newsDate\">" + dt.Rows[j]["CreateTime"] + "</div>" +
             "</div>" +
           " </a>" +
          "</div>" +
           "<div style=\"clear:both;\"></div>");
                    newsID.Add(dt.Rows[j]["NewsID"]);
                    newsImg.Add(dt.Rows[j]["ImageUrl"]);
                    newsTitle.Add(dt.Rows[j]["NewsTitle"]);
                    createUser.Add(dt.Rows[j]["CreateUser"]);
                    createTime.Add(dt.Rows[j]["CreateTime"].ToString().Split(' ')[0]);
                }
                item.Add(msg);
                item.Add(newsID);
                item.Add(newsImg);
                item.Add(newsTitle);
                item.Add(createUser);
                item.Add(createTime);
                DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
                json.WriteObject(Response.OutputStream, item);
            }
        }
        public void HighsunPortal_GetCenterNewsByID()       //新闻详细页面
        {
            string newsID_request = Request["newsID"];
            string result = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetCenterNewsByID("VYbSBDuFOPVd3452222", newsID_request);
            List<object> item = new List<object>();
            List<object> newsID = new List<object>();
            List<object> newsTitle = new List<object>();
            List<object> newsContent = new List<object>();
            List<object> newsImg = new List<object>();
            List<object> createUser = new List<object>();
            List<object> createTime = new List<object>();
            if (result.Length != 0)
            {
                newsID.Add(result.Replace("||", "|").Split('|')[0]);     //Split()里面是用char类型不是string字符串类型,只能有一个字符
                newsTitle.Add(result.Replace("||", "|").Split('|')[1]);
                newsContent.Add(result.Replace("||", "|").Split('|')[2]);
                newsImg.Add(result.Replace("||", "|").Split('|')[3]);
                createUser.Add(result.Replace("||", "|").Split('|')[4]);
                createTime.Add(result.Replace("||", "|").Split('|')[5]);
            }
            item.Add(newsID);
            item.Add(newsImg);
            item.Add(newsTitle);
            item.Add(newsContent);
            item.Add(createUser);
            item.Add(createTime);

            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }
        #endregion
        #endregion

        #region 百货业务年度、季度、月份、日销售报表
        public void SearchBaihuoReportByYear()
        {
            string year = Request["year"];
            result lt = new result();
            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHAnalysisYearReport("VYbSBDuFOPVd3452222", year);

            double totalXSE = 0;
            int totalKeDanShu = 0;
            float averagePrice = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:32%;'><span>柜组</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>销售额</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>客单数</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>客单价</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + dt.Rows[j]["柜组"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>" + dt.Rows[j]["销售额"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + dt.Rows[j]["客单数"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + dt.Rows[j]["客单价"] + "</span></div>";
                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    averagePrice += float.Parse(dt.Rows[j]["客单价"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["客单数"].ToString());

                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>" + totalXSE.ToString("#0.0") + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + totalKeDanShu + "</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + (averagePrice / dt.Rows.Count).ToString("#0.0") + "</span></div>";

            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchBaihuoReportBySeason()
        {
            string year = Request["year"];
            int season = int.Parse(Request["season"]);
            result lt = new result();
            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHAnalysisSeasonReport("VYbSBDuFOPVd3452222", year, season);

            double totalXSE = 0;
            int totalKeDanShu = 0;
            float averagePrice = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:32%;'><span>柜组</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>销售额</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>客单数</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>客单价</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + dt.Rows[j]["柜组"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>" + dt.Rows[j]["销售额"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + dt.Rows[j]["客单数"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + dt.Rows[j]["客单价"] + "</span></div>";
                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    averagePrice += float.Parse(dt.Rows[j]["客单价"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["客单数"].ToString());

                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>" + totalXSE.ToString("#0.0") + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + totalKeDanShu + "</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + (averagePrice / dt.Rows.Count).ToString("#0.0") + "</span></div>";

            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchBaihuoReportByMonth()
        {
            string year = Request["year"];
            string month = Request["month"];
            result lt = new result();
            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHAnalysisMonthReport("VYbSBDuFOPVd3452222", year, month);

            double totalXSE = 0;
            int totalKeDanShu = 0;
            float averagePrice = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:32%;'><span>柜组</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>销售额</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>客单数</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>客单价</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + dt.Rows[j]["柜组"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>" + dt.Rows[j]["销售额"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + dt.Rows[j]["客单数"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + dt.Rows[j]["客单价"] + "</span></div>";
                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    averagePrice += float.Parse(dt.Rows[j]["客单价"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["客单数"].ToString());

                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>" + totalXSE.ToString("#0.0") + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + totalKeDanShu + "</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + (averagePrice / dt.Rows.Count).ToString("#0.0") + "</span></div>";

            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchBaihuoReportByDate()
        {
            string date = Request["date"];
            result lt = new result();
            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHAnalysisDayReport("VYbSBDuFOPVd3452222", date);

            float totalXSE = 0;
            int totalKeDanShu = 0;
            float averagePrice = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:32%;'><span>柜组</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>销售额</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>客单数</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>客单价</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + dt.Rows[j]["柜组"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>" + dt.Rows[j]["销售额"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + dt.Rows[j]["客单数"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + dt.Rows[j]["客单价"] + "</span></div>";
                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    averagePrice += float.Parse(dt.Rows[j]["客单价"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["客单数"].ToString());

                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>" + totalXSE + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + totalKeDanShu + "</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + (averagePrice / dt.Rows.Count).ToString("#0.0") + "</span></div>";

            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        #endregion

        #region 餐饮业务
        public void SearchCanyinReportByMonth()
        {
            string year = Request["year"];
            string month = Request["month"];
            result lt = new result();
            DataTable dt = new com.hiooy.canyin.WS_CanYingAnalysis().CYAnalysisMonthReport("VYbSBDuFOPVd3452222", year, month);

            float totalXSE = 0;
            int totalKeDanShu = 0;
            float averagePrice = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:32%;'><span>店铺</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:27%;'><span>销售额</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>客单数</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:21%;'><span>客单价</span></div>";

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + dt.Rows[j]["店铺"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:27%;'><span>" + dt.Rows[j]["销售额"] + "</span></div>";

                    lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>" + dt.Rows[j]["客单数"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:21%;'><span>" + dt.Rows[j]["客单价"] + "</span></div>";
                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    averagePrice += float.Parse(dt.Rows[j]["客单价"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["客单数"].ToString());

                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:27%;'><span>" + totalXSE + "</span></div>";

                lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>" + totalKeDanShu + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:21%;'><span>" + (averagePrice / dt.Rows.Count).ToString("#0.0") + "</span></div>";

            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchCanyinReportBySeason()
        {
            string year = Request["year"];
            int season = int.Parse(Request["season"]);
            result lt = new result();
            DataTable dt = new com.hiooy.canyin.WS_CanYingAnalysis().CYAnalysisSeasonReport("VYbSBDuFOPVd3452222", year, season);

            float totalXSE = 0;
            int totalKeDanShu = 0;
            float averagePrice = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:32%;'><span>店铺</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:27%;'><span>销售额</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>客单数</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:21%;'><span>客单价</span></div>";

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + dt.Rows[j]["店铺"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:27%;'><span>" + dt.Rows[j]["销售额"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>" + dt.Rows[j]["客单数"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:21%;'><span>" + dt.Rows[j]["客单价"] + "</span></div>";

                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    averagePrice += float.Parse(dt.Rows[j]["客单价"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["客单数"].ToString());

                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:27%;'><span>" + totalXSE + "</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>" + totalKeDanShu + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:21%;'><span>" + (averagePrice / dt.Rows.Count).ToString("#0.0") + "</span></div>";

            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchCanyinReportByDate()
        {
            string date = Request["date"];
            result lt = new result();
            DataTable dt = new com.hiooy.canyin.WS_CanYingAnalysis().CYAnalysisDayReport("VYbSBDuFOPVd3452222", date);
            List<object> shop = new List<object>();
            List<object> sale = new List<object>();

            float totalXSE = 0;
            int totalKeDanShu = 0;
            float averagePrice = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:32%;'><span>店铺</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:27%;'><span>销售额</span></div>";

                lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>客单数</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:21%;'><span>客单价</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + dt.Rows[j]["店铺"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:27%;'><span>" + dt.Rows[j]["销售额"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>" + dt.Rows[j]["客单数"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:21%;'><span>" + dt.Rows[j]["客单价"] + "</span></div>";
                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    averagePrice += float.Parse(dt.Rows[j]["客单价"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["客单数"].ToString());

                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:27%;'><span>" + totalXSE + "</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>" + totalKeDanShu + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:21%;'><span>" + (averagePrice / dt.Rows.Count).ToString("#0.0") + "</span></div>";
            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchCanyinReportByYear()
        {
            string year = Request["year"];
            result lt = new result();
            DataTable dt = new com.hiooy.canyin.WS_CanYingAnalysis().CYAnalysisYearReport("VYbSBDuFOPVd3452222", year);

            float totalXSE = 0;
            int totalKeDanShu = 0;
            float averagePrice = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:32%;'><span>店铺</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:27%;'><span>销售额</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>客单数</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:21%;'><span>客单价</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + dt.Rows[j]["店铺"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:27%;'><span>" + dt.Rows[j]["销售额"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>" + dt.Rows[j]["客单数"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:21%;'><span>" + dt.Rows[j]["客单价"] + "</span></div>";
                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    averagePrice += float.Parse(dt.Rows[j]["客单价"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["客单数"].ToString());

                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:27%;'><span>" + totalXSE + "</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:20%;'><span>" + totalKeDanShu + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:21%;'><span>" + (averagePrice / dt.Rows.Count).ToString("#0.0") + "</span></div>";

            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchCanyinChartByDate()
        {
            string date = Request["date"];
            string nowDate, inputYeaer, inputMonth, inputDay, chartDate;//chartDate图表的日期
            DataTable dp = new DataTable();
            List<object> item = new List<object>();
            List<object> shop = new List<object>();
            List<object> sale = new List<object>();
            nowDate = DateTime.Now.ToString("yyyy-MM-dd");
            inputYeaer = date.Split('-')[0];
            inputMonth = date.Split('-')[1];
            inputDay = date.Split('-')[2];
            for (int day = 1; day <= 31; day++)
            {
                string m = "";
                m += (day > 9 ? "" : "0") + day + " ";
                chartDate = inputYeaer + "-" + inputMonth + "-" + m;
                dp = new com.hiooy.canyin.WS_CanYingAnalysis().CYAnalysisDayReport("VYbSBDuFOPVd3452222", chartDate);
                if (dp.Rows.Count != 0)
                {
                    for (int i = 0; i < dp.Rows.Count; i++)
                    {
                        shop.Add(dp.Rows[i]["店铺"]);
                        for (int j = i; j < dp.Rows.Count; j += dp.Rows.Count)
                        {
                            sale.Add(float.Parse(dp.Rows[j]["销售额"].ToString().ToString()));
                        }
                    }
                }
            }
            item.Add(shop);
            item.Add(sale);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchCanyinChartByMonth()
        {
            string year = Request["year"];
            string month = Request["month"];
            float count = 0;
            float sum = 0;
            float avg = 0;
            string[] colour = { "#3883bd", "#3F5C71", "#a6bfd2", "#aa4643", "#89a54e", "#814fa8", "#c2c232", "#4572a7", "#3d96ae", "#80699b" };

            DataTable dt = new com.hiooy.canyin.WS_CanYingAnalysis().CYAnalysisMonthReport("VYbSBDuFOPVd3452222", year, month);
            List<object> item = new List<object>();
            List<object> shop = new List<object>();
            List<object> sale = new List<object>();
            List<object> color = new List<object>();


            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    shop.Add(dt.Rows[j]["店铺"]);
                    count += float.Parse(dt.Rows[j]["销售额"].ToString());
                    color.Add(colour[j]);
                }
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if (count != 0)
                    {
                        avg = (float.Parse(dt.Rows[i]["销售额"].ToString()) / count) * 100;
                    }
                    sum += avg;
                    sale.Add(avg.ToString("#0.00"));
                }
                avg = 100 - sum;
                sale.Add(avg.ToString("#0.00"));
                item.Add(shop);
                item.Add(sale);
                item.Add(color);
            }
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchCanyinChartByYear()
        {
            string year = Request["year"];
            float count = 0;
            float sum = 0;
            float avg = 0;
            string[] colour = { "#3883bd", "#3F5C71", "#a6bfd2", "#aa4643", "#89a54e", "#814fa8", "#c2c232", "#4572a7", "#3d96ae", "#80699b" };

            DataTable dt = new com.hiooy.canyin.WS_CanYingAnalysis().CYAnalysisYearReport("VYbSBDuFOPVd3452222", year);
            List<object> item = new List<object>();
            List<object> shop = new List<object>();
            List<object> sale = new List<object>();
            List<object> color = new List<object>();


            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    shop.Add(dt.Rows[j]["店铺"]);
                    count += float.Parse(dt.Rows[j]["销售额"].ToString());
                    color.Add(colour[j]);
                }
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if (count != 0)
                    {
                        avg = (float.Parse(dt.Rows[i]["销售额"].ToString()) / count) * 100;
                    }
                    sum += avg;
                    sale.Add(avg.ToString("#0.00"));
                }
                avg = 100 - sum;
                sale.Add(avg.ToString("#0.00"));
                item.Add(shop);
                item.Add(sale);
                item.Add(color);
            }
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchCanyinChartBySeason()
        {
            string year = Request["year"];
            int season = int.Parse(Request["season"]);
            float count = 0;
            float sum = 0;
            float avg = 0;
            string[] colour = { "#3883bd", "#3F5C71", "#a6bfd2", "#aa4643", "#89a54e", "#814fa8", "#c2c232", "#4572a7", "#3d96ae", "#80699b" };

            DataTable dt = new com.hiooy.canyin.WS_CanYingAnalysis().CYAnalysisSeasonReport("VYbSBDuFOPVd3452222", year, season);
            List<object> item = new List<object>();
            List<object> shop = new List<object>();
            List<object> sale = new List<object>();
            List<object> color = new List<object>();


            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    shop.Add(dt.Rows[j]["店铺"]);
                    count += float.Parse(dt.Rows[j]["销售额"].ToString());
                    color.Add(colour[j]);
                }
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if (count != 0)
                    {
                        avg = (float.Parse(dt.Rows[i]["销售额"].ToString()) / count) * 100;
                    }
                    sum += avg;
                    sale.Add(avg.ToString("#0.00"));
                }
                avg = 100 - sum;
                sale.Add(avg.ToString("#0.00"));
                item.Add(shop);
                item.Add(sale);
                item.Add(color);
            }
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }
        #endregion

        #region  百货图表分析业务方法

        public void SearchBaihuoReportByFloor()
        {
            string date = Request["date"];
            result lt = new result();
            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHAnalysis4FloorReport("VYbSBDuFOPVd3452222", date);

            double totalXSE = 0;
            int totalKeDanShu = 0;
            int totalKeliuliang = 0;
            float averagePrice = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:22%;'><span>楼层</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:22%;'><span>销售额</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:18%;'><span>客单数</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:18%;'><span>客单价</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:20%;'><span>客流数</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<a onclick=\"forward(this)\" id=\"" + dt.Rows[j]["富基楼层"] + "\" name=\"" + dt.Rows[j]["楼层"] + "\">";
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:22%;'><span>" + dt.Rows[j]["楼层"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:22%;'><span>" + dt.Rows[j]["销售额"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:18%;'><span>" + dt.Rows[j]["客单数"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:18%;'><span>" + float.Parse(dt.Rows[j]["客单价"].ToString()).ToString("#0.0") + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:20%;'><span>" + dt.Rows[j]["客流数"] + "</span></div>";

                    lt.msg += "</a>";
                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    averagePrice += float.Parse(dt.Rows[j]["客单价"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["客单数"].ToString());
                    totalKeliuliang += int.Parse(dt.Rows[j]["客流数"].ToString());
                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:22%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:22%;'><span>" + totalXSE.ToString("#0") + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:18%;'><span>" + totalKeDanShu + "</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:18%;'><span>" + (averagePrice / dt.Rows.Count).ToString("#0") + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + totalKeliuliang + "</span></div>";

            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchBaihuoReportByFloorDetail()
        {
            string date = Request["date"];
            string floor = Request["floor"];
            result lt = new result();
            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHAnalysisByFloorDetailReport("VYbSBDuFOPVd3452222", date, floor);

            double totalXSE = 0;
            int totalKeDanShu = 0;
            float averagePrice = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:32%;'><span>柜组</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>销售额</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>客单数</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>客单价</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + dt.Rows[j]["柜组"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>" + dt.Rows[j]["销售额"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + dt.Rows[j]["客单数"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + dt.Rows[j]["客单价"] + "</span></div>";
                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    averagePrice += float.Parse(dt.Rows[j]["客单价"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["客单数"].ToString());
                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>" + totalXSE.ToString("#0.0") + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + totalKeDanShu + "</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + (averagePrice / dt.Rows.Count).ToString("#0.0") + "</span></div>";
            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchBaihuoMonthReportByFloor()
        {
            string date = Request["date"];
            result lt = new result();
            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHAnalysis4FloorMonthReport("VYbSBDuFOPVd3452222", date);

            double totalXSE = 0;
            int totalKeDanShu = 0;
            float averagePrice = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:27%;'><span>楼层</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:32%;'><span>销售额(万元)</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>客单数</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>客单价</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<a onclick=\"forward(this)\" id=\"" + dt.Rows[j]["楼层编码"] + "\" name=\"" + dt.Rows[j]["楼层"] + "\">";
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:27%;'><span>" + dt.Rows[j]["楼层"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:32%;'><span>" + (float.Parse(dt.Rows[j]["销售额"].ToString()) / 10000).ToString("#0.00") + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + dt.Rows[j]["客单数"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + dt.Rows[j]["客单价"] + "</span></div>";
                    lt.msg += "</a>";
                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    averagePrice += float.Parse(dt.Rows[j]["客单价"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["客单数"].ToString());
                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:27%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:32%;'><span>" + float.Parse((totalXSE / 10000).ToString()).ToString("#0.0") + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + totalKeDanShu + "</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + (averagePrice / dt.Rows.Count).ToString("#0.0") + "</span></div>";
            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchBaihuoMonthReportByFloorDetail()
        {
            string date = Request["date"];
            string floor = Request["floor"];
            result lt = new result();
            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHAnalysisByFloorDetailMonthReport("VYbSBDuFOPVd3452222", date, floor);

            double totalXSE = 0;
            int totalKeDanShu = 0;
            float averagePrice = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:32%;'><span>柜组</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>销售额</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>客单数</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>客单价</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + dt.Rows[j]["柜组"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>" + dt.Rows[j]["销售额"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + dt.Rows[j]["客单数"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + dt.Rows[j]["客单价"] + "</span></div>";
                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    averagePrice += float.Parse(dt.Rows[j]["客单价"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["客单数"].ToString());
                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:32%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:27%;'><span>" + totalXSE.ToString("#0.0") + "</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:20%;'><span>" + totalKeDanShu + "</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:21%;'><span>" + (averagePrice / dt.Rows.Count).ToString("#0.0") + "</span></div>";
            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchBaihuoChartByDate()
        {
            string date = Request["date"];
            float count = 0;
            float sum = 0;
            float avg = 0;
            string[] colour = { "#3883bd", "#3F5C71", "#a6bfd2", "#aa4643", "#89a54e", "#814fa8", "#c2c232", "#4572a7", "#3d96ae", "#80699b" };

            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHAnalysis4FloorReport("VYbSBDuFOPVd3452222", date);
            List<object> item = new List<object>();
            List<object> shop = new List<object>();
            List<object> sale = new List<object>();
            List<object> color = new List<object>();


            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    shop.Add(dt.Rows[j]["楼层"]);
                    count += float.Parse(dt.Rows[j]["销售额"].ToString());
                    color.Add(colour[j]);
                }
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if (count != 0)
                    {
                        avg = (float.Parse(dt.Rows[i]["销售额"].ToString()) / count) * 100;
                    }
                    sum += avg;
                    sale.Add(avg.ToString("#0.00"));
                }
                avg = 100 - sum;
                sale.Add(avg.ToString("#0.00"));
                item.Add(shop);
                item.Add(sale);
                item.Add(color);
            }
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchBaihuoChartByMonth()
        {
            string date = Request["date"];
            float count = 0;
            float sum = 0;
            float avg = 0;
            string[] colour = { "#3883bd", "#3F5C71", "#a6bfd2", "#aa4643", "#89a54e", "#814fa8", "#c2c232", "#4572a7", "#3d96ae", "#80699b" };

            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHAnalysis4FloorMonthReport("VYbSBDuFOPVd3452222", date);
            List<object> item = new List<object>();
            List<object> shop = new List<object>();
            List<object> sale = new List<object>();
            List<object> color = new List<object>();


            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    shop.Add(dt.Rows[j]["楼层"]);
                    count += float.Parse(dt.Rows[j]["销售额"].ToString());
                    color.Add(colour[j]);
                }
                for (int i = 0; i < dt.Rows.Count - 1; i++)
                {
                    if (count != 0)
                    {
                        avg = (float.Parse(dt.Rows[i]["销售额"].ToString()) / count) * 100;
                    }
                    sum += avg;
                    sale.Add(avg.ToString("#0.00"));
                }
                avg = 100 - sum;
                sale.Add(avg.ToString("#0.00"));
                item.Add(shop);
                item.Add(sale);
                item.Add(color);
            }
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchBaihuoTaskByMonth()
        {
            string year = Request["year"];
            string month = Request["month"];
            string stime = year + "-" + month + "-01";
            string etime = year + "-" + month + "-" + DateTime.DaysInMonth(int.Parse(year), int.Parse(month));
            float MC;
            float MT;
            float CT;
            float CR;

            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHTaskAnalysis4Month("VYbSBDuFOPVd3452222", stime, etime);
            List<object> item = new List<object>();
            List<object> Mcomp = new List<object>();
            List<object> MTask = new List<object>();
            List<object> CST = new List<object>();
            List<object> CRate = new List<object>();

            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    MC = float.Parse(dt.Rows[j]["MonthCompleted"].ToString()) / 10000;
                    Mcomp.Add(MC.ToString("#0.0"));
                    MT = float.Parse(dt.Rows[j]["MonthTask"].ToString()) / 10000;
                    MTask.Add(MT.ToString("#0.0"));
                    CT = float.Parse(dt.Rows[j]["ComparedSameTime"].ToString()) * 100;
                    CST.Add(CT.ToString("#0.0"));
                    CR = float.Parse(dt.Rows[j]["CompletedRate"].ToString()) * 100;
                    CRate.Add(CR.ToString("#0.0"));
                }
                item.Add(Mcomp);
                item.Add(MTask);
                item.Add(CST);
                item.Add(CRate);
            }
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchBaihuoTaskBySeason()
        {
            string year = Request["year"];
            string month = Request["month"];
            int season = (int.Parse(month) + 2) / 3;
            string stime = year + "-" + (3 * (season - 1) + 1) + "-01";
            string etime = year + "-" + (3 * season) + "-" + DateTime.DaysInMonth(int.Parse(year), 3 * season);
            float MC;
            float MT;
            float CT;
            float CR;

            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHTaskAnalysis4Season("VYbSBDuFOPVd3452222", stime, etime);
            List<object> item = new List<object>();
            List<object> Mcomp = new List<object>();
            List<object> MTask = new List<object>();
            List<object> CST = new List<object>();
            List<object> CRate = new List<object>();

            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    MC = float.Parse(dt.Rows[j]["MonthCompleted"].ToString()) / 10000;
                    Mcomp.Add(MC.ToString("#0.0"));
                    MT = float.Parse(dt.Rows[j]["MonthTask"].ToString()) / 10000;
                    MTask.Add(MT.ToString("#0.0"));
                    CT = float.Parse(dt.Rows[j]["ComparedSameTime"].ToString()) * 100;
                    CST.Add(CT.ToString("#0.0"));
                    CR = float.Parse(dt.Rows[j]["CompletedRate"].ToString()) * 100;
                    CRate.Add(CR.ToString("#0.0"));
                }
                item.Add(Mcomp);
                item.Add(MTask);
                item.Add(CST);
                item.Add(CRate);
            }
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchBaihuoTaskByYear()
        {
            string year = Request["year"];
            string stime = year + "-" + "01" + "-01";
            string etime = year + "-" + "12" + "-31";
            float MC;
            float MT;
            float CT;
            float CR;

            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHTaskAnalysis4Year("VYbSBDuFOPVd3452222", stime, etime);
            List<object> item = new List<object>();
            List<object> Mcomp = new List<object>();
            List<object> MTask = new List<object>();
            List<object> CST = new List<object>();
            List<object> CRate = new List<object>();

            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    MC = float.Parse(dt.Rows[j]["YearCompleted"].ToString()) / 10000;
                    Mcomp.Add(MC.ToString("#0.0"));
                    MT = float.Parse(dt.Rows[j]["YearTask"].ToString()) / 10000;
                    MTask.Add(MT.ToString("#0.0"));
                    CT = float.Parse(dt.Rows[j]["ComparedSameTime"].ToString()) * 100;
                    CST.Add(CT.ToString("#0.0"));
                    CR = float.Parse(dt.Rows[j]["CompletedRate"].ToString()) * 100;
                    CRate.Add(CR.ToString("#0.0"));
                }
                item.Add(Mcomp);
                item.Add(MTask);
                item.Add(CST);
                item.Add(CRate);
            }
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchBaihuoTrend()
        {
            DateTime dtime = DateTime.Parse("2015-04");
            result lt = new result();
            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHTrendAnalysis4Floor("VYbSBDuFOPVd3452222", dtime);


            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:35%;'><span>日期</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:35%;'><span>销售额</span></div>";
                lt.msg += "<div class=\"ui-block-d treven\" style='width:30%;'><span>楼层</span></div>";

                for (int j = 0; j < dt.Rows.Count; j++)
                {

                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:35%;'><span>" + dt.Rows[j]["日期"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:35%;'><span>" + dt.Rows[j]["销售额"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-d treven\" style='width:30%;'><span>" + dt.Rows[j]["楼层"] + "</span></div>";


                }
            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchBaihuoTrendbyMonth()
        {
            string year = Request["year"];
            string month = Request["month"];
            DateTime dtime = DateTime.Parse(year + "-" + month);
            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHTrendAnalysis4Month("VYbSBDuFOPVd3452222", dtime);

            List<object> item = new List<object>();
            List<object> xiaoshoue = new List<object>();
            List<object> date = new List<object>();
            float xse;
            DateTime time;

            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    xse = (float.Parse(dt.Rows[j]["销售额"].ToString()) / 10000);
                    xiaoshoue.Add(xse);
                    time = DateTime.Parse(dt.Rows[j]["日期"].ToString());
                    date.Add(time.Day);
                }
                item.Add(xiaoshoue);
                item.Add(date);
            }
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchBaihuoVIPDayReport()
        {
            string sdate = Request["sdate"];
            string edate = Request["edate"];
            string[] colour = { "#3883bd", "#3F5C71", "#a6bfd2", "#aa4643", "#89a54e", "#814fa8", "#c2c232", "#4572a7", "#3d96ae", "#80699b" };

            DataTable dt = new com.hiooy.baihuo.WS_BaiHuoAnalysis().BHAnalysisVIPDayReport("VYbSBDuFOPVd3452222", sdate, edate);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> KDS = new List<object>();
            List<object> VIPKDS = new List<object>();
            List<object> KDSProportion = new List<object>();
            List<object> TotalXFJE = new List<object>();
            List<object> VIPXFJE = new List<object>();
            List<object> VIPXFJEProportion = new List<object>();

            if (dt.Rows.Count != 0)
            {

                msg.Add("<div class=\"ui-block-b treven\" style='width:30%;'><span>客单数</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:30%;'><span>会员客单数</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:40%;'><span>会员客单数占比</span></div>");

                msg.Add("<div class=\"ui-block-b trodd\"  style='width:30%;'><span>" + dt.Rows[0]["客单数"] + "</span></div>");
                KDS.Add(dt.Rows[0]["客单数"]);
                msg.Add("<div class=\"ui-block-c trodd\" style='width:30%;'><span>" + dt.Rows[0]["会员客单数"] + "</span></div>");
                VIPKDS.Add(float.Parse(dt.Rows[0]["会员客单数"].ToString()));
                msg.Add("<div class=\"ui-block-d trodd\" style='width:40%;'><span>" + float.Parse(dt.Rows[0]["会员客单数占比"].ToString()) * 100 + "%" + "</span></div>");
                KDSProportion.Add(float.Parse(dt.Rows[0]["会员客单数占比"].ToString()));


                msg.Add("<br />");
                msg.Add("<div class=\"ui-block-e treven\" style='width:30%;'><span>总消费额</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:30%;'><span>会员消费额</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:40%;'><span>会员消费额占比</span></div>");

                msg.Add("<div class=\"ui-block-e trodd\" style='width:30%;'><span>" + dt.Rows[0]["总消费金额"] + "</span></div>");
                TotalXFJE.Add(float.Parse(dt.Rows[0]["总消费金额"].ToString()));
                msg.Add("<div class=\"ui-block-e trodd\" style='width:30%;'><span>" + dt.Rows[0]["会员消费金额"] + "</span></div>");
                VIPXFJE.Add(float.Parse(dt.Rows[0]["会员消费金额"].ToString()));
                msg.Add("<div class=\"ui-block-e trodd\" style='width:40%;'><span>" + float.Parse(dt.Rows[0]["会员消费金额占比"].ToString()) * 100 + "%" + "</span></div>");
                VIPXFJEProportion.Add(float.Parse(dt.Rows[0]["会员消费金额占比"].ToString()));
                msg.Add("</a>");

            }
            item.Add(msg);
            item.Add(KDS);
            item.Add(VIPKDS);
            item.Add(KDSProportion);
            item.Add(TotalXFJE);
            item.Add(VIPXFJE);
            item.Add(VIPXFJEProportion);

            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }
        #endregion

        #region 房地产销售
        public void SearchERPSellHouseAnalysisReport()
        {

            DataTable dt = new com.hiooy.ERPhouse.WS_ERPSellHouseAnalysis().ERPSellHouseAnalysisReport("VYbSBDuFOPVd3452334222");
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> SumTotal = new List<object>();
            List<object> REST = new List<object>();
            List<object> PrePurchase = new List<object>();
            List<object> Purchase = new List<object>();
            List<object> Signed = new List<object>();
            List<object> projectName = new List<object>();

            string[] projectNames = { "总统公馆", "森邻四季", "展贸城", "鼎湖", "大旺" };

            if (dt.Rows.Count != 0)
            {

                msg.Add("<div class=\"ui-block-b treven\" style='width:25%;'><span>项目名称</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>总数</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:15%;'><span>待售</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:15%;'><span>预订</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:15%;'><span>认购</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:15%;'><span>签约</span></div>");
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<a onclick=\"forward(this)\" id=\"" + dt.Rows[j]["ProjectNo"] + "\">");
                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:25%;'><span>" + projectNames[j] + "</span></div>");
                    projectName.Add(projectNames[j]);
                    msg.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>" + dt.Rows[j]["SumTotal"] + "</span></div>");
                    SumTotal.Add(float.Parse(dt.Rows[j]["SumTotal"].ToString()));
                    msg.Add("<div class=\"ui-block-d treven\" style='width:15%;'><span>" + dt.Rows[j]["REST"] + "</span></div>");
                    REST.Add(float.Parse(dt.Rows[j]["REST"].ToString()));
                    msg.Add("<div class=\"ui-block-e treven\" style='width:15%;'><span>" + dt.Rows[j]["PrePurchase"] + "</span></div>");
                    PrePurchase.Add(float.Parse(dt.Rows[j]["PrePurchase"].ToString()));
                    msg.Add("<div class=\"ui-block-e treven\" style='width:15%;'><span>" + dt.Rows[j]["Purchase"] + "</span></div>");
                    Purchase.Add(float.Parse(dt.Rows[j]["Purchase"].ToString()));
                    msg.Add("<div class=\"ui-block-e treven\" style='width:15%;'><span>" + dt.Rows[j]["Signed"] + "</span></div>");
                    Signed.Add(float.Parse(dt.Rows[j]["Signed"].ToString()));
                    msg.Add("</a>");
                }
            }
            item.Add(msg);
            item.Add(SumTotal);
            item.Add(REST);
            item.Add(PrePurchase);
            item.Add(Purchase);
            item.Add(Signed);
            item.Add(projectName);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchERPSellHouseAnlysisBuildingReport()
        {
            string prjNo = Request["projectNo"];
            prjNo += "++Ws";
            DataTable dt = new com.hiooy.ERPhouse.WS_ERPSellHouseAnalysis().ERPSellHouseAnlysisBuildingReport("VYbSBDuFOPVd3452334222", prjNo);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> BuildingName = new List<object>();
            List<object> SumTotal = new List<object>();
            List<object> REST = new List<object>();
            List<object> PrePurchase = new List<object>();
            List<object> Purchase = new List<object>();
            List<object> Signed = new List<object>();
            string projectName = "";

            if (dt.Rows.Count != 0)
            {
                msg.Add("<div class=\"ui-block-b treven\" style='width:52%;'><span>楼栋</span></div>");
                msg.Add("<div class=\"ui-block-b treven\" style='width:12%;'><span>总数</span></div>");
                msg.Add("<div class=\"ui-block-b treven\" style='width:12%;'><span>待售</span></div>");
                //msg.Add("<div class=\"ui-block-c treven\" style='width:12%;'><span>预订</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:12%;'><span>认购</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:12%;'><span>签约</span></div>");
                projectName = dt.Rows[0]["projectName"].ToString();

                for (int j = 0; j < dt.Rows.Count; j++)
                {

                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:52%;'><span>" + dt.Rows[j]["BuildingName"] + "</span></div>");
                    BuildingName.Add(dt.Rows[j]["BuildingName"].ToString());
                    msg.Add("<div class=\"ui-block-c treven\" style='width:12%;'><span>" + dt.Rows[j]["SumTotal"] + "</span></div>");
                    SumTotal.Add(float.Parse(dt.Rows[j]["SumTotal"].ToString()));
                    msg.Add("<div class=\"ui-block-c treven\" style='width:12%;'><span>" + dt.Rows[j]["REST"] + "</span></div>");
                    REST.Add(float.Parse(dt.Rows[j]["REST"].ToString()));
                    //msg.Add("<div class=\"ui-block-c treven\" style='width:12%;'><span>" + dt.Rows[j]["PrePurchase"] + "</span></div>");
                    PrePurchase.Add(float.Parse(dt.Rows[j]["PrePurchase"].ToString()));
                    msg.Add("<div class=\"ui-block-c treven\" style='width:12%;'><span>" + dt.Rows[j]["Purchase"] + "</span></div>");
                    Purchase.Add(float.Parse(dt.Rows[j]["Purchase"].ToString()));
                    msg.Add("<div class=\"ui-block-c treven\" style='width:12%;'><span>" + dt.Rows[j]["Signed"] + "</span></div>");
                    Signed.Add(float.Parse(dt.Rows[j]["Signed"].ToString()));
                }
            }
            item.Add(msg);
            item.Add(BuildingName);
            item.Add(SumTotal);
            item.Add(REST);
            item.Add(PrePurchase);
            item.Add(Purchase);
            item.Add(Signed);
            item.Add(projectName);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchERPSellHouseCWAnalysisReport()
        {

            DataTable dt = new com.hiooy.ERPhouse.WS_ERPSellHouseAnalysis().ERPSellHouseCWAnlysisiReport("VYbSBDuFOPVd3452334222");
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> ProjectName = new List<object>();
            List<object> SumChenjiaojia = new List<object>();
            List<object> SumHetonghuikuan = new List<object>();
            List<object> SumHetongqiankuan = new List<object>();

            if (dt.Rows.Count != 0)
            {

                msg.Add("<div class=\"ui-block-b treven\" style='width:30%;'><span>项目名称</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:20%;'><span>成交额</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:25%;'><span>合同回款</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:25%;'><span>合同欠款</span></div>");
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<div class=\"ui-block-c treven\" style='width:30%;'><span>" + dt.Rows[j]["xiangmu"] + "</span></div>");
                    ProjectName.Add(dt.Rows[j]["xiangmu"].ToString());

                    msg.Add("<div class=\"ui-block-d treven\" style='width:20%;'><span>" + (float.Parse(dt.Rows[j]["chenjiaojia"].ToString()) / 10000).ToString("#0.0") + "</span></div>");
                    SumChenjiaojia.Add(float.Parse((float.Parse(dt.Rows[j]["chenjiaojia"].ToString()) / 10000).ToString("#0.0")));

                    msg.Add("<div class=\"ui-block-d treven\" style='width:25%;'><span>" + (float.Parse(dt.Rows[j]["hetonghuikuan"].ToString()) / 10000).ToString("#0.0") + "</span></div>");
                    SumHetonghuikuan.Add(float.Parse((float.Parse(dt.Rows[j]["hetonghuikuan"].ToString()) / 10000).ToString("#0.0")));

                    msg.Add("<div class=\"ui-block-d treven\" style='width:25%;'><span>" + (float.Parse(dt.Rows[j]["hetongqiankuan"].ToString()) / 10000).ToString("#0.0") + "</span></div>");
                    SumHetongqiankuan.Add(float.Parse((float.Parse(dt.Rows[j]["hetongqiankuan"].ToString()) / 10000).ToString("#0.0")));

                    msg.Add("</a>");
                }
            }
            item.Add(msg);
            item.Add(ProjectName);
            item.Add(SumChenjiaojia);
            item.Add(SumHetonghuikuan);
            item.Add(SumHetongqiankuan);

            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchERPSellHouseSignedAnlysisReport()
        {           //累计签约情况表
            DataTable dt = new com.hiooy.ERPhouse.WS_ERPSellHouseAnalysis().ERPSellHouseSignedAnlysisReport("VYbSBDuFOPVd3452334222");
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> projectName = new List<object>();
            List<object> Signed = new List<object>();
            List<object> SignedDealAmount = new List<object>();
            List<object> Purchase = new List<object>();
            List<object> SignedPersent = new List<object>();
            int PurchaseTemp = 0;
            string[] projectNames = { "森邻四季", "鼎湖", "总统公馆", "大旺" };

            if (dt.Rows.Count != 0)
            {

                msg.Add("<div class=\"ui-block-b treven\" style='width:25%;'><span>项目名称</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:20%;'><span>签约数</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:35%;'><span>签约额(万元)</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:20%;'><span>签约率</span></div>");

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:25%;'><span>" + projectNames[j] + "</span></div>");
                    projectName.Add(dt.Rows[j]["projectName"]);

                    msg.Add("<div class=\"ui-block-d treven\" style='width:20%;'><span>" + dt.Rows[j]["Signed"] + "</span></div>");
                    Signed.Add(int.Parse(dt.Rows[j]["Signed"].ToString()));
                    msg.Add("<div class=\"ui-block-d treven\" style='width:35%;'><span>" + (float.Parse((dt.Rows[j]["SignedDealAmount"].ToString())) / 10000).ToString("#0.0") + "</span></div>");
                    SignedDealAmount.Add((float.Parse(dt.Rows[j]["SignedDealAmount"].ToString())));
                    PurchaseTemp = (int)(float.Parse(dt.Rows[j]["Signed"].ToString()) / (float.Parse(dt.Rows[j]["Qianyuelv"].ToString())));
                    //msg.Add("<div class=\"ui-block-d treven\" style='width:20%;'><span>" + PurchaseTemp + "</span></div>");
                    Purchase.Add(PurchaseTemp);
                    msg.Add("<div class=\"ui-block-d treven\" style='width:20%;'><span>" + float.Parse(dt.Rows[j]["Qianyuelv"].ToString()) * 100 + " % " + "</span></div>");
                    SignedPersent.Add(dt.Rows[j]["Qianyuelv"]);
                    msg.Add("</a>");
                }
            }
            item.Add(msg);
            item.Add(projectName);
            item.Add(Signed);
            item.Add(SignedDealAmount);
            item.Add(Purchase);
            item.Add(SignedPersent);

            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchERPSellHousePurchaseDateReport()
        {               //地产认购回款日报表
            string dateStart = Request["dateStart"];
            string dateEnd = Request["dateEnd"];
            DataTable dt = new com.hiooy.ERPhouse.WS_ERPSellHouseAnalysis().ERPSellHousePurchaseDateReport("VYbSBDuFOPVd3452334222", dateStart, dateEnd);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> ProjectID = new List<object>();
            // List<object> ProjectName = new List<object>();
            List<object> Purchase = new List<object>();
            List<object> PurchaseDealAmount = new List<object>();
            List<object> projectName = new List<object>();
            string[] projectNames = { "肇庆大旺", "肇庆鼎湖", "番禺又一城", "森邻四季" };



            if (dt.Rows.Count != 0)
            {
                msg.Add("<div class=\"ui-block-b treven\" style='width:45%;'><span>项目名称</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:15%;'><span>认购</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:40%;'><span>成交额(万元)</span></div>");
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<a onclick=\"forward(this)\" id=\"" + dt.Rows[j]["ProjectID"] + "\">");
                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:45%;'><span>" + dt.Rows[j]["ProjectName"] + "</span></div>");
                    projectName.Add(projectNames[j]);
                    msg.Add("<div class=\"ui-block-e treven\" style='width:15%;'><span>" + dt.Rows[j]["Purchase"] + "</span></div>");
                    Purchase.Add(float.Parse(dt.Rows[j]["Purchase"].ToString()));
                    msg.Add("<div class=\"ui-block-e treven\" style='width:40%;'><span>" + (float.Parse((dt.Rows[j]["PurchaseDealAmount"].ToString())) / 10000).ToString("#0.0") + "</span></div>");
                    PurchaseDealAmount.Add(float.Parse(dt.Rows[j]["PurchaseDealAmount"].ToString()));
                    ProjectID.Add(dt.Rows[j]["ProjectID"].ToString());
                    msg.Add("</a>");
                }
            }
            item.Add(msg);
            item.Add(ProjectID);
            item.Add(projectName);
            item.Add(Purchase);
            item.Add(PurchaseDealAmount);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchERPSellHousePurchaseDateDetailReport()
        {               //地产认购回款日报表（详细）        
            string prjNo = Request["projectNo"];
            string dateStart = Request["dateStart"];
            string dateEnd = Request["dateEnd"];
            DataTable dt = new com.hiooy.ERPhouse.WS_ERPSellHouseAnalysis().ERPSellHousePurchaseDateDetailReport("VYbSBDuFOPVd3452334222", prjNo, dateStart, dateEnd);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> BuildingName = new List<object>();
            List<object> Purchase = new List<object>();
            List<object> BuildingDealAmount = new List<object>();
            if (dt.Rows.Count != 0)
            {
                msg.Add("<div class=\"ui-block-b treven\" style='width:40%;'><span>楼栋</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:20%;'><span>认购</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:40%;'><span>成交额（万元）</span></div>");
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:40%;'><span>" + dt.Rows[j]["BuildingName"] + "</span></div>");
                    BuildingName.Add(dt.Rows[j]["BuildingName"].ToString());
                    msg.Add("<div class=\"ui-block-c treven\" style='width:20%;'><span>" + dt.Rows[j]["Purchase"] + "</span></div>");
                    Purchase.Add(float.Parse(dt.Rows[j]["Purchase"].ToString()));
                    msg.Add("<div class=\"ui-block-d treven\" style='width:40%;'><span>" + (float.Parse(dt.Rows[j]["BuildingDealAmount"].ToString()) / 10000).ToString("#0.00") + "</span></div>");
                    BuildingDealAmount.Add(float.Parse(dt.Rows[j]["BuildingDealAmount"].ToString()));
                }
            }
            item.Add(msg);
            item.Add(BuildingName);
            item.Add(Purchase);
            item.Add(BuildingDealAmount);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }


        #endregion

        #region 地产合同完成情况表（财务）
        public void SearchERPCOSTComConCompleteReport()
        {

            DataTable dt = new com.hiooy.ERPpromise.WS_ERPPromiseCostAnalysis().ERPCOSTComConCompleteReport("VYbSBDuFOPVd3452334222");
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> projectCompanyName = new List<object>();
            List<object> SignedNum = new List<object>();
            List<object> ContractTotalPrice = new List<object>();
            List<object> CompletedPrice = new List<object>();
            string[] ProjectCompanyName = { "鼎湖雅逸", "高新区雅逸", "海印股份", "展贸城", "番禺又一城", "鼎湖又一城", "大旺又一城", "茂名海悦", "四会阳光", "上海海印", "茂名大厦", "珠海澳杰", "总统雅逸" };

            if (dt.Rows.Count != 0)
            {

                msg.Add("<div class=\"ui-block-b treven\" style='width:37%;'><span>项目名称</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:18%;'><span>合同数</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:23%;'><span>总金额</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:22%;'><span>已付款</span></div>");

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<a onclick=\"forward(this)\" id=\"" + dt.Rows[j]["ProjectCompanyID"] + "\">");
                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:37%;'><span>" + ProjectCompanyName[j] + "</span></div>");
                    projectCompanyName.Add(ProjectCompanyName[j]);
                    msg.Add("<div class=\"ui-block-c treven\" style='width:18%;'><span>" + dt.Rows[j]["SignedNum"] + "</span></div>");
                    SignedNum.Add(float.Parse(dt.Rows[j]["SignedNum"].ToString()));
                    msg.Add("<div class=\"ui-block-d treven\" style='width:23%;'><span>" + (float.Parse(dt.Rows[j]["ContractTotalPrice"].ToString()) / 10000).ToString("#0.0") + "</span></div>");
                    ContractTotalPrice.Add(float.Parse((float.Parse(dt.Rows[j]["ContractTotalPrice"].ToString()) / 10000).ToString("#0.00")));
                    if (dt.Rows[j]["CompletedPrice"].Equals(""))
                    {
                        dt.Rows[j]["CompletedPrice"] = "0";
                    }
                    msg.Add("<div class=\"ui-block-e treven\" style='width:22%;'><span>" + (float.Parse(dt.Rows[j]["CompletedPrice"].ToString()) / 10000).ToString("#0.0") + "</span></div>");
                    CompletedPrice.Add(float.Parse((double.Parse(dt.Rows[j]["CompletedPrice"].ToString()) / 10000).ToString("#0.00")));
                    msg.Add("</a>");

                }
            }
            item.Add(msg);
            item.Add(projectCompanyName);
            item.Add(SignedNum);
            item.Add(ContractTotalPrice);
            item.Add(CompletedPrice);

            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchERPCOSTComPrjConCompleteReport()
        {
            string ComID = Request["ComID"];
            DataTable dt = new com.hiooy.ERPpromise.WS_ERPPromiseCostAnalysis().ERPCOSTComPrjConCompleteReport("VYbSBDuFOPVd3452334222", ComID);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> ProjectCompanyName = new List<object>();
            List<object> SignedNum = new List<object>();
            List<object> ContractTotalPrice = new List<object>();
            List<object> CompletedPrice = new List<object>();
            List<object> ProjectName = new List<object>();

            if (dt.Rows.Count != 0)
            {

                msg.Add("<div class=\"ui-block-b treven\" style='width:35%;'><span>项目名称</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>数量</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:25%;'><span>合同金额</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:25%;'><span>已付款</span></div>");
                ProjectCompanyName.Add(dt.Rows[0]["ProjectCompanyName"]);

                for (int j = 0; j < dt.Rows.Count; j++)
                {

                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:35%;'><span>" + dt.Rows[j]["ProjectName"] + "</span></div>");
                    ProjectName.Add(dt.Rows[j]["ProjectName"].ToString());
                    msg.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>" + dt.Rows[j]["SignedNum"] + "</span></div>");
                    SignedNum.Add(float.Parse(dt.Rows[j]["SignedNum"].ToString()));
                    msg.Add("<div class=\"ui-block-d treven\" style='width:25%;'><span>" + (float.Parse(dt.Rows[j]["ContractTotalPrice"].ToString()) / 10000).ToString("#0.0") + "</span></div>");
                    ContractTotalPrice.Add(float.Parse((float.Parse(dt.Rows[j]["ContractTotalPrice"].ToString()) / 10000).ToString("#0.00")));
                    if (dt.Rows[j]["CompletedPrice"].Equals(""))
                    {
                        dt.Rows[j]["CompletedPrice"] = "0";
                    }
                    msg.Add("<div class=\"ui-block-e treven\" style='width:25%;'><span>" + (float.Parse(dt.Rows[j]["CompletedPrice"].ToString()) / 10000).ToString("#0.0") + "</span></div>");
                    CompletedPrice.Add(float.Parse((double.Parse(dt.Rows[j]["CompletedPrice"].ToString()) / 10000).ToString("#0.00")));

                }
            }
            item.Add(msg);
            item.Add(ProjectCompanyName);
            item.Add(SignedNum);
            item.Add(ContractTotalPrice);
            item.Add(CompletedPrice);
            item.Add(ProjectName);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        #endregion

        #region 地产合同执行情况表（合同）
        public void SearchERPCOSTComConExecReport()
        {
            DataTable dt = new com.hiooy.ERPpromise.WS_ERPPromiseCostAnalysis().ERPCOSTAllPrjConExecReport("VYbSBDuFOPVd3452334222");
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> projectCompanyName = new List<object>();
            List<object> SignedNum = new List<object>();
            List<object> ContractReviseNum = new List<object>();
            List<object> ContractChangeNum = new List<object>();
            List<object> ContractSettlementNum = new List<object>();
            string[] ProjectCompanyName = { "茂名海悦", "鼎湖又一城", "大旺又一城", "番禺又一城", "总统雅逸", "茂名大厦", "珠海澳杰", "海印股份", "鼎湖雅逸", "四会阳光达", "高新区雅逸", "上海房地产", "展贸城" };

            if (dt.Rows.Count != 0)
            {

                msg.Add("<div class=\"ui-block-b treven\" style='width:30%;'><span>项目名称</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:19%;'><span>签约</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:17%;'><span>修订</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:17%;'><span>结算</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:17%;'><span>签证</span></div>");

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<a onclick=\"forward(this)\" id=\"" + dt.Rows[j]["ProjectCompanyID"] + "\">");
                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:30%;'><span>" + ProjectCompanyName[j] + "</span></div>");
                    projectCompanyName.Add(ProjectCompanyName[j]);
                    msg.Add("<div class=\"ui-block-c treven\" style='width:19%;'><span>" + dt.Rows[j]["SignedNum"] + "</span></div>");
                    SignedNum.Add(float.Parse(dt.Rows[j]["SignedNum"].ToString()));
                    msg.Add("<div class=\"ui-block-d treven\" style='width:17%;'><span>" + dt.Rows[j]["ContractReviseNum"] + "</span></div>");
                    ContractReviseNum.Add(float.Parse(dt.Rows[j]["ContractReviseNum"].ToString()));
                    msg.Add("<div class=\"ui-block-d treven\" style='width:17%;'><span>" + dt.Rows[j]["ContractSettlementNum"] + "</span></div>");
                    ContractSettlementNum.Add(float.Parse(dt.Rows[j]["ContractSettlementNum"].ToString()));
                    msg.Add("<div class=\"ui-block-d treven\" style='width:17%;'><span>" + dt.Rows[j]["ContractChangeNum"] + "</span></div>");
                    ContractChangeNum.Add(float.Parse(dt.Rows[j]["ContractChangeNum"].ToString()));
                    msg.Add("</a>");

                }
            }
            item.Add(msg);
            item.Add(projectCompanyName);
            item.Add(SignedNum);
            item.Add(ContractReviseNum);
            item.Add(ContractChangeNum);
            item.Add(ContractSettlementNum);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchERPCOSTComPrjConExecReport()
        {
            string ComID = Request["ComID"];
            DataTable dt = new com.hiooy.ERPpromise.WS_ERPPromiseCostAnalysis().ERPCOSTPrjConExecReport("VYbSBDuFOPVd3452334222", ComID);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> ProjectName = new List<object>();
            List<object> SignedNum = new List<object>();
            List<object> ContractReviseNum = new List<object>();
            List<object> ContractChangeNum = new List<object>();
            List<object> ContractSettlementNum = new List<object>();
            List<object> ProjectCompanyName = new List<object>();

            if (dt.Rows.Count != 0)
            {

                msg.Add("<div class=\"ui-block-b treven\" style='width:40%;'><span>产品名称</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>签约</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:15%;'><span>修订</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:15%;'><span>结算</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:15%;'><span>签证</span></div>");
                ProjectCompanyName.Add(dt.Rows[0]["ProjectCompanyName"].ToString());
                for (int j = 0; j < dt.Rows.Count; j++)
                {

                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:40%;'><span>" + dt.Rows[j]["ProjectName"] + "</span></div>");
                    ProjectName.Add(dt.Rows[j]["ProjectName"].ToString());
                    msg.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>" + dt.Rows[j]["SignedNum"] + "</span></div>");
                    SignedNum.Add(float.Parse(dt.Rows[j]["SignedNum"].ToString()));
                    msg.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>" + dt.Rows[j]["ContractReviseNum"] + "</span></div>");
                    ContractReviseNum.Add(float.Parse(dt.Rows[j]["ContractReviseNum"].ToString()));
                    msg.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>" + dt.Rows[j]["ContractSettlementNum"] + "</span></div>");
                    ContractSettlementNum.Add(float.Parse(dt.Rows[j]["ContractSettlementNum"].ToString()));
                    msg.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>" + dt.Rows[j]["ContractChangeNum"] + "</span></div>");
                    ContractChangeNum.Add(float.Parse(dt.Rows[j]["ContractChangeNum"].ToString()));
                }
            }
            item.Add(msg);
            item.Add(ProjectName);
            item.Add(SignedNum);
            item.Add(ContractReviseNum);
            item.Add(ContractChangeNum);
            item.Add(ContractSettlementNum);
            item.Add(ProjectCompanyName);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }
        #endregion

        #region 地产目标成本与动态成本情况表（成本）
        public void SearchERPAIM2DynCostReport()
        {

            DataTable dt = new com.hiooy.ERPpromise.WS_ERPPromiseCostAnalysis().ERPTOTALCost2TotalDynCost("VYbSBDuFOPVd3452334222");
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> projectCompanyName = new List<object>();
            List<object> TotalAIM = new List<object>();
            List<object> TotalSOFARHASAMT = new List<object>();
            List<object> TotalSOFARTOAMT = new List<object>();
            string[] ProjectCompanyName = { "茂名海悦", "肇庆大旺", "肇庆鼎湖", "番禺又一城", "四会阳光达", "展贸城" };

            if (dt.Rows.Count != 0)
            {

                msg.Add("<div class=\"ui-block-b treven\" style='width:30%;'><span>公司</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:25%;'><span>目标成本</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:23%;'><span>动态成本</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:22%;'><span>差异</span></div>");

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<a onclick=\"forward(this)\" id=\"" + dt.Rows[j]["ProjectCompanyID"] + "\">");
                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:30%;'><span>" + ProjectCompanyName[j] + "</span></div>");
                    projectCompanyName.Add(ProjectCompanyName[j]);
                    msg.Add("<div class=\"ui-block-d treven\" style='width:25%;'><span>" + (float.Parse(dt.Rows[j]["TotalAIM"].ToString()) / 10000).ToString("#0.0") + "</span></div>");
                    TotalAIM.Add(float.Parse((float.Parse(dt.Rows[j]["TotalAIM"].ToString()) / 10000).ToString("#0.00")));
                    if (dt.Rows[j]["TotalSOFARHASAMT"].Equals(""))
                    {
                        dt.Rows[j]["TotalSOFARHASAMT"] = "0";
                    }
                    msg.Add("<div class=\"ui-block-d treven\" style='width:23%;'><span>" + (float.Parse(dt.Rows[j]["TotalSOFARHASAMT"].ToString()) / 10000).ToString("#0.0") + "</span></div>");
                    TotalSOFARHASAMT.Add(float.Parse((float.Parse(dt.Rows[j]["TotalSOFARHASAMT"].ToString()) / 10000).ToString("#0.00")));
                    if (dt.Rows[j]["TotalSOFARTOAMT"].Equals(""))
                    {
                        dt.Rows[j]["TotalSOFARTOAMT"] = "0";
                    }
                    msg.Add("<div class=\"ui-block-e treven\" style='width:22%;'><span>" + (float.Parse(dt.Rows[j]["TotalSOFARTOAMT"].ToString()) / 10000).ToString("#0.0") + "</span></div>");
                    TotalSOFARTOAMT.Add(float.Parse((double.Parse(dt.Rows[j]["TotalSOFARTOAMT"].ToString()) / 10000).ToString("#0.00")));
                    msg.Add("</a>");

                }
            }
            item.Add(msg);
            item.Add(projectCompanyName);
            item.Add(TotalAIM);
            item.Add(TotalSOFARHASAMT);
            item.Add(TotalSOFARTOAMT);

            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchERPAIM2DynCostByProjectReport()
        {
            string ComID = Request["ComID"];
            DataTable dt = new com.hiooy.ERPpromise.WS_ERPPromiseCostAnalysis().ERPCOSTAIM2DynCost("VYbSBDuFOPVd3452334222", ComID);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> ProjectName = new List<object>();
            List<object> AIM = new List<object>();
            List<object> SOFARHASAMT = new List<object>();
            List<object> SOFARTOAMT = new List<object>();
            List<object> ProjectCompanyName = new List<object>();
            if (dt.Rows.Count != 0)
            {

                msg.Add("<div class=\"ui-block-b treven\" style='width:30%;'><span>项目</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:25%;'><span>目标成本</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:23%;'><span>动态成本</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:22%;'><span>差异</span></div>");
                ProjectCompanyName.Add(dt.Rows[0]["ProjectCompanyName"]);

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:30%;'><span>" + dt.Rows[j]["ProjectName"] + "</span></div>");
                    ProjectName.Add(dt.Rows[j]["ProjectName"].ToString());
                    msg.Add("<div class=\"ui-block-d treven\" style='width:25%;'><span>" + (float.Parse(dt.Rows[j]["AIM"].ToString()) / 10000).ToString("#0.0") + "</span></div>");
                    AIM.Add(float.Parse((double.Parse(dt.Rows[j]["AIM"].ToString()) / 10000).ToString("#0.00")));
                    if (dt.Rows[j]["SOFARHASAMT"].Equals(""))
                    {
                        dt.Rows[j]["SOFARHASAMT"] = "0";
                    }
                    msg.Add("<div class=\"ui-block-d treven\" style='width:23%;'><span>" + (float.Parse(dt.Rows[j]["SOFARHASAMT"].ToString()) / 10000).ToString("#0.0") + "</span></div>");
                    SOFARHASAMT.Add(float.Parse((float.Parse(dt.Rows[j]["SOFARHASAMT"].ToString()) / 10000).ToString("#0.00")));
                    if (dt.Rows[j]["SOFARTOAMT"].Equals(""))
                    {
                        dt.Rows[j]["SOFARTOAMT"] = "0";
                    }
                    msg.Add("<div class=\"ui-block-e treven\" style='width:22%;'><span>" + (float.Parse(dt.Rows[j]["SOFARTOAMT"].ToString()) / 10000).ToString("#0.0") + "</span></div>");
                    SOFARTOAMT.Add(float.Parse((double.Parse(dt.Rows[j]["SOFARTOAMT"].ToString()) / 10000).ToString("#0.00")));

                }
            }
            item.Add(msg);
            item.Add(ProjectCompanyName);
            item.Add(ProjectName);
            item.Add(AIM);
            item.Add(SOFARHASAMT);
            item.Add(SOFARTOAMT);

            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        #endregion

        #region 商联

        public void SearchSLTradingWaterReportByDate()
        {
            string date = Request["date"];
            result lt = new result();
            DataTable dt = new com.hiooy.SL.WS_SLTradingWaterAnalysis().SLTadingWaterAnalysisDayReport("VYbSBDuFOPVd3452222", date);

            float totalXSE = 0;
            int totalKeDanShu = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:35%;'><span>交易日期</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:40%;'><span>交易金额</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:25%;'><span>交易笔数</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:35%;'><span>" + dt.Rows[j]["交易日期"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:40%;'><span>" + dt.Rows[j]["交易金额"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:25%;'><span>" + dt.Rows[j]["交易笔数"] + "</span></div>";
                    totalXSE += float.Parse(dt.Rows[j]["交易金额"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["交易笔数"].ToString());

                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:35%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:40%;'><span>" + totalXSE + "</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:25%;'><span>" + totalKeDanShu + "</span></div>";

            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchSLTradingWaterReportByMonth()
        {
            string year = Request["year"];
            string month = Request["month"];
            result lt = new result();
            DataTable dt = new com.hiooy.SLtest.WS_SLTradingWaterAnalysis().SLTadingWaterAnalysisMonthReport("VYbSBDuFOPVd3452222", year, month);

            float totalXSE = 0;
            int totalKeDanShu = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:35%;'><span>交易日期</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:40%;'><span>交易金额</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:25%;'><span>交易笔数</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:35%;'><span>" + dt.Rows[j]["交易日期"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:40%;'><span>" + dt.Rows[j]["交易金额"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:25%;'><span>" + dt.Rows[j]["交易笔数"] + "</span></div>";
                    totalXSE += float.Parse(dt.Rows[j]["交易金额"].ToString());
                    totalKeDanShu += int.Parse(dt.Rows[j]["交易笔数"].ToString());

                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:35%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:40%;'><span>" + totalXSE + "</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:25%;'><span>" + totalKeDanShu + "</span></div>";

            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchSLTradingWaterTrendByMonth()
        {
            string year = Request["year"];
            string month = Request["month"];
            List<object> item = new List<object>();
            List<object> sale = new List<object>();
            List<object> date = new List<object>();
            DataTable dt = new com.hiooy.SLtest.WS_SLTradingWaterAnalysis().SLTadingWaterAnalysisMonthReport("VYbSBDuFOPVd3452222", year, month);


            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    sale.Add(float.Parse(dt.Rows[j]["交易金额"].ToString()));
                    date.Add(j + 1);
                }

            }
            item.Add(sale);
            item.Add(date);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        #endregion

        #region 体育会

        public void SearchTiyuhuiReport()
        {
            string date = Request["date"];
            result lt = new result();
            DataTable dt = new com.hiooy.tiyuhui.WS_TiyuhuiAnalysis().TYHAnalysisDayReport("VYbSBDuFOPVd3452222", date);

            float totalXSE = 0;
            float totalnum = 0;

            if (dt.Rows.Count != 0)
            {
                lt.success = true;
                lt.msg += "<div class=\"ui-block-b treven\" style='width:35%;'><span>类别</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:40%;'><span>销售额</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:25%;'><span>数量</span></div>";
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    lt.msg += "<div class=\"ui-block-b trodd\"  style='width:35%;'><span>" + dt.Rows[j]["类别"] + "</span></div>";
                    lt.msg += "<div class=\"ui-block-e treven\" style='width:40%;'><span>" + float.Parse(dt.Rows[j]["销售额"].ToString()).ToString("#0.00") + "</span></div>";
                    lt.msg += "<div class=\"ui-block-c treven\" style='width:25%;'><span>" + float.Parse(dt.Rows[j]["数量"].ToString()) + "</span></div>";
                    totalXSE += float.Parse(dt.Rows[j]["销售额"].ToString());
                    totalnum += float.Parse(dt.Rows[j]["数量"].ToString());

                }
                lt.msg += "<div class=\"ui-block-b trodd\"  style='width:35%;'><span>" + "合计：</span></div>";
                lt.msg += "<div class=\"ui-block-e treven\" style='width:40%;'><span>" + totalXSE + "</span></div>";
                lt.msg += "<div class=\"ui-block-c treven\" style='width:25%;'><span>" + totalnum + "</span></div>";

            }
            else
                lt.success = false;
            DataContractJsonSerializer json = new DataContractJsonSerializer(lt.GetType());
            json.WriteObject(Response.OutputStream, lt);
        }

        public void SearchTiyuhuiWeekReport()
        {
            result lt = new result();
            DataTable dt = new com.hiooy.tiyuhui.WS_TiyuhuiAnalysis().TYHAnylysisWeeklyReport("VYbSBDuFOPVd3452222");
            List<object> item = new List<object>();

            List<object> msg = new List<object>();
            List<object> SaleType = new List<object>();
            List<object> ThisWeek = new List<object>();
            List<object> LastWeek = new List<object>();
            List<object> TBIncrease = new List<object>();

            float thisweekXSE = 0;
            float lastweekXSE = 0;
            float increase = 0;

            if (dt.Rows.Count != 0)
            {
                msg.Add("<div class=\"ui-block-b treven\" style='width:30%;'><span>类别</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:24%;'><span>本周</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:24%;'><span>上周</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:22%;'><span>同比</span></div>");

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:30%;'><span>" + dt.Rows[j]["类别"] + "</span></div>");
                    //string type = dt.Rows[j]["类别"].ToString() +"/t"+ dt.Rows[j]["同比增长"].ToString();
                    SaleType.Add(dt.Rows[j]["类别"]);

                    msg.Add("<div class=\"ui-block-e treven\" style='width:24%;'><span>" + float.Parse(dt.Rows[j]["本周销售"].ToString()).ToString("#0.0") + "</span></div>");
                    ThisWeek.Add(float.Parse((float.Parse(dt.Rows[j]["本周销售"].ToString())).ToString("#0.0")));

                    msg.Add("<div class=\"ui-block-c treven\" style='width:24%;'><span>" + float.Parse(dt.Rows[j]["上周销售"].ToString()).ToString("#0.0") + "</span></div>");
                    LastWeek.Add(float.Parse((float.Parse(dt.Rows[j]["上周销售"].ToString())).ToString("#0.0")));

                    msg.Add("<div class=\"ui-block-c treven\" style='width:22%;'><span>" + dt.Rows[j]["同比增长"] + "</span></div>");
                    TBIncrease.Add(dt.Rows[j]["同比增长"].ToString());
                    thisweekXSE += float.Parse(dt.Rows[j]["本周销售"].ToString());
                    lastweekXSE += float.Parse(dt.Rows[j]["上周销售"].ToString());
                    string[] spilt = dt.Rows[j]["同比增长"].ToString().Split(new Char[] { '%' });
                    increase += float.Parse(spilt[0]);
                }
                msg.Add("<div class=\"ui-block-b trodd\"  style='width:30%;'><span>" + "合计：</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:24%;'><span>" + thisweekXSE + "</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:24%;'><span>" + lastweekXSE + "</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:22%;'><span>" + (increase / dt.Rows.Count).ToString("#0.0") + "%</span></div>");


            }
            item.Add(msg);
            item.Add(SaleType);
            item.Add(ThisWeek);
            item.Add(LastWeek);
            item.Add(TBIncrease);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchTiyuhuiTrendByMonth()
        {
            string year = Request["year"];
            string month = Request["month"];
            List<object> item = new List<object>();
            List<object> sale = new List<object>();
            List<object> count = new List<object>();
            List<object> date = new List<object>();
            DataTable dt = new com.hiooy.tiyuhui.WS_TiyuhuiAnalysis().TYHAnylysisTrendByMonth("VYbSBDuFOPVd3452222", year, month);


            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    sale.Add(float.Parse(dt.Rows[j]["销售额"].ToString()));
                    count.Add(float.Parse(dt.Rows[j]["数量"].ToString()));
                    date.Add(j + 1);
                }

            }
            item.Add(sale);
            item.Add(date);
            item.Add(count);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        #endregion

        #region 院线电影
        public void SearchDWYXReceiveWeekReport()
        {
            string Start = Request["dateStart"];
            string End = Request["dateEnd"];
            string nowDate = Start.ToString().Split(' ')[0];
            System.Diagnostics.Trace.WriteLine("start" + Start);
            System.Diagnostics.Trace.WriteLine("nowDate" + nowDate);
            DateTime now = Convert.ToDateTime(nowDate);
            string preStart = now.AddDays(-6).ToShortDateString();
            string preEnd = now.AddDays(0).ToShortDateString();
            string preStartYear = preStart.Split('/')[0];
            string preStartMonth = preStart.Split('/')[1];
            string preStartDay = preStart.Split('/')[2];
            string preEndYear = preEnd.Split('/')[0];
            string preEndMonth = preEnd.Split('/')[1];
            string preEndDay = preEnd.Split('/')[2];
            if (int.Parse(preStartMonth) < 10)
            {
                preStartMonth = "0" + preStartMonth;
            }
            if (int.Parse(preStartDay) < 10)
            {
                preStartDay = "0" + preStartDay;
            }
            if (int.Parse(preEndMonth) < 10)
            {
                preEndMonth = "0" + preEndMonth;
            }
            if (int.Parse(preEndDay) < 10)
            {
                preEndDay = "0" + preEndDay;
            }
            preStart = preStartYear + "-" + preStartMonth + "-" + preStartDay + " " + "0600";
            preEnd = preEndYear + "-" + preEndMonth + "-" + preEndDay + " " + "0600";


            DataTable dt = new com.hiooy.tiyuhui.WS_TiyuhuiAnalysis().DWYXReceiveWeekReport("VYbSBDuFOPVd3452222", Start, End);

            DataTable predt = new com.hiooy.tiyuhui.WS_TiyuhuiAnalysis().DWYXReceiveWeekReport("VYbSBDuFOPVd3452222", preStart, preEnd);
            List<object> item = new List<object>();
            List<object> msg1 = new List<object>();
            List<object> msg2 = new List<object>();
            List<object> showdate = new List<object>();
            List<object> changciNum = new List<object>();
            List<object> CumstomerNum = new List<object>();
            List<object> Tongkan = new List<object>();
            List<object> NewAddNum = new List<object>();
            List<object> BoxOffice = new List<object>();
            List<object> XiaoMB = new List<object>();
            List<object> MemberAddMoney = new List<object>();
            List<object> preShowdate = new List<object>();
            List<object> preBoxOffice = new List<object>();
            List<object> preMemberAddMoney = new List<object>();
            int sumChangciNum = 0;
            int sumCumstomerNum = 0;
            int sumTongkan = 0;
            int sumNewAddNum = 0;
            float sumBoxOffice = 0;
            int sumXiaoMB = 0;
            int sumMemberAddMoney = 0;

            if (dt.Rows.Count != 0)
            {
                msg1.Add("<div class=\"ui-block-b treven\" style='width:25%;'><span>日期</span></div>");
                msg1.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>场次</span></div>");
                msg1.Add("<div class=\"ui-block-d treven\" style='width:15%;'><span>人数</span></div>");
                msg1.Add("<div class=\"ui-block-e treven\" style='width:20%;'><span>通看</span></div>");
                msg1.Add("<div class=\"ui-block-e treven\" style='width:25%;'><span>票房</span></div>");
                msg2.Add("<div class=\"ui-block-b treven\" style='width:25%;'><span>日期</span></div>");
                msg2.Add("<div class=\"ui-block-e treven\" style='width:25%;'><span>新增会员</span></div>");
                msg2.Add("<div class=\"ui-block-e treven\" style='width:25%;'><span>小卖部</span></div>");
                msg2.Add("<div class=\"ui-block-e treven\" style='width:25%;'><span>会员充值</span></div>");
                try
                {
                    for (int j = 0; j < dt.Rows.Count; j++)
                    {

                        msg1.Add("<div class=\"ui-block-b trodd\"  style='width:25%;'><span>" + dt.Rows[j]["showdate"].ToString().Split(' ')[0].Substring(5) + "</span></div>");
                        showdate.Add(dt.Rows[j]["showdate"].ToString().Split(' ')[0]);
                        msg1.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>" + dt.Rows[j]["changciNum"] + "</span></div>");
                        changciNum.Add(float.Parse(dt.Rows[j]["changciNum"].ToString()));
                        msg1.Add("<div class=\"ui-block-d treven\" style='width:15%;'><span>" + dt.Rows[j]["CumstomerNum"] + "</span></div>");
                        CumstomerNum.Add(float.Parse(dt.Rows[j]["CumstomerNum"].ToString()));
                        msg1.Add("<div class=\"ui-block-e treven\" style='width:20%;'><span>" + (((string)dt.Rows[j]["Tongkan"] == "") ? "0" : dt.Rows[j]["Tongkan"].ToString()) + "</span></div>");
                        Tongkan.Add((((string)dt.Rows[j]["Tongkan"] == "") ? "0" : dt.Rows[j]["Tongkan"].ToString()));
                        msg1.Add("<div class=\"ui-block-e treven\" style='width:25%;'><span>" + dt.Rows[j]["BoxOffice"] + "</span></div>");
                        BoxOffice.Add(float.Parse(dt.Rows[j]["BoxOffice"].ToString()));


                        msg2.Add("<div class=\"ui-block-b trodd\"  style='width:25%;'><span>" + dt.Rows[j]["showdate"].ToString().Split(' ')[0].Substring(5) + "</span></div>");
                        showdate.Add(dt.Rows[j]["showdate"].ToString().Split(' ')[0]);

                        msg2.Add("<div class=\"ui-block-e treven\" style='width:25%;'><span>" + dt.Rows[j]["NewAddNum"] + "</span></div>");
                        if (dt.Rows[j]["NewAddNum"] == "" || dt.Rows[j]["NewAddNum"] == null)
                        {
                            NewAddNum.Add(0);
                        }
                        else
                        {
                            NewAddNum.Add(float.Parse(dt.Rows[j]["NewAddNum"].ToString()));
                        }

                        msg2.Add("<div class=\"ui-block-e treven\" style='width:25%;'><span>" + dt.Rows[j]["XiaoMB"] + "</span></div>");

                        if (dt.Rows[j]["XiaoMB"] == "" || dt.Rows[j]["XiaoMB"] == null)
                        {
                            XiaoMB.Add(0);
                        }
                        else
                        {
                            XiaoMB.Add(float.Parse(dt.Rows[j]["XiaoMB"].ToString()));

                        }

                        msg2.Add("<div class=\"ui-block-e treven\" style='width:25%;'><span>" + dt.Rows[j]["MemberAddMoney"] + "</span></div>");

                        if (dt.Rows[j]["MemberAddMoney"] == "" || dt.Rows[j]["MemberAddMoney"] == null)
                        {
                            MemberAddMoney.Add(0);
                        }
                        else
                        {
                            MemberAddMoney.Add(float.Parse(dt.Rows[j]["MemberAddMoney"].ToString()));

                        }
                        sumChangciNum += int.Parse((((string)dt.Rows[j]["changciNum"] == "") ? "0" : dt.Rows[j]["changciNum"].ToString()));
                        sumCumstomerNum += int.Parse((((string)dt.Rows[j]["CumstomerNum"] == "") ? "0" : dt.Rows[j]["CumstomerNum"].ToString()));
                        sumTongkan += int.Parse((((string)dt.Rows[j]["Tongkan"] == "") ? "0" : dt.Rows[j]["Tongkan"].ToString()));
                        sumBoxOffice += float.Parse((((string)dt.Rows[j]["BoxOffice"] == "") ? "0" : dt.Rows[j]["BoxOffice"].ToString()));

                        sumNewAddNum += int.Parse((((string)dt.Rows[j]["NewAddNum"] == "") ? "0" : dt.Rows[j]["NewAddNum"].ToString()));
                        sumXiaoMB += int.Parse((((string)dt.Rows[j]["XiaoMB"] == "") ? "0" : dt.Rows[j]["XiaoMB"].ToString()));
                        sumMemberAddMoney += int.Parse((((string)dt.Rows[j]["MemberAddMoney"] == "") ? "0" : dt.Rows[j]["MemberAddMoney"].ToString()));

                    }

                    msg1.Add("<div class=\"ui-block-b treven\" style='width:25%;'><span>合计</span></div>");
                    msg1.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>" + sumChangciNum + "</span></div>");
                    msg1.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>" + sumCumstomerNum + "</span></div>");
                    msg1.Add("<div class=\"ui-block-c treven\" style='width:20%;'><span>" + sumTongkan + "</span></div>");
                    msg1.Add("<div class=\"ui-block-c treven\" style='width:25%;'><span>" + sumBoxOffice + "</span></div>");
                    msg2.Add("<div class=\"ui-block-b treven\" style='width:25%;'><span>合计</span></div>");
                    msg2.Add("<div class=\"ui-block-c treven\" style='width:25%;'><span>" + sumNewAddNum + "</span></div>");
                    msg2.Add("<div class=\"ui-block-c treven\" style='width:25%;'><span>" + sumXiaoMB + "</span></div>");
                    msg2.Add("<div class=\"ui-block-c treven\" style='width:25%;'><span>" + sumMemberAddMoney + "</span></div>");

                    if (predt.Rows.Count != 0)
                    {
                        sumChangciNum = 0;
                        sumCumstomerNum = 0;
                        sumTongkan = 0;
                        sumNewAddNum = 0;
                        sumBoxOffice = 0;
                        sumXiaoMB = 0;
                        sumMemberAddMoney = 0;
                        for (int j = 0; j < predt.Rows.Count; j++)
                        {
                            preShowdate.Add(predt.Rows[j]["showdate"].ToString().Split(' ')[0]);
                            preBoxOffice.Add(float.Parse(predt.Rows[j]["BoxOffice"].ToString()));

                            preMemberAddMoney.Add(float.Parse(predt.Rows[j]["MemberAddMoney"].ToString()));
                           
                            sumChangciNum += int.Parse((((string)predt.Rows[j]["changciNum"] == "") ? "0" : predt.Rows[j]["changciNum"].ToString()));

                            sumCumstomerNum += int.Parse((((string)predt.Rows[j]["CumstomerNum"] == "") ? "0" : predt.Rows[j]["CumstomerNum"].ToString()));

                            sumTongkan += int.Parse((((string)predt.Rows[j]["Tongkan"] == "") ? "0" : predt.Rows[j]["Tongkan"].ToString()));

                            sumBoxOffice += float.Parse((((string)predt.Rows[j]["BoxOffice"] == "") ? "0" : predt.Rows[j]["BoxOffice"].ToString()));
                            sumNewAddNum += int.Parse((((string)predt.Rows[j]["NewAddNum"] == "") ? "0" : predt.Rows[j]["NewAddNum"].ToString()));
                            sumXiaoMB += int.Parse((((string)predt.Rows[j]["XiaoMB"] == "") ? "0" : predt.Rows[j]["XiaoMB"].ToString()));
                            sumMemberAddMoney += int.Parse((((string)predt.Rows[j]["MemberAddMoney"] == "") ? "0" : predt.Rows[j]["MemberAddMoney"].ToString()));

                        }

                        msg1.Add("<div class=\"ui-block-b treven\" style='width:25%;'><span>同比</span></div>");
                        msg1.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>" + sumChangciNum + "</span></div>");
                        msg1.Add("<div class=\"ui-block-c treven\" style='width:15%;'><span>" + sumCumstomerNum + "</span></div>");
                        msg1.Add("<div class=\"ui-block-c treven\" style='width:20%;'><span>" + sumTongkan + "</span></div>");
                        msg1.Add("<div class=\"ui-block-c treven\" style='width:25%;'><span>" + sumBoxOffice + "</span></div>");
                        msg2.Add("<div class=\"ui-block-b treven\" style='width:25%;'><span>同比</span></div>");
                        msg2.Add("<div class=\"ui-block-c treven\" style='width:25%;'><span>" + sumNewAddNum + "</span></div>"); ;
                        msg2.Add("<div class=\"ui-block-c treven\" style='width:25%;'><span>" + sumXiaoMB + "</span></div>");
                        msg2.Add("<div class=\"ui-block-c treven\" style='width:25%;'><span>" + sumMemberAddMoney + "</span></div>");

                    }
                    item.Add(msg1);
                    item.Add(showdate);
                    item.Add(changciNum);
                    item.Add(CumstomerNum);
                    item.Add(Tongkan);
                    item.Add(NewAddNum);
                    item.Add(BoxOffice);
                    item.Add(XiaoMB);
                    item.Add(MemberAddMoney);
                    item.Add(preShowdate);
                    item.Add(preBoxOffice);
                    item.Add(preMemberAddMoney);
                    item.Add(msg2);
                    DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
                    json.WriteObject(Response.OutputStream, item);
                }
                catch
                { }
            }
        }
        #endregion

        #region 客户线索


        //各在售项目客户线索分析(时间段)
        public void SearchERPSellHouseClueAnalysisReport()
        {
            string dateStart = Request["dateStart"];
            string dateEnd = Request["dateEnd"];
            DataTable dt = new com.hiooy.ERPhouse.WS_ERPSellHouseAnalysis().ERPSellHouseClueAnalysisReport("VYbSBDuFOPVd3452334222", dateStart, dateEnd);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> ProjectID = new List<object>();
            List<object> ProjectName = new List<object>();
            List<object> VistCount = new List<object>();

            if (dt.Rows.Count != 0)
            {
                msg.Add("<div class=\"ui-block-b treven\" style='width:50%;'><span>项目名称</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:50%;'><span>总来访人数</span></div>");
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<a onclick=\"forward(this)\" id=\"" + dt.Rows[j]["ProjectID"] + "\">");
                    ProjectID.Add(dt.Rows[j]["ProjectID"]);
                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:50%;'><span>" + dt.Rows[j]["ProjectName"] + "</span></div>");
                    ProjectName.Add(dt.Rows[j]["ProjectName"]);
                    msg.Add("<div class=\"ui-block-e treven\" style='width:50%;'><span>" + dt.Rows[j]["VistCount"] + "</span></div>");
                    VistCount.Add(float.Parse(dt.Rows[j]["VistCount"].ToString()));
                    msg.Add("</a>");
                }
            }
            item.Add(msg);
            item.Add(ProjectID);
            item.Add(ProjectName);
            item.Add(VistCount);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchERPSellHouseClueAnalysisDetailReport()
        {               ////各在售项目客户线索分析(时间段)（详细）        
            string prjNo = Request["projectNo"];
            string dateStart = Request["dateStart"];
            string dateEnd = Request["dateEnd"];
            DataTable dt = new com.hiooy.ERPhouse.WS_ERPSellHouseAnalysis().ERPSellHouseClueDetailAnalysisReport("VYbSBDuFOPVd3452334222", prjNo, dateStart, dateEnd);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> ProjectName = new List<object>();
            List<object> VisitSource = new List<object>();
            List<object> VistCount = new List<object>();
            string tempVisitSource = "";
            if (dt.Rows.Count != 0)
            {
                msg.Add("<div class=\"ui-block-b treven\" style='width:40%;'><span>项目名称</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:30%;'><span>来访方式</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:30%;'><span>来访人数</span></div>");
                for (int j = 0; j < dt.Rows.Count; j++)
                {

                    switch (int.Parse(dt.Rows[j]["VisitSource"].ToString().Substring(0, 1)))
                    {
                        case 1: tempVisitSource = "电话来访";
                            break;
                        case 2: tempVisitSource = "来访参观";
                            break;
                        case 3: tempVisitSource = "其他";
                            break;
                    }

                    switch (int.Parse(dt.Rows[j]["VisitSource"].ToString().Substring(0, 1)))
                    {
                        case 1: tempVisitSource = "电话来访";
                            break;
                        case 2: tempVisitSource = "来访参观";
                            break;
                        case 3: tempVisitSource = "其他";
                            break;
                    }

                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:40%;'><span>" + dt.Rows[j]["ProjectName"] + "</span></div>");
                    ProjectName.Add(dt.Rows[j]["ProjectName"].ToString());
                    msg.Add("<div class=\"ui-block-c treven\" style='width:30%;'><span>" + tempVisitSource + "</span></div>");
                    VisitSource.Add(tempVisitSource);
                    msg.Add("<div class=\"ui-block-d treven\" style='width:30%;'><span>" + dt.Rows[j]["VistCount"] + "</span></div>");
                    VistCount.Add(float.Parse(dt.Rows[j]["VistCount"].ToString()));
                }
            }
            item.Add(msg);
            item.Add(ProjectName);
            item.Add(VisitSource);
            item.Add(VistCount);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SerachERPSellHouseClueDayReport()
        {               //各在售项目客户线索分析(单日)
            string date = Request["date"];
            DataTable dt = new com.hiooy.ERPhouse.WS_ERPSellHouseAnalysis().ERPSellHouseClueDayReport("VYbSBDuFOPVd3452334222", date);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> ProjectID = new List<object>();
            List<object> ProjectName = new List<object>();
            List<object> VisitTimes = new List<object>();

            if (dt.Rows.Count != 0)
            {
                msg.Add("<div class=\"ui-block-b treven\" style='width:50%;'><span>项目名称</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:50%;'><span>来访次数</span></div>");
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<a onclick=\"forward(this)\" id=\"" + dt.Rows[j]["ProjectID"] + "\">");
                    ProjectID.Add(dt.Rows[j]["ProjectID"]);
                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:50%;'><span>" + dt.Rows[j]["ProjectName"] + "</span></div>");
                    ProjectName.Add(dt.Rows[j]["ProjectName"]);
                    msg.Add("<div class=\"ui-block-e treven\" style='width:50%;'><span>" + dt.Rows[j]["VisitTimes"] + "</span></div>");
                    VisitTimes.Add(float.Parse(dt.Rows[j]["VisitTimes"].ToString()));
                    msg.Add("</a>");
                }
            }
            item.Add(msg);
            item.Add(ProjectID);
            item.Add(ProjectName);
            item.Add(VisitTimes);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SerachERPSellHouseClueDetailDayReport()
        {               //各在售项目客户线索分析(单日)
            string date = Request["date"];
            string ProjectID = Request["projectNo"];
            DataTable dt = new com.hiooy.ERPhouse.WS_ERPSellHouseAnalysis().ERPSellHouseClueDetailDayReport("VYbSBDuFOPVd3452334222", ProjectID, date);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> ProjectName = new List<object>();
            List<object> VisitTimes = new List<object>();
            List<object> VisitTime = new List<object>();
            List<object> VisitSource = new List<object>();
            List<object> VisitorName = new List<object>();
            List<object> Description = new List<object>();
            List<object> ConsultantName = new List<object>();
            string tempDescription = "";
            string tempVisitSource = "";
            int call = 0;
            int visit = 0;
            int other = 0;
            if (dt.Rows.Count != 0)
            {
                msg.Add("<div class=\"ui-block-b trodd\" style='width:20%;'><span>来访时间</span></div>");
                msg.Add("<div class=\"ui-block-b treven\" style='width:20%;'><span>来访方式</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:15%;'><span>来访者</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:25%;'><span>备注说明</span></div>");
                msg.Add("<div class=\"ui-block-e treven\" style='width:20%;'><span>置业顾问</span></div>");
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (String.IsNullOrWhiteSpace(dt.Rows[j]["Description"].ToString()))
                        tempDescription = "无";
                    else
                        tempDescription = dt.Rows[j]["Description"].ToString();
                    switch (int.Parse(dt.Rows[j]["VisitSource"].ToString().Substring(0, 1)))
                    {
                        case 1: call += 1; tempVisitSource = "电话来访";
                            break;
                        case 2: visit += 1; tempVisitSource = "来访参观";
                            break;
                        case 3: other += 1; tempVisitSource = "其他";
                            break;
                    }

                    ProjectName.Add(dt.Rows[j]["ProjectName"]);
                    msg.Add("<div class=\"ui-block-b\" id=\"row" + j + "\" style='width:100%;'><div class=\"ui-block-b trodd\"  style='width:20%;height:100%;'><span>" + dt.Rows[j]["VisitTime"].ToString().Split(' ')[1].Substring(0, 5) + "</span></div>");
                    VisitTime.Add(dt.Rows[j]["VisitTime"]);
                    msg.Add("<div class=\"ui-block-e treven\" style='width:20%;height:100%;'><span>" + tempVisitSource + "</span></div>");
                    //VisitSource.Add(tempVisitSource);
                    msg.Add("<div class=\"ui-block-e treven\" style='width:15%;height:100%;'><span>" + dt.Rows[j]["VisitorName"] + "</span></div>");

                    ProjectName.Add(dt.Rows[j]["ProjectName"]);
                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:20%;'><span>" + dt.Rows[j]["VisitTime"] + "</span></div>");
                    VisitTime.Add(dt.Rows[j]["VisitTime"]);
                    msg.Add("<div class=\"ui-block-e treven\" style='width:20%;'><span>" + tempVisitSource + "</span></div>");
                    //VisitSource.Add(tempVisitSource);
                    msg.Add("<div class=\"ui-block-e treven\" style='width:15%;'><span>" + dt.Rows[j]["VisitorName"] + "</span></div>");

                    VisitorName.Add(dt.Rows[j]["VisitorName"]);

                    msg.Add("<div class=\"ui-block-e treven\" id=\"description" + j + "\" style='width:25%;height:100%;'><span>" + tempDescription + "</span></div>");

                    msg.Add("<div class=\"ui-block-e treven\" style='width:25%;'><span>" + tempDescription + "</span></div>");

                    Description.Add(dt.Rows[j]["Description"]);
                    msg.Add("<div class=\"ui-block-e treven\" style='width:20%;height:100%;'><span>" + dt.Rows[j]["ConsultantName"] + "</span></div>");
                    ConsultantName.Add(dt.Rows[j]["ConsultantName"]);
                    msg.Add("</a></div>");
                }
            }
            VisitSource.Add(call);
            VisitSource.Add(visit);
            VisitSource.Add(other);
            item.Add(msg);
            item.Add(ProjectID);
            item.Add(ProjectName);
            item.Add(VisitTime);
            item.Add(VisitSource);
            item.Add(VisitorName);
            item.Add(Description);
            item.Add(ConsultantName);

            item.Add(dt.Rows.Count);

            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        #endregion

        #region 工业物料
        public void SearchMaterialInfomationsByFnumber()
        {                   //根据物料编码模糊查询
            string prjFnumber = Request["prjFnumber"];
            DataTable dt = new com.hiooy.industry.WS_IndustryAnalysis().MaterialInfomationsByFnumber("VYbSBDuF1OP234332Vd3452222", prjFnumber);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> Fnumber = new List<object>();
            List<object> FmaterialName = new List<object>();
            List<object> Fmodel = new List<object>();
            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    Fnumber.Add(dt.Rows[j]["物料编码"]);
                    FmaterialName.Add(dt.Rows[j]["物料名称"]);
                }
            }
            item.Add(msg);
            item.Add(Fnumber);
            item.Add(FmaterialName);
            item.Add(Fmodel);

            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchMaterialInfomationsByName()
        {                   //根据物料名称模糊查询
            string prjName = Request["prjName"];
            DataTable dt = new com.hiooy.industry.WS_IndustryAnalysis().MaterialInfomationsByName("VYbSBDuF1OP234332Vd3452222", prjName);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> Fnumber = new List<object>();
            List<object> FmaterialName = new List<object>();
            List<object> Fmodel = new List<object>();
            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    Fnumber.Add(dt.Rows[j]["物料编码"]);
                    FmaterialName.Add(dt.Rows[j]["物料名称"]);
                }
            }
            item.Add(msg);
            item.Add(Fnumber);
            item.Add(FmaterialName);
            item.Add(Fmodel);

            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchMaterialInfomationsByFmodel()
        {                   //根据物料规格模糊查询
            string prjModel = Request["prjModel"];
            DataTable dt = new com.hiooy.industry.WS_IndustryAnalysis().MaterialInfomationsByFmodel("VYbSBDuF1OP234332Vd3452222", prjModel);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> Fnumber = new List<object>();
            List<object> FmaterialName = new List<object>();
            List<object> Fmodel = new List<object>();
            if (dt.Rows.Count != 0)
            {
                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    Fnumber.Add(dt.Rows[j]["物料编码"]);
                    FmaterialName.Add(dt.Rows[j]["物料名称"]);
                    Fmodel.Add(dt.Rows[j]["物料规格"]);
                }
            }
            item.Add(msg);
            item.Add(Fnumber);
            item.Add(FmaterialName);
            item.Add(Fmodel);

            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        public void SearchMaterialPriceAndOutputAnylysisTrend()
        {                   //物料价格趋势
            string dateStart = Request["dateStart"];
            string dateEnd = Request["dateEnd"];
            string materialNumber = Request["materialNumber"];
            System.Diagnostics.Trace.WriteLine("开始时间" + dateStart);
            System.Diagnostics.Trace.WriteLine("截至时间" + dateEnd);
            System.Diagnostics.Trace.WriteLine("物料编号" + materialNumber);
            DataTable dt = new com.hiooy.industry.WS_IndustryAnalysis().MaterialPriceAndOutputAnylysisTrend("VYbSBDuF1OP234332Vd3452222", dateStart, dateEnd, materialNumber);
            List<object> item = new List<object>();
            List<object> msg = new List<object>();
            List<object> Fnumber = new List<object>();
            List<object> FmaterialName = new List<object>();
            List<object> Fmodel = new List<object>();
            List<object> PurchasingTime = new List<object>();
            List<object> PurchasingAmount = new List<object>();
            List<object> PurchasingPrice = new List<object>();
            List<object> AvgPrice = new List<object>();
            if (dt.Rows.Count != 0)
            {

                msg.Add("<div class=\"ui-block-b treven\" style='width:25%;'><span>编码</span></div>");
                msg.Add("<div class=\"ui-block-c treven\" style='width:25%;'><span>名称</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:15%;'><span>日期</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:15%;'><span>数量</span></div>");
                msg.Add("<div class=\"ui-block-d treven\" style='width:20%;'><span>平均含税价</span></div>");

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    msg.Add("<div class=\"ui-block-b trodd\"  style='width:25%;'><span>" + dt.Rows[j]["物料编码"] + "</span></div>");
                    Fnumber.Add(dt.Rows[j]["物料编码"]);
                    msg.Add("<div class=\"ui-block-b treven\"  style='width:25%;'><span>" + dt.Rows[j]["物料名称"] + "</span></div>");
                    FmaterialName.Add(dt.Rows[j]["物料名称"]);
                    //msg.Add("<div class=\"ui-block-d treven\" style='width:10%;'><span>" + dt.Rows[j]["物料规格"] + "</span></div>");
                    Fmodel.Add(dt.Rows[j]["物料规格"]);
                    msg.Add("<div class=\"ui-block-d treven\" style='width:15%;'><span>" + dt.Rows[j]["年份"] + "-" + dt.Rows[j]["月份"] + "</span></div>");
                    PurchasingTime.Add(dt.Rows[j]["年份"] + "-" + dt.Rows[j]["月份"]);
                    msg.Add("<div class=\"ui-block-d treven\" style='width:15%;'><span>" + dt.Rows[j]["采购数量"] + "</span></div>");
                    PurchasingAmount.Add(dt.Rows[j]["采购数量"]);
                    //msg.Add("<div class=\"ui-block-d treven\" style='width:20%;'><span>" + dt.Rows[j]["金额"] + "</span></div>");
                    PurchasingPrice.Add(dt.Rows[j]["金额"]);
                    msg.Add("<div class=\"ui-block-d treven\" style='width:20%;'><span>" + float.Parse(dt.Rows[j]["平均含税价格"].ToString()).ToString("#0.00") + "</span></div>");
                    AvgPrice.Add(float.Parse(float.Parse(dt.Rows[j]["平均含税价格"].ToString()).ToString("#0.00")));
                }
            }
            item.Add(msg);
            item.Add(Fnumber);
            item.Add(FmaterialName);
            item.Add(Fmodel);
            item.Add(PurchasingTime);
            item.Add(PurchasingAmount);
            item.Add(PurchasingPrice);
            item.Add(AvgPrice);
            DataContractJsonSerializer json = new DataContractJsonSerializer(item.GetType());
            json.WriteObject(Response.OutputStream, item);
        }

        #endregion

        #region portal业务方法接口
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

        /// <summary>
        /// 工资条查询方法
        /// </summary>
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
        #endregion
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
