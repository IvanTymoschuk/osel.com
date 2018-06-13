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
using System.Text.RegularExpressions;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public List<User> list = new List<User>();
        public User new_user= new User();
        public Registration()
        {
            this.DataContext = new_user;
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

       
            
         
                list.Add(new User(this.Login.Text, this.Pass.Password, this.City.Text, this.Phone.Text));
                MessageBox.Show("Please log in");
                this.DialogResult = true;
                using (FileStream fs = new FileStream("user.xml", FileMode.Create))
                {
                    XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<User>));
                    xmlSerializer.Serialize(fs, list);
                }
                this.Close();


        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {

          
        }

        bool pass_valid = false;
        private void Pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (progres.Value > 10)
                progres.Value -= 25;
        
            if (Pass.Password.Length >= 7)
                pass_valid = true;
            else
                pass_valid = false;

            if (pass_valid == true)
                progres.Value += 25;
            else
                progres.Value -= 25;
        }
    }
}
