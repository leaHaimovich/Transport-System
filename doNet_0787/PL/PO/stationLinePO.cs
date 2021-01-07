using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PO
{
    public class stationLinePO : DependencyObject
    {
        public string Name { get; set; }
        public int Code { get; set; }//station number
        public double Distance { get; set; }
        public TimeSpan Time { get; set; }
    }
}
