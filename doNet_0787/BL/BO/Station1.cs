using DO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Station1
    {
        public IEnumerable<Line> LinesOnThisStation { get; set; }// קווי אוטובוס שעוברים בתחנה
        public int Code { get; set; }//station code
        public string Name { get; set; }//station name
        public string Address { get; set; }//station Address
        public double Latitude { get; set; }//Latitude of location of the station
        public double longitude { get; set; }//longitude of location of the station
    }
}
