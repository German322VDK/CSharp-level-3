using MailSender.lib.Interfaces;
using MailSender.lib.Models;
using Microsoft.EntityFrameworkCore;
using Project_send_Email.lib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_send_Email.Data.Stores.InDB
{
     class RecipientsStoreInDB :  StoreInDB<Recipient>
    {
        public RecipientsStoreInDB(Project_send_EmailDB db) : base(db) { }
    }


    class SendersStoreInDB : StoreInDB<Sender>
    {
        public SendersStoreInDB(Project_send_EmailDB db) : base(db) { }
    }

    class ServersStoreInDB : StoreInDB<Servers>
    {
        public ServersStoreInDB(Project_send_EmailDB db) : base(db) { }
    }

    class MessagesStoreInDB : StoreInDB<Message>
    {
        public MessagesStoreInDB(Project_send_EmailDB db) : base(db) { }
    }

    class SchedulerTasksStoreInDB : StoreInDB<SchedulerTask>
    {
        public SchedulerTasksStoreInDB(Project_send_EmailDB db) : base(db) { }
    }

}
