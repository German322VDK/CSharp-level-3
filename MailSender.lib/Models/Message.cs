using MailSender.lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_send_Email.lib.Models
{
    public class Message : Entity
    {
        public string Subject { set; get; }
        public string Body { set; get; }
    }
}
