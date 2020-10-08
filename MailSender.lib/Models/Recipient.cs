using MailSender.lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_send_Email.lib.Models
{
    public class Recipient : Person 
    {
        public override string Name { 
            get => base.Name;
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value));
                if (value == "QWE")
                    throw new ArgumentException("Запрещенно вводить QWE!",nameof(value));
                base.Name = value;
            }
        }
    }
}
