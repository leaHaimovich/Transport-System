using BLAPI;
using BO;
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
    /// Interaction logic for AddScachel.xaml
    /// </summary>
    public partial class AddScachel : Window
    {
        IBL bl;
        LINE l;
        public AddScachel(IBL b1, LINE l1)
        {
            InitializeComponent();
            bl = b1;
            l = l1;
            txtLineID.Text =Convert.ToString( l.Code);
            txtLineID.IsEnabled = false;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if(txthour.Text=="" && txtminit.Text=="" && txtsecond.Text=="")
            { MessageBox.Show("נא מלא את שעת היציאה"); }
            TimeSpan start = new TimeSpan(int.Parse(txthour.Text), int.Parse(txtminit.Text), int.Parse(txtsecond.Text));
            try { 
            bl.AddLINETRIP(l.Code, start);
            }
            catch
            {
                MessageBox.Show("לא ניתן להוסיף זמן תדירות זה לקו הנידרש");
            }
            this.Close();
        }
    }
}
