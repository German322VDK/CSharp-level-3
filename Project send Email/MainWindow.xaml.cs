using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using Project_send_Email.Models;
using MailSender.lib;

namespace Project_send_Email
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //private void OnSendButtonClick(object Sender, RoutedEventArgs e)
        //{
        //    var sender = SendersList.SelectedItem as Sender;
        //    if (sender is null) return;
        //    if (!(RecipientsList.SelectedItem is Recipient recipient)) return;
        //    var server = ServersList.SelectedItem as Servers;
        //    if (server is null) return;
        //    var massage = MessagesList.SelectedItems as Message;
        //    if (massage is null) return;
        //    var mail_sender = new MailSenderServise
        //    {
        //        ServerAddress = server.Address,
        //        ServerPort = server.Port,
        //        UseSsl = server.UseSSL,
        //        Loggin = server.Login,
        //        Password = server.Password
        //    };
        //    try
        //    {
        //        mail_sender.SendMessage(sender.Address, recipient.Address, massage.Subject, massage.Body);
        //    }
        //    catch (SmtpException er)
        //    {
        //        MessageBox.Show("Ошибка при отправке письма"+ er.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //    }
        //}
    }
}
