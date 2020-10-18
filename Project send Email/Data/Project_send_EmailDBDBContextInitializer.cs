using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Project_send_Email.Data
{
    class Project_send_EmailDBDBContextInitializer : IDesignTimeDbContextFactory<Project_send_EmailDB>
    {
        public Project_send_EmailDB CreateDbContext(string[] args)
        {
            const string connection_string = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MailSender.DB;Integrated Security=True";

            var optionsBuilder = new DbContextOptionsBuilder<Project_send_EmailDB>();
            optionsBuilder.UseSqlServer(connection_string);

            return new Project_send_EmailDB(optionsBuilder.Options);
        }
    }
}
