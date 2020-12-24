using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
  public   class BusOnTrip
    {
        public int ID { get; set; }//Bus ID on the go
        public int LicenseNumber { get; set; }//License Number of the bus
        public int LineID { get; set; }//Identifies a line in execution
        public TimeSpan pormalTakeOffTime { get; set; }//Departure time to the formal line
        public TimeSpan ActuallyTakeOffTime { get; set; }//  Actually Take Off Time
        public int PrevStation { get; set; }//Last stop number on the line where the vehicle passed
        public TimeSpan PrevStationAt { get; set; }//Transit time at the last stop mentioned above
        public TimeSpan NextStationAt { get; set; }//Time to get to the next station
        public int DriverID { get; set; }// driver ID

    }
}
