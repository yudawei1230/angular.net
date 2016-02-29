using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Threading;
using System.Collections ;

namespace WebSite.Comman
{
    public class Emails
    {
        static System.Net.Mail.MailMessage _mailMessage = null;
        static SmtpClient _smtpClient = new SmtpClient();
        static bool state = false;
        /// <summary>
        /// 发送邮件,
        /// </summary>
        /// <param name="smtpserver">smtp服务器</param>
        /// <param name="smptport">smtp端口</param>
        /// <param name="userName">用户名</param>
        /// <param name="pwd">密码</param>
        /// <param name="strfrom">发件人地址</param>
        /// <param name="strto">收件人地址</param>
        /// <param name="subj">主题</param>
        /// <param name="bodys">内容</param>
        /// <returns></returns>
        public static bool SendMail(string smtpserver, string smptport, string userName, string pwd, string strfrom, string strto, string subj, string bodys)
        {

            _smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式
            _smtpClient.Host = smtpserver;//指定SMTP服务器

            int port = Convert.ToInt32(smptport);
            if (port > 0)
                _smtpClient.Port = port;
            _smtpClient.Credentials = new System.Net.NetworkCredential(userName, pwd);//用户名和密码
            _smtpClient.EnableSsl = true;
            _mailMessage = new System.Net.Mail.MailMessage(strfrom, strto);
            _mailMessage.Subject = subj;//主题
            _mailMessage.Body = bodys;//内容
            _mailMessage.BodyEncoding = System.Text.Encoding.Default;//正文编码
            _mailMessage.IsBodyHtml = true;//设置为HTML格式
            _mailMessage.Priority = System.Net.Mail.MailPriority.High;//优先级
            try
            {
                Thread t1 = new Thread(new ThreadStart(DoSend));
                t1.Start();
                return state;
            }
            catch
            {
                return false;
            }
        }

        public static void DoSend()
        {
            try
            {
                if (_mailMessage != null)
                {
                    _smtpClient.Send(_mailMessage); state = true;
                }
            }
            catch
            {
                state = false;
            }
        }

        /// <summary>
        /// 发送邮件，替换模版
        /// </summary>
        /// <param name="stringToFormat">邮件内容</param>
        /// <param name="userName">替换的用户名,没有为null</param>
        /// <param name="userPassword">替换的密码,没有为null</param>
        /// <param name="siteName">替换的网站名称,没有为null</param>
        /// <param name="OrderId">替换的订单ID,没有为null</param>
        /// <param name="LoginUrl">替换的登录地址,没有为null</param>
        /// <param name="ChangePassWordUrl">替换的修改密码地址,没有为null</param>
        /// <param name="Amount">替换的订单金额,没有为null</param>
        /// <param name="ShipOrderNumber">替换的发货单,没有为null</param>
        /// <returns></returns>
        public static string GenericEmailFormatter(string stringToFormat, string userName, string userPassword, string siteName, string OrderId, string LoginUrl, string ChangePassWordUrl, string Amount, string ShipOrderNumber)
        {
            if (siteName != null)
            {
                stringToFormat = stringToFormat.Replace("$SiteName$", siteName);
            }
            if (userName != null)
            {
                stringToFormat = stringToFormat.Replace("$UserName$", userName);
            }
            if (userPassword != null)
            {
                stringToFormat = stringToFormat.Replace("$Password$", userPassword);
            }
            if (OrderId != null)
            {
                stringToFormat = stringToFormat.Replace("$OrderId$", OrderId);
            }
            if (LoginUrl != null)
            {
                stringToFormat = stringToFormat.Replace("$LoginUrl$", LoginUrl);
            }
            if (ChangePassWordUrl != null)
            {
                stringToFormat = stringToFormat.Replace("$ChangePassWordUrl$", ChangePassWordUrl);
            }
            if (Amount != null)
            {
                stringToFormat = stringToFormat.Replace("$Amount$", Amount);
            }
            if (ShipOrderNumber != null)
            {
                stringToFormat = stringToFormat.Replace("$ShipOrderNumber$", ShipOrderNumber);
            }
            return stringToFormat;
        }
        /// <summary>
        /// 推荐好友的模板替换
        /// </summary>
        /// <param name="module">模板内容</param>
        /// <param name="UserName">推荐人名称</param>
        /// <param name="ProductName">产品名称</param>
        /// <param name="ProductIMG">产品图片名称</param>
        /// <param name="ProductJS">产品介绍</param>
        /// <param name="ProductYS">产品优势</param>
        /// <param name="ProductID">产品编号</param>
        /// <returns></returns>
        public static string ReCommendEamilFormatter(string module,string UserName,string ProductName,string ProductIMG,string ProductJS,string ProductYS,int ProductID)
        {
            if (!string.IsNullOrEmpty(module))
            {
                if (!string.IsNullOrEmpty(UserName))
                {
                    module = module.Replace("#UserName#",UserName);
                }
                if (!string .IsNullOrEmpty(ProductName))
                {
                    module = module.Replace("#ProductName#",ProductName);
                }
                if (!string.IsNullOrEmpty(ProductIMG))
                {
                    module = module.Replace("#ProductIMG#", ProductIMG);
                }
                if (!string.IsNullOrEmpty(ProductJS))
                {
                    module = module.Replace("#ProductJS#", ProductJS);
                }
                if (!string .IsNullOrEmpty (ProductYS))
                {
                    module = module.Replace("#ProductYS#", ProductYS);
                }
                if (ProductID!=0)
                {
                    module = module.Replace("#ProductID#", ProductID.ToString());
                }
            }
            return module;
        }
    }
}
