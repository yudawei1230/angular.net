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
                        _tlt = "培训学习";
                        break;
                    case 1002:
                        _tlt = "推荐文章";
                        break;
                    case 1003:
                        _tlt = "海印读书会";
                        break;
                    case 1004:
                        _tlt = "规章制度";
                        break;
                    case 1005:
                        _tlt = "廉洁海印";
                        break;
                    case 1006:
                        _tlt = "部门抽查";
                        break;
                    case 1007:
                        _tlt = "总裁大讲堂";
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
                    //case 9:
                    //case 21:
                    //case 41:
                    //case 7:
                    //    //OA
                    //    DataTable oaDt = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_GetOANotices("VYbSBDuFOPVd3452222", parm.ToString());

                    //    foreach (DataRow dr in oaDt.Rows)
                    //    {
                    //        //http://oa.ehighsun.com/login/MyVerifyLogin.jsp?logintype=1&loginid=testAccount&userpassword=H!ghsun141106
                    //        _str += "<li><a href=\"" + dr[1].ToString() + "\">" + dr[0].ToString() + "</a></li>\n";
                    //    }
                    //    oaDt.Dispose();
                    //    break;
                    case 1000:
                        DataTable portalDt = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadInsideCompetes("VYbSBDuFOPVd3452222", 20);
                        foreach (DataRow dr in portalDt.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[1].ToString() + "</a></li>\n";
                        }
                        portalDt.Dispose();
                        break;
                    case 1001:
                        DataTable trainDt1 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadTrainingInfosByChannelID("VYbSBDuFOPVd3452222", "E037BCD8-501F-44C4-92E4-0B45CE896336", 20);
                        foreach (DataRow dr in trainDt1.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[2].ToString() + "</a></li>\n";
                        }
                        trainDt1.Dispose();
                        break;
                    case 1002:
                        DataTable trainDt2 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadTrainingInfosByChannelID("VYbSBDuFOPVd3452222", "B9C5E0FF-6D29-4F8E-A08F-486062B39B9E", 20);
                        foreach (DataRow dr in trainDt2.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[2].ToString() + "</a></li>\n";
                        }
                        trainDt2.Dispose();
                        break;
                    case 1003:
                        DataTable trainDt3 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadTrainingInfosByChannelID("VYbSBDuFOPVd3452222", "E31F6879-F54C-43AA-BBC6-6A081467989C", 20);
                        foreach (DataRow dr in trainDt3.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[2].ToString() + "</a></li>\n";
                        }
                        trainDt3.Dispose();
                        break;
                    case 1004:
                        DataTable itemsDt1 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadChannelItemsByChannelID("VYbSBDuFOPVd3452222", "64874804-334D-47BB-BD4D-802D4DDF31EC", 20);
                        foreach (DataRow dr in itemsDt1.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[1].ToString() + "</a></li>\n";
                        }
                        itemsDt1.Dispose();
                        break;
                    case 1005:
                        DataTable itemsDt2 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadChannelItemsByChannelID("VYbSBDuFOPVd3452222", "02E70F04-5559-4F69-B293-07292ABBCB9A", 20);
                        foreach (DataRow dr in itemsDt2.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[1].ToString() + "</a></li>\n";
                        }
                        itemsDt2.Dispose();
                        break;
                    case 1006:
                        DataTable itemsDt3 = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadChannelItemsByChannelID("VYbSBDuFOPVd3452222", "C7C282C6-E6D4-4EDA-AAD2-63A746A76EC3", 20);
                        foreach (DataRow dr in itemsDt3.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[1].ToString() + "</a></li>\n";
                        }
                        itemsDt3.Dispose();
                        break;
                    case 1007:
                        DataTable ceoDt = new com.hiooy.dsp.WS_HighsunPortal1().HighsunPortal_LoadCEOSpeakings("VYbSBDuFOPVd3452222", 20);
                        foreach (DataRow dr in ceoDt.Rows)
                        {
                            _str += "<li><a href=\"news_detail.aspx?id=" + dr[0].ToString() + "&npid=" + parm + "\">" + dr[1].ToString() + "</a></li>\n";
                        }
                        ceoDt.Dispose();
                        break;
                }
                return _str;
            }
        }
    }
}