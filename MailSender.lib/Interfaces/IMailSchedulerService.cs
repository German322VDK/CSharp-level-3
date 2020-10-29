using Project_send_Email.lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Interfaces
{
    public interface IMailSchedulerService
    {
        void Start();

        void Stop();

        void AddTask(DateTime Time, Sender Sender, IEnumerable<Recipient> Recipients, Servers Server, Message Message);
    }
}
