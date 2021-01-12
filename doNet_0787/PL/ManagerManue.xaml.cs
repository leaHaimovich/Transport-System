using BLAPI;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for ManagerManue.xaml
    /// </summary>
    public partial class ManagerManue : Window
    {
        IBL bl;
        public ManagerManue(IBL bl1)
        {
            bl = bl1;
            InitializeComponent();
        }

        private void btnLines_Click(object sender, RoutedEventArgs e)
        {
            SHOWALL sHOWALL = new SHOWALL(bl);
            sHOWALL.Show();
        }

        private void btnStation_Click(object sender, RoutedEventArgs e)
        {
            Stations stations = new Stations(bl);
            stations.Show();
        }
    }
}
