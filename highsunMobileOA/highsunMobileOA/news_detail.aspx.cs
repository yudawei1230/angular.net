using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace highsunMobileOA
{
    public partial class news_detail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        private string covdate(string date)
        {
            return string.IsNullOrEmpty(date) ? string.Empty : Convert.ToDateTime(date).ToLongDateString();
        }

        private string _str = string.Empty;



        public string Str
        {
            get
            {
                int npid = WebSite.Comman.SRequest.GetQueryInt("npid", 1);
                string id = WebSite.Comman.SRequest.GetQueryString("id");
                switch (npid)
                {
                    case 0:
                    case 1:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        //新闻
                        string CenterNews = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetCenterNewsByID("VYbSBDuFOPVd3452222", id);
                        string[] CenterNewsSinge = CenterNews.Split(new[] { "||" }, StringSplitOptions.None);
                        _str += "<div class=\"detail_box\">\n";
                        _str += "<h3 class=\"news_title\">" + CenterNewsSinge[1] + "</h3>\n";
                        _str += "<h4 class=\"news_subtit\">创建人：" + CenterNewsSinge[4] + "&nbsp;&nbsp;&nbsp;&nbsp;发布日期：" + covdate(CenterNewsSinge[5]) + "</h4>\n";
                        _str += "<div class=\"news_detail\">\n";
                        _str += CenterNewsSinge[2].Replace("src=\"/images/", "src=\"http://portal.ehighsun.com/images/");
                        _str += "</div>\n";
                        _str += "</div>\n";
                        break;
                    //case 9:
                    //case 21:
                    //case 41:
                    //case 7:
                    //    //OA
                    //    XmlNode OANotices = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetOANotices("VYbSBDuFOPVd3452222", parm.ToString());

                    //    foreach (XmlNode node in OANotices.SelectNodes("item"))
                    //    {
                    //        _str += "<h3 class=\"news_title\">" + CenterNewsSinge[0] + "</h3>\n";
                    //        _str += "<h4 class=\"news_subtit\">创建人：" + CenterNewsSinge[3] + "&nbsp;&nbsp;&nbsp;&nbsp;发布日期：" + CenterNewsSinge[4] + "</h4>\n";
                    //        _str += "<div class=\"news_detail\">\n";
                    //        _str += CenterNewsSinge[1];
                    //        _str += "</div>\n";
                    //        _str += "<li><a href=\"news_detail.aspx?id=" + node.SelectSingleNode("newsid").InnerText + "\">" + node.SelectSingleNode("title").InnerText + "</a></li>\n";
                    //    }
                    //    break;

                    case 1000:
                        string portalStr = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetInsideCompeteByID("VYbSBDuFOPVd3452222", int.Parse(id));
                        string[] portalStrSinge = portalStr.Split(new[] { "||" }, StringSplitOptions.None);
                        _str += "<div class=\"detail_box\">\n";
                        _str += "<h3 class=\"news_title\">" + portalStrSinge[1] + "</h3>\n";
                        _str += "<h4 class=\"news_subtit\">发布人：" + portalStrSinge[6] + "&nbsp;&nbsp;&nbsp;&nbsp;发布日期：" + covdate(portalStrSinge[3]) + "&nbsp;&nbsp;&nbsp;&nbsp;竞聘日期：" + covdate(portalStrSinge[4]) + "至" + covdate(portalStrSinge[5]) + "</h4>\n";
                        _str += "<div class=\"news_detail\">\n";
                        _str += portalStrSinge[2].Replace("src=\"/images/", "src=\"http://portal.ehighsun.com/images/");
                        _str += "</div>\n";
                        _str += "</div>\n";
                        break;
                    case 1001:
                        string trainStr1 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetTrainingInfoByID("VYbSBDuFOPVd3452222", id);
                        string[] trainStrSinge1 = trainStr1.Split(new[] { "||" }, StringSplitOptions.None);
                        _str += "<div class=\"detail_box\">\n";
                        _str += "<h3 class=\"news_title\">" + trainStrSinge1[2] + "</h3>\n";
                        _str += "<h4 class=\"news_subtit\">发布人：" + trainStrSinge1[4] + "&nbsp;&nbsp;&nbsp;&nbsp;发布日期：" + covdate(trainStrSinge1[5]) + "</h4>\n";
                        _str += "<div class=\"news_detail\">\n";
                        _str += trainStrSinge1[3].Replace("src=\"/images/", "src=\"http://portal.ehighsun.com/images/");
                        _str += "</div>\n";
                        _str += "</div>\n";
                        break;
                    case 1002:
                        string trainStr2 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetTrainingInfoByID("VYbSBDuFOPVd3452222", id);
                        string[] trainStrSinge2 = trainStr2.Split(new[] { "||" }, StringSplitOptions.None);
                        _str += "<div class=\"detail_box\">\n";
                        _str += "<h3 class=\"news_title\">" + trainStrSinge2[2] + "</h3>\n";
                        _str += "<h4 class=\"news_subtit\">发布人：" + trainStrSinge2[4] + "&nbsp;&nbsp;&nbsp;&nbsp;发布日期：" + covdate(trainStrSinge2[5]) + "</h4>\n";
                        _str += "<div class=\"news_detail\">\n";
                        _str += trainStrSinge2[3].Replace("src=\"/images/", "src=\"http://portal.ehighsun.com/images/");
                        _str += "</div>\n";
                        _str += "</div>\n";
                        break;
                    case 1003:
                        string trainStr3 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetTrainingInfoByID("VYbSBDuFOPVd3452222", id);
                        string[] trainStrSinge3 = trainStr3.Split(new[] { "||" }, StringSplitOptions.None);
                        _str += "<div class=\"detail_box\">\n";
                        _str += "<h3 class=\"news_title\">" + trainStrSinge3[2] + "</h3>\n";
                        _str += "<h4 class=\"news_subtit\">发布人：" + trainStrSinge3[4] + "&nbsp;&nbsp;&nbsp;&nbsp;发布日期：" + covdate(trainStrSinge3[5]) + "</h4>\n";
                        _str += "<div class=\"news_detail\">\n";
                        _str += trainStrSinge3[3].Replace("src=\"/images/", "src=\"http://portal.ehighsun.com/images/");
                        _str += "</div>\n";
                        _str += "</div>\n";
                        break;
                    case 1004:
                         string trainStr4 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetTrainingInfoByID("VYbSBDuFOPVd3452222", id);
                        string[] trainStrSinge4 = trainStr4.Split(new[] { "||" }, StringSplitOptions.None);
                        _str += "<div class=\"detail_box\">\n";
                        _str += "<h3 class=\"news_title\">" + trainStrSinge4[2] + "</h3>\n";
                        _str += "<h4 class=\"news_subtit\">发布人：" + trainStrSinge4[4] + "&nbsp;&nbsp;&nbsp;&nbsp;发布日期：" + covdate(trainStrSinge4[5]) + "</h4>\n";
                        _str += "<div class=\"news_detail\">\n";
                        _str += trainStrSinge4[3].Replace("src=\"/images/", "src=\"http://portal.ehighsun.com/images/");
                        _str += "</div>\n";
                        _str += "</div>\n";
                        break;
                    case 1005:
                        string trainStr5 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetTrainingInfoByID("VYbSBDuFOPVd3452222", id);
                        string[] trainStrSinge5 = trainStr5.Split(new[] { "||" }, StringSplitOptions.None);
                        _str += "<div class=\"detail_box\">\n";
                        _str += "<h3 class=\"news_title\">" + trainStrSinge5[2] + "</h3>\n";
                        _str += "<h4 class=\"news_subtit\">发布人：" + trainStrSinge5[4] + "&nbsp;&nbsp;&nbsp;&nbsp;发布日期：" + covdate(trainStrSinge5[5]) + "</h4>\n";
                        _str += "<div class=\"news_detail\">\n";
                        _str += trainStrSinge5[3].Replace("src=\"/images/", "src=\"http://portal.ehighsun.com/images/");
                        _str += "</div>\n";
                        _str += "</div>\n";
                        break;
                    case 1006:
                         string trainStr6 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetTrainingInfoByID("VYbSBDuFOPVd3452222", id);
                        string[] trainStrSinge6 = trainStr6.Split(new[] { "||" }, StringSplitOptions.None);
                        _str += "<div class=\"detail_box\">\n";
                        _str += "<h3 class=\"news_title\">" + trainStrSinge6[2] + "</h3>\n";
                        _str += "<h4 class=\"news_subtit\">发布人：" + trainStrSinge6[4] + "&nbsp;&nbsp;&nbsp;&nbsp;发布日期：" + covdate(trainStrSinge6[5]) + "</h4>\n";
                        _str += "<div class=\"news_detail\">\n";
                        _str += trainStrSinge6[3].Replace("src=\"/images/", "src=\"http://portal.ehighsun.com/images/");
                        _str += "</div>\n";
                        _str += "</div>\n";
                        break;
                    case 1007:
                        string trainStr7 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetTrainingInfoByID("VYbSBDuFOPVd3452222", id);
                        string[] trainStrSinge7 = trainStr7.Split(new[] { "||" }, StringSplitOptions.None);
                        _str += "<div class=\"detail_box\">\n";
                        _str += "<h3 class=\"news_title\">" + trainStrSinge7[2] + "</h3>\n";
                        _str += "<h4 class=\"news_subtit\">发布人：" + trainStrSinge7[4] + "&nbsp;&nbsp;&nbsp;&nbsp;发布日期：" + covdate(trainStrSinge7[5]) + "</h4>\n";
                        _str += "<div class=\"news_detail\">\n";
                        _str += trainStrSinge7[3].Replace("src=\"/images/", "src=\"http://portal.ehighsun.com/images/");
                        _str += "</div>\n";
                        _str += "</div>\n";
                        break;
                }
                return _str;
            }
        }
    }
}