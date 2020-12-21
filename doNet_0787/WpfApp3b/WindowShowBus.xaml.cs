using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
    /// Interaction logic for WindowShowBus.xaml
    /// </summary>
    public partial class WindowShowBus : Window
    {
        private Buss buss;
        private BackgroundWorker worker;
        public WindowShowBus(Buss b)
        {
            InitializeComponent();
            buss = b;
            //lblBusData = new Label();
            DataContext = b;
            lblBusData.Content = b.PrintBuss();
            lblBusData.Content = b.PrintBuss();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowRefueling w1 = new WindowRefueling(buss);
            w1.ShowDialog();
        }

        private void btnTreatment_Click(object sender, RoutedEventArgs e)
        {
            worker = new BackgroundWorker();//Create a new show
            worker.DoWork += treatment;//adding func to the thred
             worker.RunWorkerAsync((((sender as Button).DataContext) as Buss));//Run the procession
            buss.kMFromLastTreat = 0;
            buss.LastTreat = DateTime.Now;
            //buss.Status = StatusBus.inTreat;
            MessageBox.Show("Bus was sent for treatment, the treatment was successful!");
            this.Close();
            MainWindow m = new MainWindow();
            m.Show();
            
        }
        //private void refuling_Click(object sender, RoutedEventArgs e)
        //{
        //    worker = new BackgroundWorker();//Create a new show
        //    worker.DoWork += Refuling;//adding func to the thred
        //    worker.RunWorkerAsync((((sender as Button).DataContext) as Buss));//Run the procession

        //}
        private void treatment(object sender, DoWorkEventArgs e)
        {
            Buss bus = (e.Argument) as Buss;
            bus.TRETMENT();
            bus.Status = StatusBus.inTreat;
            Thread.Sleep(14400);
            bus.Status = StatusBus.ReadyForRide;
        }
    }
}
