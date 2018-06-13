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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


       public ObservableCollection<Advertisment> adverts = new ObservableCollection<Advertisment>();

        public MainWindow()
        {
            InitializeComponent();
       
             
            
            ModeSort.Items.Add("Price UP");
            ModeSort.Items.Add("Price DOWN");
            ModeSort.Items.Add("Type");
            ModeSort.Items.Add("Name");
            ModeSort.Items.Add("City");
            ModeSort.Items.Add("Date");
            ListItem.IsChecked = true;

            ReadXML();
            View.ItemsSource = adverts;
            //DONT USE!!!!!!

            Loginned();
           
        }
        private User user;
        private void Loginned()
        {
            Autorization aut = new Autorization();
            aut.ShowDialog();
            if (aut.DialogResult == false)
            {
                this.Close();
                return;
            }
            this.Title = "Osel.com CONECTED: " + aut.user_name.login;
            user = aut.user_name;
        }

        private void ReadXML()
    {
        if (File.Exists("tovar.xml") == true)
        {

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Advertisment>));
            using (FileStream fs = new FileStream("tovar.xml", FileMode.Open))
            {
                    adverts = (ObservableCollection<Advertisment>)xmlSerializer.Deserialize(fs);
            }
        }
    }
    private void ModeSort_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(ModeSort.SelectedItem.ToString())
            {
                case "Name":

                    adverts = new ObservableCollection<Advertisment>( adverts.OrderBy(k => k.Name));
                   
                    break;
                case "Price UP":
                    adverts = new ObservableCollection<Advertisment>(adverts.OrderBy(k => k.Price));
                    break;
                case "Price DOWN":
                    adverts = new ObservableCollection<Advertisment>(adverts.OrderByDescending(k => k.Price));
                    break;
                case "Type":
                    adverts = new ObservableCollection<Advertisment>(adverts.OrderBy(k => k.Type));
                    break;
                case "City":
                    adverts = new ObservableCollection<Advertisment>(adverts.OrderBy(k => k.City));
                    break;
                case "Date":
                    adverts = new ObservableCollection<Advertisment>(adverts.OrderBy(k => k.Date));
                    break;

            }
            View.ItemsSource = adverts;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
             using (FileStream fs = new FileStream("tovar.xml", FileMode.Create))
                        {
                            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Advertisment>));
                            xmlSerializer.Serialize(fs, adverts);
                        }
        }

        private void MyRoom_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add(user, adverts);
            add.ShowDialog();
            if(add.DialogResult==true)
            View.ItemsSource = adverts;
         
        }

        private void View_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Description description = new Description(adverts[View.SelectedIndex]);
            description.Show();
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SwitchBut_IsCheckedChanged(object sender, EventArgs e)
        {

        }

        private void TileItem_Click(object sender, RoutedEventArgs e)
        {
            if (TileItem.IsChecked == true)
                ListItem.IsChecked = false;

            View.ItemsPanel = Application.Current.TryFindResource("ItemsTempTile") as ItemsPanelTemplate;
        }

        private void ListItem_Click(object sender, RoutedEventArgs e)
        {
            if (ListItem.IsChecked == true)
                TileItem.IsChecked = false;
            View.ItemsPanel = Application.Current.TryFindResource("ItemsTempList") as ItemsPanelTemplate;


        }
    }

}
