using MailSender.lib.Models.Base;
using Project_send_Email.lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MailSender.lib.Models
{
    public class SchedulerTask : Entity
    {
        public DateTime Time { get; set; }

        public Servers Server { get; set; }

        public Sender Sender { get; set; }

        public ICollection<Recipient> Recipients { get; set; }

        public Message Message { get; set; }
    }
}
