using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_LibraryManagementSystem.API.DataModel.Helper
{
    public class EmailService
    {
        public static void smtpMailer(int status, string fromMailId, string toMailid, string comments)
        {
            var subject = "";
            if (status == 1)
            {
                subject = "Book Requested";
            }
            else if (status == 2)
            {

                subject = "Your book request accepted";
            }
            else if (status == 3)
            {
                subject = "Your Book Request is Rejected";
            }
            string content;
            if (status == 1)
            {
                content = "You have got one book request!!!  : ";
            }
            else if (status == 2)
            {
                content = "your request is approved  ";
            }
            else
            {
                content = $"your requset  is  rejected due to {comments}";
            }
           
                
                MailMessage message = new MailMessage(fromMailId, toMailid);
                SmtpClient smtp = new SmtpClient();

                message.Subject = subject;
                message.IsBodyHtml = false; //to make message body as html
                message.Body = content;
                smtp.Port = 587;
                smtp.UseDefaultCredentials = true;
                smtp.Host = "smtp.gmail.com"; //for gmail host
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("sachinmittalkod@gmail.com", "xuzoevzhklxmrgwe");
                //smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
          
            
        }
    }
}
