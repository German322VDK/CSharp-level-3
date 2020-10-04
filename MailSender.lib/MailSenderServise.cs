using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.Diagnostics;

namespace MailSender.lib
{
    public class MailSenderServise
    {
        public string ServerAddress { set; get; }
        public int ServerPort { set; get; }
        public string Loggin { set; get; }
        public string Password { set; get; }
        public bool UseSsl { get; set; }
        public void SendMessage(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            MailAddress from = new MailAddress(SenderAddress);
            MailAddress to = new MailAddress(RecipientAddress);
            using (MailMessage m = new MailMessage(from, to))
            {
                m.Subject = Subject;
                m.Body = Body;
                m.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(ServerAddress, ServerPort))
                {
                    smtp.Credentials = new NetworkCredential
                    {
                        UserName = Loggin,
                        Password = Password
                    };
                    smtp.EnableSsl = UseSsl;

                    try
                    {
                        smtp.Send(m);
                    }
                    catch(SmtpException e)
                    {
                        Trace.TraceError(e.ToString());
                        throw;
                    }
                }
            }
        }
    }
}
