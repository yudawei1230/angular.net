using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Data;
using System.Xml;
using WebSite.Comman;


namespace WebSite.BLL
{
    /// <summary>
    /// 页面的头部尾部操作处理类
    /// </summary>
    public class BasePageLoading : System.Web.UI.Page
    {
        public BasePageLoading()
        {
            GetTitle();
        }

        #region 页面头部/尾部内容处理操作

        //加载头部Meta、Script、Style
        public static string TitleContent;
        public void GetTitle()
        {
            XmlDocument pageContent = new XmlDocument();
            pageContent.Load(Server.MapPath("~/App_Data/CommonScript.xml"));
            TitleContent = XMLUtil.GetNodeValue(pageContent, "title");
        }

        //定义一个文件流读取器
        StreamReader rder = null;
        //设置文件流读取器文字编码
        Encoding encoding = Encoding.GetEncoding("gb2312");

        /// <summary>
        /// 提取头部文件内容
        /// </summary>
        /// <returns></returns>
        public void GetHeader()
        {
            try
            {
                StringBuilder pageHeader = new StringBuilder();
                rder = new StreamReader(Server.MapPath("~/Control/header.html"), encoding);
                pageHeader.Append(rder.ReadToEnd());
            }
            catch (Exception ex)
            {
                Context.Response.Write("读取头部错误!" + ex.Message);
                rder.Close();
            }
            finally
            {
                rder.Close();
            }
        }
        /// <summary>
        /// 提取尾部文件内容
        /// </summary>
        public void GetFooter()
        {
            try
            {
                StringBuilder pagefooter = new StringBuilder();
                rder = new StreamReader(Server.MapPath("~/Control/footer.html"), encoding);
                pagefooter.Append(rder.ReadToEnd());
            }
            catch (Exception ex)
            {
                Context.Response.Write("读取尾部错误!" + ex.Message);
                rder.Close();
            }
            finally
            {
                rder.Close();
            }
        }
        #endregion
    }

}
