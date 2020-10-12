using Project_send_Email.lib.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using MailSender.lib.Servise;

namespace Project_send_Email.Data
{
    static class TestData
    {
        public static List<Sender> Senders { get; } = Enumerable.Range(1, 10)
            .Select(i => new Sender
            {
                Name = $"Отправитель {i}",
                Address = $"Sender_{i}@server.ru"
            })
            .ToList();
        public static List<Recipient> Recipients { get; } = Enumerable.Range(1, 10)
           .Select(i => new Recipient
           {
               Name = $"Получатель {i}",
               Address = $"Sender_{i}@server.ru"
           })
           .ToList();
        public static List<Servers> Serverss { get; } = Enumerable.Range(1, 10)
           .Select(i => new Servers
           {
               Address = $"smtp.server{i}.com",
               Login = $"Login-{i}",
               Password= TextEncoder.Encode($"Password-{i}"),
               UseSSL = i%2==0
           })
           .ToList();

        public static List<Message> Messages { get; } = Enumerable.Range(1, 10)
           .Select(i => new Message
           {
               Subject = $"Сообщение {i}",
               Body = $"Текст сообщения {i}"
           })
           .ToList();
    }
}
