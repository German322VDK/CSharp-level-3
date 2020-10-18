using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using TestDataBase.Data.Entities;

namespace TestDataBase.Data
{
    public class StudentsDB : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public StudentsDB(DbContextOptions options) : base(options) { }

    }
}
