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
    /// Interaction logic for SHOWALL.xaml
    /// </summary>
    public partial class SHOWALL : Window
    {
        IBL bl;
        public SHOWALL(IBL bl1)
        {
            bl = bl1;
            InitializeComponent();
            DatatGridLines.IsReadOnly = true;
        }

        private void btnLines_Click(object sender, RoutedEventArgs e)
        {
         lst.DataContext =bl.GetAllLINES();
            btnLines.IsEnabled = false;
            
          
        }
        private void lst__MaouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //DatatGridLines.DataContext = (lst.SelectedItem as BO.LINE).StationListOfLine;

        }
        private void btnUpdateStationLine_Click(object sender, RoutedEventArgs e)//פונקצציה לעידכון תחנת קו
        {
           // UpdateStationLine a = new UpdateStationLine(bl);
            BO.STATIONLINE z= (BO.STATIONLINE)DatatGridLines.SelectedItem;
            UpdateStationLine a = new UpdateStationLine(bl,z,1);
            a.Show();
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (lst.SelectedItem != null)
            {
                BO.LINE l = bl.GetLINE((lst.SelectedItem as BO.LINE).Code, (lst.SelectedItem as BO.LINE).Area);
                DatatGridLines.DataContext = l.StationListOfLine.ToList();
                DataContext = l.StationListOfLine.ToList();
            }
            else
            {
                lst.SelectedItem = default;
                //BO.LINE l=bl.GetLINE()
            }
            // DatatGridLines.ItemsSource= l.StationListOfLine;

        }

        private void DatatGridLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAddLine_Click(object sender, RoutedEventArgs e)
        {
            AddNewLine a = new AddNewLine(bl);
            a.Show();
        }

        private void btnDeleteLine_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("?אתה בטוח שהינך רוצה למחוק קו זה", " מחיקת קו", MessageBoxButton.YesNo);
            
            BO.LINE dl1=(lst.SelectedItem) as BO.LINE;
            if (MessageBox.Show("?אתה בטוח שהינך רוצה למחוק קו זה", " מחיקת קו", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
                {
                try { bl.DeleteLINE(dl1.Code, dl1.Area); }
                catch { MessageBox.Show("שגיאה: קו זה לא נמצא במערכת "); }
                lst.DataContext = bl.GetAllLINES();
                //BO.LINE l = bl.GetLINE((lst.SelectedItem as BO.LINE).Code, (lst.SelectedItem as BO.LINE).Area);
                //DatatGridLines.DataContext = l.StationListOfLine.ToList();
                //DataContext = l.StationListOfLine.ToList();

            }
            
               
          
            
           
        }

        private void btnUpdateLine_Click(object sender, RoutedEventArgs e)
        {
            UpdateLine update = new UpdateLine(bl, (lst.SelectedItem) as BO.LINE);
            update.Show();
        }
    }
}
