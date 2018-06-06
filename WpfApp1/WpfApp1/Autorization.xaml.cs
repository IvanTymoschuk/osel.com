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
using System.Windows.Shapes;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Autorization.xaml
    /// </summary>
    public partial class Autorization : Window
    {
        public List<User> list = new List<User>();
        public Autorization()
        {
            InitializeComponent();
            if (File.Exists("user.xml") == true)
            {

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
                using (FileStream fs = new FileStream("user.xml", FileMode.Open))
                {
                    list = (List<User>)xmlSerializer.Deserialize(fs);
                }
            }
            else
                list.Add(new User());
        }

        private void reg_btn_Click(object sender, RoutedEventArgs e)
        {
            Registration new_acc = new Registration();
            new_acc.Show();;
            this.Close();
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            foreach (var el in list)
                if (el.login == this.Login.Text && el.password == this.Pass.Password)
                    MessageBox.Show("Connect");
                else
                {
                    MessageBox.Show("Login or password is valid");
                    return;
                }
        }
    }
}
