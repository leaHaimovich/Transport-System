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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        private Buss mybuss;
        public Window2(Buss b)
        {
            InitializeComponent();
            DataContext = b;
            mybuss = b;
        }

        private void txtKilometer_TextChanged(object sender, TextChangedEventArgs e)
        {
            mybuss.Km = Convert.ToDouble(txtKilometer.Text);
        }

        private void txtlKilometerAfterTreat_TextChanged(object sender, TextChangedEventArgs e)
        {
            mybuss.kMFromLastTreat = Convert.ToDouble(txtlKilometerAfterTreat.Text);
        }

        private void txtKilometersAfterRefueling_TextChanged(object sender, TextChangedEventArgs e)
        {
            mybuss.KmafterRefueling = Convert.ToDouble(txtKilometersAfterRefueling.Text);
        }
        private void dpDaeOfLastTreat_TextChanged(object sender, TextChangedEventArgs e)
        {
            mybuss.LastTreat = Convert.ToDateTime(dpDaeOfLastTreat.SelectedDate);
        }

        private void txtLincesNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            mybuss.LicenseNumber = txtLincesNumber.Text;
        }

        private void txtStatus_TextChanged(object sender, TextChangedEventArgs e)
        {
            //mybuss.Status = txtStatus.Text;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            // mybuss.Km = Convert.ToDouble(txtKilometer.Text);
            //mybuss.Status = (Buss.StatusBus)txtStatus.Text;
            // mybuss.LicenseNumber = Convert.ToString(txtLincesNumber);
            MainWindow.listBUSS.Add(mybuss);
             MainWindow m = new MainWindow();
            m.Show();

        }
        
    }
}
