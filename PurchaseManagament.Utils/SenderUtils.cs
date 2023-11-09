using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PurchaseManagament.Utils
{
    public static class SenderUtils
    {

        public static void SendMail(string mailAdress, string title, string message)
        {
            MailMessage message1 = new MailMessage();
            SmtpClient smtpClient = new SmtpClient(/*"smtp.gmail.com", 587*/);
            smtpClient.Credentials = new NetworkCredential("emrebjk1919@gmail.com", "emrekaya1903");
            smtpClient.Port = 587;
            smtpClient.Host = "smtp.office365.com";
            smtpClient.EnableSsl = true;
            message1.To.Add(mailAdress);
            message1.From = new MailAddress("emrebjk1919@gmail.com");
            message1.Subject = title;
            message1.Body = message;
            smtpClient.Send(message1);
        }
    }
}
