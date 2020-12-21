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
using static Buss;

namespace WpfApp3b
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ObservableCollection<Buss> listBUSS = new ObservableCollection<Buss>();
        //RandomBuses(listBUSS);
        public static bool degel = true;
        public MainWindow()
        {

            InitializeComponent();
            //DataContext = listBUSS;

            //random 10 buses
            if (degel)
            {
                for (int i = 1; i <= 10; i++)
                {
                    Random r = new Random();
                    Buss t = new Buss();
                    t.LicenseNumber = i.ToString();
                    t.Km = i * 10;
                    t.KmafterRefueling = r.Next(0, 100);
                    t.kMFromLastTreat = r.Next(0, 100);
                    DateTime d = new DateTime(r.Next(2000, 2020), r.Next(1, 12), r.Next(1, 30));
                    t.LastTreat = d;//להגריל תאריך
                    t.Status = 0;
                    listBUSS.Add(t);
                }
                listBUSS[0].kMFromLastTreat = 19999;
                listBUSS[1].KmafterRefueling = 1100;
                listBUSS[2].LastTreat = new DateTime(2019, 12, 13);


            }
            DataContext = listBUSS;

            degel = false;




        }
        // public MainWindow(int a) { DataContext = listBUSS; }
        private void lstBuses_MaouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var b =lstBuses.SelectedItem as Buss;
            WindowShowBus w3 = new WindowShowBus(b);
            w3.ShowDialog();

        }

        private void btnAddNewBuss_Click(object sender, RoutedEventArgs e)
        {
            Buss myNewBuss = new Buss();
            myNewBuss.LicenseNumber = " ";
            myNewBuss.Km = 0;
            myNewBuss.KmafterRefueling = 0;
            myNewBuss.LastTreat = new DateTime(1, 1, 1);
            myNewBuss.kMFromLastTreat = 0;
            myNewBuss.Status = Buss.StatusBus.ReadyForRide;
            Window2 myNew = new Window2(myNewBuss);
            myNew.ShowDialog();
            // listBUSS.Add(myNewBuss);
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var b = ((sender as Button).DataContext as Buss);
            if (b.Status != 0)
            {
                if(b.Status==StatusBus.Rufueling)
                    MessageBox.Show("bus is Rufueling");
                if (b.Status == StatusBus.inTreat)
                    MessageBox.Show("bus is inTreat");
                if (b.Status == StatusBus.inTreat)
                    MessageBox.Show("bus is inTreat");
                if (b.Status == StatusBus.inMiddleOfRide)
                    MessageBox.Show("bus is inMiddleOfRide");

                //MessageBox.Show("bus is not ready for ride");
                return;
            }
            Window1 w1 = new Window1(b);
            w1.ShowDialog();
            // listBUSS.Items.Refresh();
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            var b = ((sender as Button).DataContext as Buss);
            WindowRefueling w2 = new WindowRefueling(b);
            w2.ShowDialog();

        }

        private void lstBuses_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }

    }
