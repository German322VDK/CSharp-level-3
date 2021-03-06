﻿using MailSender.lib.Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_send_Email.lib.Models
{
    public class Servers : NamedEntity
    {
        public string Address { get; set; }
        private int _Port=25;

        public int Port 
        {
            get => _Port; 
            set
            {
                if (value < 0 || value > 65535)
                    throw new ArgumentOutOfRangeException(nameof(value), value, "Номер порта должен быть в диапозоне");
                _Port = value;
            }
        }
        public string Login { get; set; }
        public string Password { get; set; }
        public bool UseSSL { get; set; }
        public string Description { get; set; }

    }
}
