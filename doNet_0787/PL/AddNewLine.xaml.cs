﻿using BLAPI;
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
    /// Interaction logic for AddNewLine.xaml
    /// </summary>
    public partial class AddNewLine : Window
    {
        IBL bl;
        public AddNewLine( IBL bl1)
        {
            bl = bl1;
            InitializeComponent();
            cmbLineArea.ItemsSource = Enum.GetValues(typeof(BO.Emuns.AREA));
        }

        private void cmbLineArea_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSaveNewLine_Click(object sender, RoutedEventArgs e)
        {
            BO.LINE newL = new BO.LINE();
            newL.Code = Convert.ToInt32(txtLineCode.Text);
           newL.Area = (BO.Emuns.AREA)(cmbLineArea.SelectedItem);
           newL.FinishAt = new TimeSpan(Convert.ToInt32(txtFinishAtHour.Text), Convert.ToInt32(txtFinishAtMiniute.Text), Convert.ToInt32(txtFinishAtSecond.Text));
           newL.StartAt = new TimeSpan(Convert.ToInt32(txtStartAtHour.Text), Convert.ToInt32(txtStartAtMiniute.Text), Convert.ToInt32(txtStartAtSecond.Text));
            bl.AddLINE(newL);
            SHOWALL a = new SHOWALL(bl);
            a.Show();
        }
    }
}
