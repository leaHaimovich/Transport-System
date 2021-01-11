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
    /// Interaction logic for UpdateLine.xaml
    /// </summary>
    public partial class UpdateLine : Window
    {
        IBL bl;
        BO.LINE ln;
        BO.STATIONLINE stationlinechhosen;
        bool isListOfLineStationIsChanged = false;
        IEnumerable<BO.STATIONLINE> FinalListStation;
        public UpdateLine(IBL bl1,BO.LINE l)
        {
           bl = bl1;
            ln = l;
            InitializeComponent();
            txtLineCode.Text =Convert.ToString( ln.Code);
            txtLineCode.IsEnabled = false;
           
            cmbArea.ItemsSource = Enum.GetValues(typeof(BO.Emuns.AREA));
            cmbArea.Text = Convert.ToString(ln.Area);
            ln.Area= (BO.Emuns.AREA)cmbArea.SelectedItem;
            DataContext = ln.StationListOfLine;
            FinalListStation = ln.StationListOfLine;

            if(l.StationListOfLine.ToList().Count==0)
            {
                btnAddFirstStationLine.Visibility = Visibility.Visible;
                //btnAddFirstStationLine.IsEnabled = true;
            }

           
        }
        private void btnAddFirstStationLine_Click(object sender, RoutedEventArgs e)
        {
            AddStationLine a = new AddStationLine(bl, ln, stationlinechhosen, true);
            a.Show();
        }
        
        private void btnDeleteStationLine_Click(object sender, RoutedEventArgs e)//Delete Station Line
        {
            BO.STATIONLINE sld = (BO.STATIONLINE)dataGridStationLINE.SelectedItem ;
            if (MessageBox.Show("?אתה בטוח שהינך רוצה למחוק תחנה זה", " מחיקת תחנת קו", MessageBoxButton.YesNo, MessageBoxImage.Question)
               == MessageBoxResult.Yes)
            {
                try { bl.DeleteSTATIONLINE(sld); }
                catch { MessageBox.Show("לא ניתן למחוק את התחנה, מכיון שהיא לא קיימת"); }
            }
            //לאתחל את הדטה גריד
        }
       private void btnAddStationLine_Click(object sender, RoutedEventArgs e)
        {
            BO.STATIONLINE x = (BO.STATIONLINE)dataGridStationLINE.SelectedItem;
            stationlinechhosen = x;
            AddStationLine a = new AddStationLine(bl,ln,stationlinechhosen,false);
            a.Show();
        }
        private void btnUpdateLine_Click(object sender, RoutedEventArgs e)
        {
            UpdateStationLine a = new UpdateStationLine(bl, (BO.STATIONLINE)dataGridStationLINE.SelectedItem,2);
            a.Show();
        }

        private void btnUpdateStationLine_Click(object sender, RoutedEventArgs e)
        {
            UpdateStationLine a = new UpdateStationLine(bl, (BO.STATIONLINE)dataGridStationLINE.SelectedItem, 2);
            a.Show();
        }

        private void btnUpdataLine_Click(object sender, RoutedEventArgs e)
        {
            BO.STATIONLINE x = (BO.STATIONLINE)dataGridStationLINE.SelectedItem;
            stationlinechhosen = x;
            BO.LINE upli = new BO.LINE();
            upli.Area = (BO.Emuns.AREA)cmbArea.SelectedItem;
            upli.Code = Convert.ToInt32(txtLineCode.Text);
            upli.FinishAt = ln.FinishAt;
            upli.StartAt = ln.StartAt;
            upli.Frequency = ln.Frequency;
            //if( isListOfLineStationIsChanged==false)
             // upli.StationListOfLine = FinalListStation;
            upli.StationListOfLine = ln.StationListOfLine;
            bl.UpdateLINE(upli);
            SHOWALL sHOWALL = new SHOWALL(bl);
            sHOWALL.Show();
        }

        private void cmbArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataGridStationLINE_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAddFirstStationLine_Click_1(object sender, RoutedEventArgs e)
        {

            AddStationLine a = new AddStationLine(bl, ln, stationlinechhosen, true);
            a.Show();
        }
    }
}
