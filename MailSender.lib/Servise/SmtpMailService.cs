using System.Net;
using MailSender.lib.Interfaces;
using System.Net.Mail;
using System.Diagnostics;
using System.Collections.Generic;
using System.Threading;

namespace MailSender.lib.Servise
{
    public class SmtpMailService : IMailService
    {
        public IMailSender GetSender(string Server, int Port, bool SSL, string Login, string Password)
        {
            return new SmtpMailSender(Server, Port, SSL, Login, Password);
        }
    }

    internal class SmtpMailSender : IMailSender
    {
        private readonly string _Address;
        private readonly int _Port;
        private readonly bool _SSL;
        private readonly string _Login;
        private readonly string _Password;
        public SmtpMailSender(string Address, int Port, bool SSL, string Login, string Password)
        {
            this._Address = Address;
            this._Port = Port;
            this._SSL = SSL;
            this._Login = Login;
            this._Password = Password;
        }
        public void Send(string SenderAddress, string RecipientAddress, string Subject, string Body)
        {
            MailAddress from = new MailAddress(SenderAddress);
            MailAddress to = new MailAddress(RecipientAddress);
            using (MailMessage m = new MailMessage(from, to))
            {
                m.Subject = Subject;
                m.Body = Body;
                m.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(_Address, _Port))
                {
                    smtp.Credentials = new NetworkCredential
                    {
                        UserName = _Login,
                        Password = _Password
                    };
                    smtp.EnableSsl = _SSL;

                    try
                    {
                        smtp.Send(m);
                    }
                    catch (SmtpException e)
                    {
                        Trace.TraceError(e.ToString());
                        throw;
                    }
                }
            }
        }

        public void Send(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body)
        {
            foreach (var recipient_address in RecipientsAddresses)
                Send(SenderAddress, recipient_address, Subject, Body);
        }

        public void SendParallel(string SenderAddress, IEnumerable<string> RecipientsAddresses, string Subject, string Body)
        {
            foreach (var recipient_address in RecipientsAddresses)
                ThreadPool.QueueUserWorkItem(o => Send(SenderAddress, recipient_address, Subject, Body));
        }
    }
}
