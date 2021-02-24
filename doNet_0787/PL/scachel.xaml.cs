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
    /// Interaction logic for scachel.xaml
    /// </summary>
    public partial class scachel : Window
    {
        IBL bl;
        bool isManager;
        public scachel(IBL b1, bool ismang)
        {
            isManager = ismang;
            bl = b1;
            InitializeComponent();
            lstLines.DataContext = bl.GetAllLINES();
           if(!isManager)
            {
                btnAdd.IsEnabled = false;
                btnDelete.IsEnabled = false;
            }
        }

        private void dataGridScachel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void lstLines_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstLines.SelectedItem != null)
            {
                BO.LINE l = bl.GetLINE((lstLines.SelectedItem as BO.LINE).Code, (lstLines.SelectedItem as BO.LINE).Area);
                IEnumerable<BO.LINETRIP> h = bl.getAllLineTripOfOneLine(l.Code);
                dataGridScachel.DataContext = h;
            }
            else
            {
                lstLines.SelectedItem = default;

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddScachel addScachel = new AddScachel(bl, lstLines.SelectedItem as BO.LINE);
            addScachel.ShowDialog();
            lstLines.DataContext = bl.GetAllLINES();
            if (lstLines.SelectedItem != null)
            {
                BO.LINE l = bl.GetLINE((lstLines.SelectedItem as BO.LINE).Code, (lstLines.SelectedItem as BO.LINE).Area);
                IEnumerable<BO.LINETRIP> h = bl.getAllLineTripOfOneLine(l.Code);
                dataGridScachel.DataContext = h;
            }
            else
            {
                lstLines.SelectedItem = default;

            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if(dataGridScachel.SelectedItem==null)
                {
                MessageBox.Show("יש לבחור קו בשעת יציאה למחיקה");
                return;
               }
            bl.DeleteLINETRIP((dataGridScachel.SelectedItem as BO.LINETRIP).LineID, (dataGridScachel.SelectedItem as BO.LINETRIP).StartAt);
        }
    }
}
