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

namespace WpfApp3b
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
       
        public Window1()
        {
            InitializeComponent();
        }
        public Window1(Buss bs)
        {
            InitializeComponent();
            DataContext = bs;
           
        }

        private void txtLicenseNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource bussViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bussViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // bussViewSource.Source = [generic data source]
        }

        private void bussListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bussListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {

        }

        private void bussListView_SelectionChanged_2(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource bussViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("bussViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // bussViewSource.Source = [generic data source]
        }

        private void bussListView_SelectionChanged_3(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
