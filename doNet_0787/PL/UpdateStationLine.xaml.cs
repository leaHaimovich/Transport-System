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
    /// Interaction logic for UpdateStationLine.xaml
    /// </summary>
    public partial class UpdateStationLine : Window
    {
        IBL bl;
        BO.STATIONLINE stl;
        public UpdateStationLine(IBL bl1, BO.STATIONLINE S)//,BO.STATIONLINE S
        {
            bl = bl1;
            stl = S;
            InitializeComponent();
        }

        private void btnUpdateLineStation_Click(object sender, RoutedEventArgs e)
        {
            BO.STATIONLINE sl = new BO.STATIONLINE();
            sl.StationName = txtStationName.Text;
            sl.Time = new TimeSpan(Convert.ToInt32(txtTimeHour.Text), Convert.ToInt32(txtTimeMiniute.Text), Convert.ToInt32(txtTimeSecond.Text));
            sl.Distance = Convert.ToDouble(txtDistance.Text);
            sl.CodeStation = stl.CodeStation;
            sl.NextStation = stl.LineCode;
            sl.LineCode = stl.LineCode;
            sl.LineCode = stl.LineCode;
            bl.updateSTATIONLINE(sl);
            SHOWALL a = new SHOWALL(bl);
            a.Show();
        }
    }
}