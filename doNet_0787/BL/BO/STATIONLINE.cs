using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
   public class STATIONLINE
    {
        //public int LineID { get; set; }
        public string StationName { get; set; }
        public int CodeStation { get; set; }//cobe station 1
        public int LineCode { get; set; }//lune number//name of line
        //public int PrevStation { get; set; }
        public int NextStation { get; set; }//CODESTATION2
        public double Distance { get; set; }
        public TimeSpan Time { get; set; }
        public override string ToString()
        {
            string str = " StationName:" + StationName + " CodeStation: " + CodeStation + " Distance:" + Distance + " Time:" + Time;
            return str;
        }
    }
}
