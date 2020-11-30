using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    /// <summary>
    /// Department for the implementation of a physical bus station
    /// </summary>
    public class BusStop
    {
        private int stationNum;
        public int StationNum

        {
            get { return stationNum; }
            set
            {
                if (stationNum < 1000000)
                {
                    stationNum = value;
                }
                else
                {
                    Console.WriteLine("ERORR: The number cannot contain more than 6 digits");
                }
            }
        }
        public string stationStreet { get; set; }

        private double latitude;
        public double Latitude
        {
            get { return latitude; }

            set
            {
                if (value >= -90 && value <= 90)
                {
                    latitude = value;
                }
                else
                {
                    Console.WriteLine("ERORR latitude");
                }
            }
        }

        private double longitude;
        public double Longitude
        {
            get { return longitude; }
            set
            {
                if (value >= -180 && value <= 180)
                {
                    longitude = value;
                }
                else
                {
                    Console.WriteLine("ERORR longitude");
                }
            }
        }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="num"></Station number>
        /// <param name="street"></Location of the station>
        /// <param name="latitude"></Latitude>
        /// <param name="longitude"></longitude>
        public BusStop(int num, string street, double latitude,double longitude)
        {
            this.stationNum = num;
            this.stationStreet = street;
            this.latitude = latitude;
            this.longitude = longitude;

        }

        public BusStop() { }
        public override string ToString()
        {
            return string.Format("details of station: {0} , {1}°N , {2}°E, {3}",
                StationNum, Latitude, Longitude, stationStreet);    
        }
       
    }
}
