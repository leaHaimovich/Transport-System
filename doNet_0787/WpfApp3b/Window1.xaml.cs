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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private Buss myb;
        private BackgroundWorker worker;
        private double k;
        public Window1(Buss b)
        {
            InitializeComponent();
            myb = b;
        }

        
        
        private void DistanceKeyDown_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.Key == Key.Enter)
            {
                double k1 = Convert.ToDouble(DistanceKeyDown.Text);
                  k = k1;
                Double a = myb.kMFromLastTreat;
                Double r = myb.KmafterRefueling;
                if ((a + k1) >= 20000 || (myb.LastTreat.Year + 1) > DateTime.Now.Year)
                {
                    MessageBox.Show("ERROR: cant go, need a treatment\n");
                    MainWindow m3 = new MainWindow();
                    m3.Show();
                    return;
                }
                if ((r + k1) > 1200)
                {
                    MessageBox.Show("ERROR: cant go, need to refueling\n");
                    MainWindow m2 = new MainWindow();
                    m2.Show();
                    return;
                }
                if (myb.LastTreat.Year > DateTime.Now.Year)
                {
                    MessageBox.Show("ERROR: need to go to treatment, over a year\n");
                    //return;
                    this.Close();
                    MainWindow m1 = new MainWindow();
                    m1.Show();
                    return;
                }
                worker = new BackgroundWorker();//Create a new show
                worker.DoWork += Driving;//adding func to the thred
                worker.RunWorkerAsync(myb as Buss);//Run the procession

                myb.Km = myb.Km + k1;
                myb.KmafterRefueling += k1;
                myb.kMFromLastTreat = myb.kMFromLastTreat + k1;
                // myb.Status = StatusBus.inMiddleOfRide;
                // myb.Status = StatusBus.ReadyForRide;
                this.Close();
                MainWindow m = new MainWindow();
                m.Show();
            }


        }
        
        private void Driving(object sender, DoWorkEventArgs e)
        {
            Buss bus = (e.Argument) as Buss;
            bus.DRIVING();
            myb.Km = myb.Km + k;
            myb.KmafterRefueling += k;
            myb.kMFromLastTreat = myb.kMFromLastTreat + k;
            // myb.Status = StatusBus.inMiddleOfRide;
            // myb.Status = StatusBus.ReadyForRide;
            //foo();
            bus.Status = StatusBus.inMiddleOfRide;
            Random r = new Random();
            int a=r.Next(20, 50);
            Thread.Sleep(((int)k*a*10));
            bus.Status = StatusBus.ReadyForRide;
        }
        private void NumberVaildTextBox(object sender, TextCompositionEventArgs e)
        {

            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }

        private void DistanceKeyDown_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
