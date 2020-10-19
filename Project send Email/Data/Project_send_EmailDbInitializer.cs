using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project_send_Email.Data
{
    class Project_send_EmailDbInitializer
    {
        private readonly Project_send_EmailDB _db;

        public Project_send_EmailDbInitializer(Project_send_EmailDB db) => _db = db;

        public void Initialize()
        {
            _db.Database.Migrate();

            InitializeRecipients();
            InitializeSenders();
            InitializeServers();
            InitializeMessages();
        }

        private void InitializeRecipients()
        {
            if (_db.Recipients.Any()) return;

            _db.Recipients.AddRange(TestData.Recipients);
            _db.SaveChanges();
        }

        private void InitializeSenders()
        {
            if (_db.Senders.Any()) return;

            _db.Senders.AddRange(TestData.Senders);
            _db.SaveChanges();
        }

        private void InitializeMessages()
        {
            if (_db.Messages.Any()) return;

            _db.Messages.AddRange(TestData.Messages);
            _db.SaveChanges();
        }

        private void InitializeServers()
        {
            if (_db.Servers.Any()) return;

            _db.Servers.AddRange(TestData.Serverss);
            _db.SaveChanges();
        }
    }
}
