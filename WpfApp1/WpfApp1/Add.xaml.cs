using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.IO;
using System.Xml.Serialization;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        private User user;
        ObservableCollection<Advertisment> adverts;
        public Add(User user, ObservableCollection<Advertisment> adverts)
        {
            InitializeComponent();
            this.user = user;
            this.adverts = adverts;
         }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(this.Name.Text)==true|| String.IsNullOrEmpty(this.Descript.Text) == true|| String.IsNullOrEmpty(this.City.Text) == true|| String.IsNullOrEmpty(this.Price.Text) == true|| String.IsNullOrEmpty(this.Type.Text) == true)
            {
                MessageBox.Show("Please input all field");
                return;
            }
            else
            {
                int price;
                try
                {
                   price = int.Parse(this.Price.Text); 
                }
                catch(Exception)
                {
                    MessageBox.Show("Valid PRICE ");
                    return;
                }
                adverts.Add( new Advertisment(this.Name.Text, price, this.Descript.Text, this.Type.Text, this.City.Text, DateTime.Now, user));
                DialogResult = true;
                this.Close();
            }
        }

        private void close_btn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
