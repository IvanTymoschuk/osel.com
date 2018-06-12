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
        public User user_name { get; set; }
        public List<User> list = new List<User>();
        public Autorization()
        {
            InitializeComponent();
            ReadXML();
        }
        private void ReadXML()
        {
            if (File.Exists("user.xml") == true)
            {

                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
                using (FileStream fs = new FileStream("user.xml", FileMode.Open))
                {
                    list = (List<User>)xmlSerializer.Deserialize(fs);
                }
            }
          
        }
        private void reg_btn_Click(object sender, RoutedEventArgs e)
        {
            Registration new_acc = new Registration();
            new_acc.ShowDialog();
            if (new_acc.DialogResult == true)
            {

                list.Clear();
                ReadXML();

             
            }
        }

        private void login_btn_Click(object sender, RoutedEventArgs e)
        {
            int count_acc=0;
            foreach (var el in list)
            {

                if (el.login == this.Login.Text && el.password == this.Pass.Password)
                {
                    user_name = el;
                    this.DialogResult = true;
                    this.Close();
                    break;
                }
                else
                    count_acc++;
               
            }
            if (count_acc == list.Count)
            {
                count_acc = 0;
                MessageBox.Show("Login or password is valid");
                this.Pass.Password = "";
                return;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          
            this.Close();
          //  MainWindow m = new MainWindow();
           // m.Close();
           
        }
    }
}
