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

namespace WpfApp3b
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Buss> listBUSS = new ObservableCollection<Buss>();
        //RandomBuses(listBUSS);
        public MainWindow()
        {

            InitializeComponent();
            //DataContext = listBUSS;

            //random 10 buses
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
                listBUSS.Add(t);
            }
            listBUSS[0].kMFromLastTreat = 19999;
            listBUSS[1].KmafterRefueling = 1100;
            listBUSS[2].LastTreat = new DateTime(2019, 12, 13);


            DataContext = listBUSS;






        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

      
      }

        private void btnAddNewBuss_Click(object sender, RoutedEventArgs e)
        {
            Buss myNewBuss = new Buss();
            myNewBuss.LicenseNumber = " ";
            myNewBuss.Km = 0;
            myNewBuss.KmafterRefueling = 0;
            myNewBuss.LastTreat = new DateTime(0, 0, 0);
            myNewBuss.kMFromLastTreat = 0;
            myNewBuss.Status = 0;
            Window1 myNew = new Window1(myNewBuss);
        }
    }

}
