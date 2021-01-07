using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Buss;

namespace WpfApp3b
{
    /// <summary>
    /// Interaction logic for WindowRefueling.xaml
    /// </summary>
    public partial class WindowRefueling : Window
    {
        private Buss b;
        private BackgroundWorker worker;
        public WindowRefueling(Buss buss)
        {
            InitializeComponent();
            b = buss;
        }

        private void txtEnterNumberLiters_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void LitersKeyDown_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                double ltrs = Convert.ToDouble(LitersKeyDown.Text);
                b.KmafterRefueling = 0;
               // b.Status = StatusBus.Rufueling;
                worker = new BackgroundWorker();//Create a new show
                worker.DoWork += Refuling;//adding func to the thred
               worker.RunWorkerAsync(b);//Run the procession
                this.Close();
                MainWindow m = new MainWindow();
                m.Show();
            }
        }

            private void NumberVaildTextBox1(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        //private void refuling_Click(object sender, RoutedEventArgs e)
        //{
        //    worker = new BackgroundWorker();//Create a new show
        //    worker.DoWork += Refuling;//adding func to the thred
        //    worker.RunWorkerAsync((((sender as Button).DataContext) as Buss));//Run the procession

        //}
        private void Refuling(object sender, DoWorkEventArgs e)
        {
            Buss bus = (e.Argument) as Buss;
            bus.REFUELING();
            bus.Status = StatusBus.Rufueling;
            Thread.Sleep(12000);
            bus.Status = StatusBus.ReadyForRide;
        }

        private void LitersKeyDown_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
