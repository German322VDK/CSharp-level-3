using Microsoft.EntityFrameworkCore;
using Project_send_Email.lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Project_send_Email.Data
{
    class Project_send_EmailDB : DbContext
    {
        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<Sender> Senders { get; set; }

        public DbSet<Servers> Servers { get; set; }

        public DbSet<Message> Messages { get; set; }

        //public DbSet<SchedulerTask> SchedulerTasks { get; set; }
        public Project_send_EmailDB(DbContextOptions<Project_send_EmailDB> opt) : base(opt) { }

    }
}
