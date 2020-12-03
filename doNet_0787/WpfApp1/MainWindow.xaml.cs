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
using System.Windows.Navigation;
using System.Windows.Shapes;
/*Lea haimovich 324240787
 * Bat sheva cohen 211735626
 */
namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BusCompany lines;
        private LineBus currentDisplayBusLine;
        //static Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
            List<BusStop> listOfStations = new List<BusStop>();
            Random rnd = new Random();
            for (int i = 0;i < 40;i++)//added 40 random stations
            {
                BusStop b = new BusStop(i + 100, "", rnd.NextDouble() + 10 * i, rnd.NextDouble() + 10 * (i + 1));
                listOfStations.Add(b);
            }

            Random r = new Random();
             lines = new BusCompany();
            int z = 0;
            for (int i = 0; i < 10; i++)
            {
                LineBus a = new LineBus();
                a.numBus = i;
                
                List<LineStation> lineStation = new List<LineStation>();
                for (int j=i;j<i+4;j++)
                {                  
                    lineStation.Add(new LineStation(listOfStations[z], j * 8, j + 20));
                    z++;
                }
                a.firstStation = lineStation[0];
                a.lastStation = lineStation[2];
                a.lineRoute = lineStation;
                if (i < 6)
                    a.area = (AREA)i;
                else a.area = (AREA)i - 5;
                lines.addLine(a);    
                

            }


            cbBusLines.ItemsSource = lines.listOfBuses;
            cbBusLines.DisplayMemberPath = " numBus ";
            cbBusLines.SelectedIndex = 0;
            ShowBusLine(cbBusLines.SelectedIndex);
            tbArea.Text = lines[0].area.ToString();

        }


         public void ShowBusLine(int index)
        {
            currentDisplayBusLine = lines[index];//.ToString();
            UpGrid.DataContext = currentDisplayBusLine;
            lbBusLineStations.DataContext = currentDisplayBusLine.LineRoute;
            tbArea.DataContext = lines[index].area;
            tbArea.Text = lines[index].area.ToString();
        }

        private void cbBusLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine((cbBusLines.SelectedValue as LineBus).numBus);
            tbArea.Text = lines[(cbBusLines.SelectedValue as LineBus).numBus].area.ToString();
           // lbBusLineStations.DataContext = lines[(cbBusLines.SelectedValue as LineBus).numBus].LineRoute;
        }

        private void lbBusLineStations_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ShowBusLine(cbBusLines.SelectedIndex);
        }

        private void tbArea_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
   
