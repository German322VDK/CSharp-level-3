using System;
using System.Collections.Generic;
using System.Security;
using System.Text;
using System.Net;
using System.Net.Mail;

namespace Project_send_Email
{
    public class SendMessage
    {
        int p = 25; //у меня и гугл и яндекс работают только через этот порт
        
        public SendMessage(string ylog, SecureString pass, string plog, string nam, string them, string lett, mail a)
        {
            this.Ylog = ylog;
            this.Pass = pass;
            this.Plog = plog;
            this.Name = nam;
            this.Them = them;
            this.Lett = lett;
            this.A = a;
        }
        
        string Ylog { set; get; }
        SecureString Pass { set; get; }
        string Plog { set; get; }
        string Name { set; get; }
        string Them { set; get; }
        string Lett { set; get; }
        mail A { set; get; }

        public void Send()
        {
            MailAddress to = new MailAddress(Plog);
            MailAddress from = new MailAddress(Ylog, Name);


            using MailMessage message = new MailMessage(from, to);

            message.Subject = Them + " " + DateTime.Now;
            message.Body = Lett + "  " + DateTime.Now;
            SmtpClient client;
            if (A == mail.google) client = new SmtpClient("smtp.gmail.com", p);
            else client = new SmtpClient("smtp.yandex.ru", p);
            client.Credentials = new NetworkCredential
            {
                UserName = Ylog,
                SecurePassword = Pass
            };


            client.EnableSsl = true;

            client.Send(message);
        }
    }
}
