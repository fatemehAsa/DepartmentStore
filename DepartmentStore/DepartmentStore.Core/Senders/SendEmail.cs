using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace DepartmentStore.Core.Senders
{
    public class SendEmail
    {
        public static void Send(string To,string Subject,string Body)
        {
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("fa.asadi1984@gmail.com","ایران ابزار");
            mail.To.Add(To);
            mail.Subject = Subject;
            mail.Body = Body;
            mail.IsBodyHtml = true;

            //System.Net.Mail.Attachment attachment;
            // attachment = new System.Net.Mail.Attachment("c:/textfile.txt");
            // mail.Attachments.Add(attachment);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("fa.asadi1984@gmail.com", "Fatemeh@123456");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

        }
    }
}