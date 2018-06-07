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
            adverts.Add(new Advertisment("Tovar", 50, "Dich", "Govnotovary","Rivne", DateTime.Now));
            adverts.Add(new Advertisment("Aovar", 50, "Dich", "Govnotovary", "Rivne", DateTime.Now));
            adverts.Add(new Advertisment("Novar", 50, "Dich", "Govnotovary", "Rivne", DateTime.Now));



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
            switch(ModeSort.SelectionBoxItem.ToString())
            {
                case "Name":
                    adverts.OrderBy(k => k);
                    //adverts.
                    break;
            }
        }
    }

}
