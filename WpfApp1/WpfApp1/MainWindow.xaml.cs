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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Advertisment> adverts = new ObservableCollection<Advertisment>();

        public MainWindow()
        {
            InitializeComponent();
            adverts.Add(new Advertisment("Tovar", 50, "Dich", "Govnotovary","Rivne", new DateTime(2018, 6, 7, 15, 15, 0)));
            adverts.Add(new Advertisment("Aovar",45, "Dich", "Govnotovary", "Rivne", new DateTime(2018,6,7,15,0,0)));
            adverts.Add(new Advertisment("Novar", 68, "Dich", "Govnotovary", "Rivne", DateTime.Now));



            ModeSort.Items.Add("Price UP");
            ModeSort.Items.Add("Price DOWN");
            ModeSort.Items.Add("Type");
            ModeSort.Items.Add("Name");
            ModeSort.Items.Add("City");
            ModeSort.Items.Add("Date");



            View.ItemsSource =adverts;
            //DONT USE!!!!!!
            Autorization aut = new Autorization();
            aut.ShowDialog();
            if (aut.DialogResult == false)
                this.Close();
            this.Title ="Osel.com CONECTED: "+ aut.user_name;
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

        }

        private void MyRoom_Click(object sender, RoutedEventArgs e)
        {
            Add add = new Add();
            add.ShowDialog();
        }
    }

}
