using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_9887_9517
{
    /// <summary>
    /// A bus line station class that contains physical station data
    /// and data related to a particular bus line
    /// </summary>
    public class LineStation
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

        public double Longitude;
        public double distance { get; set; }
        public double time { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="station"></Physical station data>
        /// <param name="distance"></Distance from previous station>
        /// <param name="time"></Travel time from previous station>
        public LineStation(BusStop station, double distance, double time)
        {
            stationNum = station.StationNum;
            stationStreet = station.stationStreet;
            latitude = station.Latitude;
            longitude = station.Longitude;
            this.distance = distance;
            this.time = time;
        }

        public LineStation() { }

        /// <summary>
        /// A function that compares two stations by the station number
        /// </summary>
        /// <param name="A"></First stop>
        /// <param name="B"></Second stop>
        /// <returns></retReturns truth if they are equalurns>
        public static  bool operator ==(LineStation A, LineStation B)
        {
            if(A.StationNum == B.StationNum)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Complementary function to the previous function
        /// </summary>
        /// <param name="A"></param>
        /// <param name="B"></param>
        /// <returns></returns>
        public static bool operator !=(LineStation A, LineStation B)
        {
            if (A.StationNum != B.StationNum)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Station data print function
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            int intTime = (int)time;
            int intDis = (int)distance;
            return string.Format("station num: {0}, location: {1}, Distance from previous station :{2} , Travel time from previous station: {3} minute",
                StationNum, stationStreet, intDis, intTime);
        }
    }
}
