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
    /// Interaction logic for AddStationLine.xaml
    /// </summary>
    public partial class AddStationLine : Window
    {
        IBL bl;
       // BO.STATIONLINE add;
        BO.LINE ln;
        BO.STATIONLINE stationline;
        bool isFirst = false;
        public AddStationLine(IBL bl1,BO.LINE l, BO.STATIONLINE stationline1,bool isf)
        {
            isFirst = isf;
            stationline = stationline1;
            bl = bl1;
            ln = l;
            InitializeComponent();
            IEnumerable<BO.STATION> stationl = bl.GetALLSTATION();
            cmbStation.ItemsSource = stationl;
            if(isFirst==true)
            {
                txtDistance.Text =Convert.ToString( 0);
                txtFinishAtHour.Text = "0";
                txtFinishAtMiniute.Text = "0";
                txtFinishAtSecond.Text = "0";

            }
        }

        private void btnAddStationLine_Click(object sender, RoutedEventArgs e)
        {
            BO.STATIONLINE sl = new BO.STATIONLINE();
            BO.STATION a= (BO.STATION)cmbStation.SelectedItem;
            sl.CodeStation = a.Code;
            sl.StationName = a.Name;
            if(stationline!=null)
            sl.NextStation = stationline.CodeStation;// למה זה ריק????????????????
            // sl.NextStation   
            sl.LineCode = ln.Code;
            sl.Distance =Convert.ToDouble( txtDistance.Text);
            sl.Time = new TimeSpan(Convert.ToInt32(txtFinishAtHour.Text), Convert.ToInt32(txtFinishAtMiniute.Text), Convert.ToInt32(txtFinishAtSecond.Text));
            bl.AddSTATIONLINE(sl);
            SHOWALL sHOWALL = new SHOWALL(bl);
            sHOWALL.Show();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
