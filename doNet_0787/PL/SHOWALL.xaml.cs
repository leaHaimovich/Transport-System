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
        BO.LINE line;
        public SHOWALL(IBL bl1)
        {
            bl = bl1;
            InitializeComponent();
            DatatGridLines.IsReadOnly = true;
            lst.DataContext = bl.GetAllLINES();
            if(lst.SelectedItem!=null)
            {
                BO.LINE l = bl.GetLINE((lst.SelectedItem as BO.LINE).Code, (lst.SelectedItem as BO.LINE).Area);
                DatatGridLines.ItemsSource = bl.GetAllLineStationsByLineCode(l.Code);
                line = l;
            }
           // btnLines.IsEnabled = false;
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
            a.ShowDialog();
            BO.LINE line1 = bl.GetLINE((lst.SelectedItem as BO.LINE).Code, (lst.SelectedItem as BO.LINE).Area);
            DatatGridLines.ItemsSource = bl.GetAllLineStationsByLineCode(line1.Code);
        }
        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (lst.SelectedItem != null)
            {
                BO.LINE l = bl.GetLINE((lst.SelectedItem as BO.LINE).Code, (lst.SelectedItem as BO.LINE).Area);
                DatatGridLines.ItemsSource = bl.GetAllLineStationsByLineCode(l.Code);
                //DatatGridLines.ItemsSource= bl.GetALLSTATION().ToList();
                //DatatGridLines.DataContext = l.StationListOfLine.ToList();
                //DataContext = l.StationListOfLine.ToList();
                //DatatGridLines.ItemsSource = l.StationListOfLine;
            }
            else
            {
                lst.SelectedItem = default;
               
            }
            

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
            if (lst.SelectedItem == null) { MessageBox.Show("הקש את הקו המבוקש ואז הקש מחק "); return; }
            BO.LINE dl1=(lst.SelectedItem) as BO.LINE;
            if (MessageBox.Show("?אתה בטוח שהינך רוצה למחוק קו זה", " מחיקת קו", MessageBoxButton.YesNo, MessageBoxImage.Question)
                == MessageBoxResult.Yes)
                {
                try { bl.DeleteLINE(dl1.Code, dl1.Area); }
                catch { MessageBox.Show("שגיאה: קו זה לא נמצא במערכת "); }
                lst.DataContext = bl.GetAllLINES();
                DatatGridLines.ItemsSource = default;
                //BO.LINE l = bl.GetLINE((lst.SelectedItem as BO.LINE).Code, (lst.SelectedItem as BO.LINE).Area);
                //DatatGridLines.DataContext = l.StationListOfLine.ToList();
                //DataContext = l.StationListOfLine.ToList();

            }
                          
                    
        }

        private void btnUpdateLine_Click(object sender, RoutedEventArgs e)
        {
            if (lst.SelectedItem == null) { MessageBox.Show("הקש את הקו המבוקש ואז לחץ על עדכון");  return; }
           
                BO.LINE l2 = (lst.SelectedItem) as BO.LINE;
                UpdateLine update = new UpdateLine(bl, (lst.SelectedItem) as BO.LINE);
                update.Show();

            DatatGridLines.ItemsSource = bl.GetAllLineStationsByLineCode(l2.Code);
            lst.DataContext = bl.GetAllLINES();
            // BO.LINE l=bl.GetLINE(lst.SelectedItema BO.LINE).Code, (lst.SelectedItem as BO.LINE).Area);
            //if (lst.SelectedIndex == -1) lst.SelectedItem = default;
            //BO.LINE l = bl.GetLINE((lst.SelectedItem as BO.LINE).Code, (lst.SelectedItem as BO.LINE).Area);
            DatatGridLines.ItemsSource = default;
          //  DatatGridLines.ItemsSource = bl.GetAllLineStationsByLineCode(l2.Code);

        }
    }
}
