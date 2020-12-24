using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
   public class Bus
    {
        public int LicenseNumber { get; set; }//License Number of the bus
        public DateTime LicensingDate { get; set; }//Licensing Date of the bus
        public double Mileage { get; set; }//Mileage of the bus
        public double FuelTank { get; set; }//FuelTank of the bus
        public enum STATUS//status of the bus
        {
            ReadyForRide = 0, inMiddleOfRide, Rufueling, inTreat
        }
        public STATUS Status { get; set; }
        public bool IsExist { get; set; }//if bus exist or delited

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
