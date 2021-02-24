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
using BLAPI;
namespace PL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IBL bl = BLFactory.GetBL("1");
        public MainWindow()
        {
            InitializeComponent();
        }

        public void btnGo_Click(object sender, RoutedEventArgs e)
        {
            
            if (rbUser.IsChecked == true)
            {
                ManagerManue a = new ManagerManue(bl, false);
                a.Show();
            }
            else if (rbManagare.IsChecked == true)
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("כדי להיכנס להרשאת מנהל עליך להזין תעודת זהות");
                    return;
                }
                int id =int.Parse( txtID.Text);
                
                string name = txtpasswort.Text;
                bool ismanager=bl.isManagerB(id, name);
                if (ismanager)
                {
                    ManagerManue a = new ManagerManue(bl, ismanager);
                    a.Show();
                }
                else
                {
                    MessageBox.Show("אין לך הרשאת גישה");
                }
               // SHOWALL sHOWALL = new SHOWALL(bl);
                //sHOWALL.Show();
                //LecturerWindow win = new LecturerWindow(bl);
                //win.Show();
                //  MessageBox.Show("This method is under construction!", "TBD", MessageBoxButton.OK, MessageBoxImage.Asterisk);
            }
            else
            {
                //CoursesWindow win = new CoursesWindow(bl);
                //win.Show();
                MessageBox.Show("This method is under construction!", "TBD", MessageBoxButton.OK, MessageBoxImage.Asterisk);


            }
        }

        private void rbUser_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
