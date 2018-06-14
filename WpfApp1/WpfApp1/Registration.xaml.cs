using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
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


        #region
        //-------------------------------
        //System var dont change!!!!
        bool city_cheng = false;
        bool pas = false;
        bool pass = false;
        bool phone_valid = false;
        bool phone_novalid = false;
        bool login_valid = false;
        bool login_novalid = false;

        #endregion


        public Registration()
        {
            this.DataContext = new_user;
            InitializeComponent();
            ReadXML();
            Cities cities = new Cities();
            City.ItemsSource = cities.getCities();
          
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

       
            
         
                list.Add(new User(this.Login.Text, this.Pass.Password, this.City.SelectedItem.ToString(), this.Phone.Text));
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

    
        private void progres_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (progres.Value == 100)
                reg_btn.IsEnabled = true;
            else
                reg_btn.IsEnabled = false;
        
        }


        private void Pass_PasswordChanged(object sender, RoutedEventArgs e)
        {
           // progres.Value = 75;
            if (Pass.Password.Length < 7)
            {
                if (pass == true)
                {
                    pas = false;
                        progres.Value -= 25;
                    pass = false;
                }
            }
            else
            {
                if (pas == false)
                {
                        progres.Value += 25;
                    pas = true;
                    pass = true;
                }
            }
        }

        private void Phone_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Validation.GetHasError(Phone) == false)
                    if (phone_valid == false)
                    {
                        progres.Value += 25;
                        phone_novalid = true;
                        phone_valid = true;
                    }
                if (Validation.GetHasError(Phone) == true)
                    if (phone_novalid == true)
                    {
                        phone_novalid = false;
                        progres.Value -= 25;
                        phone_valid = false;
                    }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
             
        }

        private void Login_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (Validation.GetHasError(Login) == false)
                    if (login_valid == false)
                    {
                        progres.Value += 25;
                        login_novalid = true;
                        login_valid = true;
                    }
                if (Validation.GetHasError(Login) == true)
                    if (login_novalid == true)
                    {
                        login_novalid = false;
                        progres.Value -= 25;
                        login_valid = false;
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void City_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (city_cheng == false)
            {
                city_cheng = true;
                progres.Value += 25;
            }
        }
    }
}
