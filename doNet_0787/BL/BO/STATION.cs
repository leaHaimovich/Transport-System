using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Emuns;

namespace BO
{
    public class STATION
    {
        public AREA area { get; set; }
        public int Code { get; set; }//station code
        public string Name { get; set; }//station name
       
        public IEnumerable<LINE> LinesOnThisStation { get; set; }// קווי אוטובוס שעוברים בתחנה
        public IEnumerable<STATIONLINE> LinesAdjacentStations { get; set; }//רשימת תחנות עוקבות לתחנה זאת
        public override string ToString()
        {
            string str = Code + " " + Name + " ";
            return str;
        }
    }
}
