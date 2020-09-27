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
    public enum mail
    {
        yandex,
        google
    }

    public partial class MainWindow : Window
    {
       private mail a;
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
            
                SendMessage b = new SendMessage(YLoginEdit.Text,
                    PasswordEdit.SecurePassword,
                    PLoginEdit.Text,
                    Yname.Text,
                    ThemnEdit.Text,
                    LetterEdit.Text, a);
            try
            {
                b.Send();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Невозможно отправить письмо " + ex.ToString());

            }
            MessageBox.Show("Работа завершена.");
        }

        private void rbYan_Checked(object sender, RoutedEventArgs e)
        {
            a = mail.yandex;
        }

        private void rbGoog_Checked(object sender, RoutedEventArgs e)
        {
            a = mail.google;
        }
    }
}
