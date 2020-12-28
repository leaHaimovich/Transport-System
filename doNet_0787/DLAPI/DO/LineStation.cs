using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
   public class LineStation
    {
        public int LineID { get; set; }//id of line
        public int Station { get; set; }//station code
        public int LineStationIndex { get; set; }//Station number on line
        public int PrevStation { get; set; }//prev Station
        public int NextStation { get; set; }// next station 

    }
}
