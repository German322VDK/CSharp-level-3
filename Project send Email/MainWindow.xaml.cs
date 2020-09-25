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

        private void YLoginEdit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

       

        private void PLoginEdit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ThemnEdit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Yname_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void LetterEdit_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MailAddress to = new MailAddress(PLoginEdit.Text);
            MailAddress from = new MailAddress(YLoginEdit.Text, Yname.Text);


            MailMessage message = new MailMessage(from, to);

            message.Subject = ThemnEdit.Text + " " + DateTime.Now;
            message.Body = LetterEdit.Text + "  " + DateTime.Now;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 25);
            client.Credentials = new NetworkCredential
            {
                UserName = YLoginEdit.Text,
                SecurePassword = PasswordEdit.SecurePassword
            };


            client.EnableSsl = true;

            client.Send(message);
        }
    }
}
