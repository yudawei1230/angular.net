using System;
using System.Collections.Generic;
using System.Web;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace WebSite.Comman
{
    /// <summary>
    ///SendMail(发送邮件的类)
    /// </summary>
    public class SendMail
    {
        public SendMail()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }
        private MailMessage mailme;
        private SmtpClient smipct;
        private string password;//发件人密码
        /// <summary>
        /// 处理类的实例
        /// </summary>
        /// <param name="To">收件人地址</param>
        /// <param name="From">发件人地址</param>
        /// <param name="Body">邮件正文</param>
        /// <param name="Title">邮件标题</param>
        /// <param name="password">发件人密码</param>
        public void SendMailMethod(string To, string From, string Body, string Title, string password)
        {
            mailme = new MailMessage();
            string[] email = To.Split(',');
            for (int i = 0; i < email.Length; i++)
            {
                mailme.To.Add(email[i]);
            }
            mailme.From = new System.Net.Mail.MailAddress(From);
            mailme.Subject = Title;
            mailme.Body = Body;
            mailme.BodyEncoding = System.Text.Encoding.UTF8;
            mailme.Priority = System.Net.Mail.MailPriority.Normal;
            this.password = password;
        }
        /// <summary>
        /// 添加附件
        /// </summary>
        /// <param name="path">附件</param>
        public void Attachments(string path)
        {
            string[] paths = path.Split(',');
            Attachment data;
            ContentDisposition disposition;
            for (int i = 0; i < paths.Length; i++)
            {
                data = new Attachment(paths[i], MediaTypeNames.Application.Octet);//实例化
                disposition = data.ContentDisposition;
                disposition.CreationDate = System.IO.File.GetCreationTime(paths[i]);//获取
                disposition.ModificationDate = System.IO.File.GetLastWriteTime(paths[i]);//获取附件的修改日期  
                disposition.ReadDate = System.IO.File.GetLastAccessTime(paths[i]);//获取附件的读取日期  
                mailme.Attachments.Add(data);//添加到附件中 
            }
        }
        /// <summary>  
        /// 异步发送邮件  
        /// </summary>  
        /// <param name="CompletedMethod"></param>  
        public void SendAsync(SendCompletedEventHandler CompletedMethod)
        {
            if (mailme != null)
            {
                smipct = new SmtpClient();
                smipct.Credentials = new System.Net.NetworkCredential
    (mailme.From.Address, password);//设置发件人身份的票据  
                smipct.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smipct.Host = "smtp." + mailme.From.Host;
                smipct.SendCompleted += new SendCompletedEventHandler
    (CompletedMethod);//注册异步发送邮件完成时的事件  
                smipct.SendAsync(mailme, mailme.Body);
            }
        }
        /// <summary>  
        /// 发送邮件  
        /// </summary>  
        public void Send()
        {
            if (mailme != null)
            {
                smipct = new SmtpClient();
                smipct.Credentials = new System.Net.NetworkCredential
    (mailme.From.Address, password);//设置发件人身份的票据  
                smipct.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smipct.Host = "smtp." + mailme.From.Host;
                smipct.Send(mailme);
            }
        }
    }

}