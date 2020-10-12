using MailSender.lib.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Project_send_Email.lib.Models
{
    public class Recipient : Person, IDataErrorInfo
    {
        public override string Name { 
            get => base.Name;
            set
            {
                //if (value == null)
                //    throw new ArgumentNullException(nameof(value));
                //if (value == "")
                //    throw new ArgumentNullException(nameof(value));
                if (value == "QWE")
                    throw new ArgumentException("Запрещенно вводить QWE!",nameof(value));
                base.Name = value;
            }
        }

        string IDataErrorInfo.Error { get; } = "";
        public string this[string PropertyName]
        {
            get
            {
                switch(PropertyName)
                {
                    case nameof(Name):
                        var name = Name;
                        if (name is null) return "Имя не может быть пустой строкой";
                        if(name.Length <= 2) return "Имя не должно быть короче 2 символов";
                        if (name.Length > 20) return "Имя не должно быть длиннее 20 символов";
                        return null;
                    case nameof(Address):

                        return null;
                    default:
                        return null;
                }
            }
        }

    }
}
