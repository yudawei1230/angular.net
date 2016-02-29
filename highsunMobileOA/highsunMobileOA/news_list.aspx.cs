using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using System.Xml.Linq;

namespace highsunMobileOA
{
    public partial class news_list : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }


        private string _str = string.Empty;
        private string _tlt = string.Empty;

        public string Tlt
        {
            get
            {
                int parm = WebSite.Comman.SRequest.GetQueryInt("id", 0);
                switch (parm)
                {
                    case 0:
                        _tlt = "海印文化";
                        break;
                    case 1:
                        _tlt = "内部新闻";
                        break;
                    case 5:
                        _tlt = "会议纪要";
                        break;
                    case 6:
                        _tlt = "企业动态";
                        break;
                    case 7:
                        _tlt = "员工检查";
                        break;   
                    case 8:
                        _tlt = "服务监督";
                        break;                    
                    case 1000:
                        _tlt = "招聘展示";
                        break;
                    case 1001:
                        _tlt = "海印导读";
                        break;
                    case 1002:
                        _tlt = "海印聚焦";
                        break;
                    case 1003:
                        _tlt = "海印生活";
                        break;
                    case 1004:
                        _tlt = "特色课程";
                        break;
                    case 1005:
                        _tlt = "推荐文章";
                        break;
                    case 1006:
                        _tlt = "讲师风采";
                        break;
                    case 1007:
                        _tlt = "课程回顾";
                        break;
                    case 9:
                        _tlt = "通知";
                        break;
                    case 21:
                        _tlt = "人事任免";
                        break;
                    case 41:
                        _tlt = "绩效";
                        break;
                    //case 7:
                    //    _tlt = "奖惩";
                    //    break;
                }
                return _tlt;
            }
        }

        public string Str
        {
            get
            {
                int parm = WebSite.Comman.SRequest.GetQueryInt("id", 0);
                switch (parm)
                {
                    case 0:
                    case 1:
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        //新闻
                        DataTable newDt = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetCenterNews("VYbSBDuFOPVd3452222", parm.ToString(),20);
                        foreach (DataRow dr in newDt.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[1].ToString() + "</a></li>\n";
                        }

                        newDt.Dispose();
                        break;
                    
                    case 1000://内部竞聘
                        DataTable portalDt = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadInsideCompetes("VYbSBDuFOPVd3452222", 20);
                        foreach (DataRow dr in portalDt.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[1].ToString() + "</a></li>\n";
                        }
                        portalDt.Dispose();
                        break;
                    case 1001://海印文化-海印导读
                        DataTable trainDt1 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadTrainingInfosByChannelID("VYbSBDuFOPVd3452222", "130E0208-2537-4ADE-A8E5-961CBEBD91EB", 100);
                        foreach (DataRow dr in trainDt1.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[2].ToString() + "</a></li>\n";
                        }
                        trainDt1.Dispose();
                        break;
                    case 1002://海印文化-海印聚焦
                        DataTable trainDt2 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadTrainingInfosByChannelID("VYbSBDuFOPVd3452222", "D6824D3F-B550-4A79-9FDA-F5FDF6C95EA2", 100);
                        foreach (DataRow dr in trainDt2.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[2].ToString() + "</a></li>\n";
                        }
                        trainDt2.Dispose();
                        break;
                    case 1003://海印文化-海印生活
                        DataTable trainDt3 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadTrainingInfosByChannelID("VYbSBDuFOPVd3452222", "E03C7983-1E21-4944-95F1-27D27804619C", 100);
                        foreach (DataRow dr in trainDt3.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[2].ToString() + "</a></li>\n";
                        }
                        trainDt3.Dispose();
                        break;
                    case 1004://海印培训-特色课程
                        DataTable itemsDt1 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadTrainingInfosByChannelID("VYbSBDuFOPVd3452222", "AFA6F1CC-209A-4610-B0D7-8A7BED2B6F51", 100);
                        foreach (DataRow dr in itemsDt1.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[2].ToString() + "</a></li>\n";
                        }
                        itemsDt1.Dispose();
                        break;
                    case 1005://海印培训-推荐文章
                        DataTable itemsDt2 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadTrainingInfosByChannelID("VYbSBDuFOPVd3452222", "B9C5E0FF-6D29-4F8E-A08F-486062B39B9E", 100);
                        foreach (DataRow dr in itemsDt2.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[2].ToString() + "</a></li>\n";
                        }
                        itemsDt2.Dispose();
                        break;
                    case 1006://海印培训-讲师风采
                        DataTable itemsDt3 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadTrainingInfosByChannelID("VYbSBDuFOPVd3452222", "8F73DF78-ADA5-4F56-BB36-BEBD2257515E", 100);
                        foreach (DataRow dr in itemsDt3.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[2].ToString() + "</a></li>\n";
                        }
                        itemsDt3.Dispose();
                        break;
                    case 1007://微课堂-课程回顾
                        DataTable itemsDt4 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadTrainingInfosByChannelID("VYbSBDuFOPVd3452222", "7CB3470A-3A1C-4ABA-AF9E-C0F775379256", 100);
                        foreach (DataRow dr in itemsDt4.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[2].ToString() + "</a></li>\n";
                        }
                        itemsDt4.Dispose();
                        break;
                }
                return _str;
            }
        }
    }
}