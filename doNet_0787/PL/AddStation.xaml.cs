using BLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for AddStation.xaml
    /// </summary>
    public partial class AddStation : Window
    {
        IBL bl;
        public BO.STATION bs = new BO.STATION();
        public AddStation(IBL bl1)
        {
            bl= bl1;
            InitializeComponent();
            cbarea.ItemsSource = Enum.GetValues(typeof(BO.Emuns.AREA));


        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            //input is only numbers
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void btnAddStation_Click(object sender, RoutedEventArgs e)
        {
            if ((txtcode.Text.Length) > 5 || txtcode.Text.Length < 5)
            { MessageBox.Show("הקש קוד בן 5 ספרות בלבד"); }

            else
            {
                bs.Code = int.Parse(txtcode.Text);
            }
            bs.Name = txtname.Text;

            bs.area = (BO.Emuns.AREA)cbarea.SelectedItem;
            try
            {
                bl.AddSTATION(bs);
                MessageBox.Show("התחנה נוספה בהצלחה");
                this.Close();
            }
            catch (BO.OlreadtExistExceptionBO ex)
            {
                MessageBox.Show("התחנה כבר קיימת במערכת");
            }
        }
    }
}
