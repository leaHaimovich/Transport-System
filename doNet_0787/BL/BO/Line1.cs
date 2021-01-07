using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Line1
    {
        public IEnumerable<Station> stationsListInLine { get; set; }
        public int Code { get; set; }//code of line//number of line
        public enum AREA
        {
            GENERAL, NORTH, SOUTH, EAET, WEST, GUSH_DAN, CENTER
        }
        public AREA Area { get; set; }// area of line activitis
        public int FirstStation { get; set; }//FirstStation number of line
        public int LastStation { get; set; }//lasttStation number of line
        public int StationNum { get; set; }//number of station un line
    }
}
