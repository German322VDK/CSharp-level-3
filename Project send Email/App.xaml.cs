using System;
using MailSender.lib.Interfaces;
using MailSender.lib.Servise;
using Project_send_Email.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

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
            // services.AddScoped<>()

            //using (var scope = Services.CreateScope())
            //{
            //    var mail_service = scope.ServiceProvider.GetRequiredService<IMailService>();
            //    var sender = mail_service.GetSender("smtp.mail.ru", 25, true, "Login", "Password");
            //    sender.Send("sender@mail.ru", "recipient@gmail.com", "Title", "Body");
            //}
        }
    }
}
