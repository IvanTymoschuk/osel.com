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
            adverts.Add(new Advertisment("Tovar", "50$", "Dich", "Govnotovary","Rivne", DateTime.Now));
            adverts.Add(new Advertisment("Tovar", "50$", "Dich", "Govnotovary", "Rivne", DateTime.Now));
            View.ItemsSource =adverts;
            //DONT USE!!!!!!
            //Autorization aut = new Autorization();
           // aut.Show();
        }

    }

}
