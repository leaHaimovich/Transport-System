using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Line
    {
        public int ID { get; set; }//id of line
        public int Code { get; set; }//code of line//number of line
        public enum AREA
        {
            GENERAL, NORTH, SOUTH, EAET, WEST, GUSH_DAN,CENTER,YERUSALEM
        }
        public AREA Area { get; set; }// area of line activitis
        public int FirstStation { get; set; }//FirstStation number of line
        public int LastStation { get; set; }//lasttStation number of line
        public int StationNum { get; set; }//number of station un line
        
    }
}
