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

namespace WpfApp1
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



        private void Login_Click(object sender, RoutedEventArgs e)
        {
            string login = "test";
            string password = "test";
            bool isBanned = false;
            if (String.IsNullOrEmpty(Login_box.Text) || String.IsNullOrEmpty(Password_box.Password))
                MessageBox.Show("Please input all field");
            else
            if (login == Login_box.Text && Password_box.Password == password)
                if (isBanned == true)
                {
                    MessageBox.Show("You has banned");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Connected");
                    this.Close();
                }
            else
                MessageBox.Show("Login or password is invalid");
          
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
