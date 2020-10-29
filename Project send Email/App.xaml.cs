using System;
using MailSender.lib.Interfaces;
using MailSender.lib.Servise;
using Project_send_Email.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Project_send_Email.Data;
using Microsoft.EntityFrameworkCore;
using System.Windows;
using System.Linq;
using Project_send_Email.lib.Models;
using Project_send_Email.Data.Stores.InDB;

namespace Project_send_Email
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App //: Application
    {
        private static IHost _Hosting;

        public static IHost Hosting => _Hosting
            ??= Host.CreateDefaultBuilder(Environment.GetCommandLineArgs())
            .ConfigureHostConfiguration(cfg => cfg
                   .AddJsonFile("appconfig.json", true, true)
                   .AddXmlFile("appsettings.xml", true, true)
                )
            .ConfigureAppConfiguration(cfg => cfg
                   .AddJsonFile("appconfig.json", true, true)
                   .AddXmlFile("appsettings.xml", true, true)
                )
            .ConfigureLogging(log => log
            .AddConsole()
            .AddDebug()
                )
            .ConfigureServices(ConfigureServices)
            .Build();

        public static IServiceProvider Services => Hosting.Services;

        private static void ConfigureServices(HostBuilderContext host, IServiceCollection services)
        {
            services.AddSingleton<MainWindowViewModel>();

#if DEBUG
            services.AddTransient<IMailService, DebugMailService>();
#else
            services.AddTransient<IMailService, SmtpMailService>();
#endif
            services.AddSingleton<IEncryptorService, Rfc2898Encryptor>();
            services.AddDbContext<Project_send_EmailDB>(opt => opt
               .UseSqlServer(host.Configuration.GetConnectionString("Default")));
            services.AddTransient<Project_send_EmailDbInitializer>();
            // services.AddScoped<>()
            services.AddSingleton<IStore<Recipient>, RecipientsStoreInDB>();
            //using (var scope = Services.CreateScope())
            //{
            //    var mail_service = scope.ServiceProvider.GetRequiredService<IMailService>();
            //    var sender = mail_service.GetSender("smtp.mail.ru", 25, true, "Login", "Password");
            //    sender.Send("sender@mail.ru", "recipient@gmail.com", "Title", "Body");
            //}
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            Services.GetRequiredService<Project_send_EmailDbInitializer>().Initialize();
            base.OnStartup(e);
            //using (var db = Services.GetRequiredService<Project_send_EmailDB>())
            //{
            //    var to_remove = db.SchedulerTasks.Where(task => task.Time < DateTime.Now);
            //    if (to_remove.Any())
            //    {
            //        db.SchedulerTasks.RemoveRange(to_remove);
            //        db.SaveChanges();
            //    }
            //}
        }
    }
}
