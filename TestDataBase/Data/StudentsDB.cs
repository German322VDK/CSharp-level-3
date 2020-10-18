using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TestDataBase.Data
{
    class StudentsDB : DbContext
    {
        public StudentsDB(DbContextOptions options) : base(options) { }

    }
}
