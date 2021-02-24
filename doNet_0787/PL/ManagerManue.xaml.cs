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
        bool isManager = false;
        public ManagerManue(IBL bl1, bool ismang)
        {
            bl = bl1;
            isManager = ismang;
            InitializeComponent();
        }

        private void btnLines_Click(object sender, RoutedEventArgs e)
        {
            SHOWALL sHOWALL = new SHOWALL(bl,isManager);
            sHOWALL.Show();
        }

        private void btnStation_Click(object sender, RoutedEventArgs e)
        {
            Stations stations = new Stations(bl, isManager);
            stations.Show();
        }

        

        private void rbLines_Checked(object sender, RoutedEventArgs e)
        {
           
        }

        private void rbUser_Checked(object sender, RoutedEventArgs e)
        {
            
        }
        public void rbscachel_Checked(object sender, RoutedEventArgs e) { }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            if (rbLines.IsChecked == true)
            {
                SHOWALL sHOWALL = new SHOWALL(bl, isManager);
                sHOWALL.Show();
            }
            if(rbStation.IsChecked==true)
            {
                Stations stations = new Stations(bl, isManager);
                stations.Show();
            }
            if(rbscachel.IsChecked==true)
            {
                scachel scachel = new scachel(bl, isManager);
                scachel.Show();
            }
        }
    }
    }

