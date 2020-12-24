using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    public class Station
    {
        public int Code { get; set; }//station code
        public string Name { get; set; }//station name
         public string Address { get; set; }//station Address
        public int Latitude { get; set; }//Latitude of location of the station
        public int longitude { get; set; }//longitude of location of the station
    }
}
