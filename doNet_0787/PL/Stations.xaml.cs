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
    /// Interaction logic for Stations.xaml
    /// </summary>
    public partial class Stations : Window
    {
        IBL bl;
        public BO.STATION bs = new BO.STATION();
        public Stations(IBL bl1)
        {
            bl = bl1;
            InitializeComponent();
            stationDataGrid.ItemsSource = bl.GetALLSTATION();
        }

        private void stationDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (stationDataGrid.SelectedItem != null)
            {
                bs = (stationDataGrid.SelectedItem as BO.STATION);
                bs = bl.GetSTATION(bs.Code);
                lineStationDataGrid.ItemsSource = bs.LinesAdjacentStations;
                lineDataGrid.ItemsSource = bs.LinesOnThisStation;
                txtStationName.Text = bs.Name;
                txtStationCode.Text = bs.Code.ToString();
            }
            else { stationDataGrid.SelectedItem = default; }
        }

        private void txtStationCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnAddStation_Click(object sender, RoutedEventArgs e)
        {
            AddStation add = new AddStation(bl);
            add.ShowDialog();
            // stationDataGrid.Items.Refresh();
            stationDataGrid.ItemsSource = bl.GetALLSTATION();
        }

        private void btnDeletStation_Click(object sender, RoutedEventArgs e)
        {
            if (stationDataGrid.SelectedIndex == -1) { MessageBox.Show("יש לבחור תחנה למחיקה"); }
            BO.STATION s = stationDataGrid.SelectedItem as BO.STATION;
            IEnumerable<BO.LINE> l = bl.GetAllLinesPassByStation(s.Code);

            if (l.Any())
                MessageBox.Show("לתחנה ישנם קוים שעוברים בה.אינך יכול למחוק אותה");
            else if (MessageBox.Show("האם אתה בטוח שברצונך למחוק תחנה זו?", "מחיקת תחנה", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try { bl.DeleteSTATION(s.Code); }
                catch { MessageBox.Show("התחנה אינה קיימת במערכת"); }
                stationDataGrid.ItemsSource = bl.GetALLSTATION();

            }
        }

        private void btnUpdatStation_Click(object sender, RoutedEventArgs e)
        {

            if (stationDataGrid.SelectedIndex == -1) { MessageBox.Show("יש לבחור תחנה לעדכון"); }
            BO.STATION s = stationDataGrid.SelectedItem as BO.STATION;
            int i = (stationDataGrid.SelectedItem as BO.STATION).Code;
            s.Name = txtStationName.Text;
            if (MessageBox.Show("האם אתה בטוח שברצונך לעדכן תחנה זו?", "עדכון תחנה", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try { bl.UpdateSTATION(s); }
                catch { MessageBox.Show("התחנה אינה קיימת במערכת"); }
                stationDataGrid.ItemsSource = bl.GetSortStations();
            }
        }
    }
}
