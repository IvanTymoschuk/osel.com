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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Window
    {
        public List<User> list = new List<User>();
        public Registration()
        {
            InitializeComponent();
            this.City.Items.Add("RIVNE");
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
            User user = new User(this.Login.Text, this.Pass.Password, this.City.SelectedItem.ToString(), this.Phone.Text);
            list.Add(user);
             
           
            this.Close();
        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<User>));
            using (FileStream fs = new FileStream("user.xml", FileMode.Create))
            {
                xmlSerializer.Serialize(fs, list);
            }
        }
    }
}
