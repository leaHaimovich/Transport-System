using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LineStation1
    {
        public int LineID { get; set; }//id of line
       public  string StationName { get; set; }// station name
        public int Station { get; set; }//station code
        public int LineStationIndex { get; set; }//Station number on line לא צריךךך אפשר למחוקק
        public int PrevStation { get; set; }//prev Station
        public int NextStation { get; set; }// next station 
    }
}
