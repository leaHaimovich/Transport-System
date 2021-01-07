using PO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace PL.PO
{
    public class linePO : DependencyObject
    {


        public int Code
        {
            get { return (int)GetValue(CodeProperty); }
            set { SetValue(CodeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Code.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CodeProperty =
            DependencyProperty.Register("Code", typeof(int), typeof(linePO), new PropertyMetadata(0));



        public BO.Emuns.AREA Area
        {
            get { return (BO.Emuns.AREA)GetValue(AreaProperty); }
            set { SetValue(AreaProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Area.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AreaProperty =
            DependencyProperty.Register("Area", typeof(BO.Emuns.AREA), typeof(linePO), new PropertyMetadata(0));



        public IEnumerable<BO.STATIONLINE> StationListOfLine
        {
            get { return (IEnumerable<BO.STATIONLINE>)GetValue(StationListOfLineProperty); }
            set { SetValue(StationListOfLineProperty, value); }
        }

        // Using a DependencyProperty as the backing store for StationListOfLine.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StationListOfLineProperty =
            DependencyProperty.Register("StationListOfLine", typeof(IEnumerable<BO.STATIONLINE>), typeof(linePO), new PropertyMetadata(0));

        public ObservableCollection<stationLinePO> StationListOfLineOB { get; } = new ObservableCollection<stationLinePO>();
    }
}
