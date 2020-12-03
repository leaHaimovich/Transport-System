using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace WpfApp1
{

    /// <summary>
    /// Department for the implementation of a single bus line
    /// </summary>
    public class LineBus:IComparable<LineBus>
    {
        
        // A list containing the station route of the line
        public List<LineStation> lineRoute = new List<LineStation>();
        public List<LineStation> LineRoute
        {
            get { return lineRoute; }
            set
            {
                lineRoute = value;
                //if((lineRoute[0]!= firstStation) || lineRoute[lineRoute.Count-1]!=lastStation))
                     //   throw new ex
            }

        }
        public int numBus { get; set; } 
        public LineStation firstStation { get; set; }
        public LineStation lastStation { get; set; }
        public AREA area { get; set; }

        public LineBus() { }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="route"></The route of the line>
        /// <param name="num"></Line number>
        /// <param name="area"></The travel area of the line>
        public LineBus(List<LineStation> route, int num, AREA area)
        {
            if (route.Count < 2)
                throw new ArgumentNullException("ERROR: canot create bus without 2 stations");
            lineRoute.AddRange(route);
            numBus = num;
            firstStation = lineRoute[0];
            lastStation = lineRoute[lineRoute.Count - 1];
            this.area = area;
        }

        /// <summary>
        /// Line data print function
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string result = "";
            foreach (LineStation temp in lineRoute)
            {
                result += temp.StationNum + ", ";
            }
            //Now "result" contains the entire list of stations of the line
            return string.Format("line number is: {0}, area of travel: {1}, Station numbers: {2}",
                numBus, area.ToString(), result);
        }


        /// <summary>
        /// A function that adds a station to the line route
        /// </summary>
        /// <param name="newStation"></The new station>
        /// <param name="locationInList"></The requested location of the station>
        public void addStation(LineStation newStation, int locationInList)
        {
            Random r = new Random();
            //Check whether the station location is within range of the existing list
            if (locationInList >= 0 && locationInList <= lineRoute.Count)
            {
                if (locationInList == 0)
                {
                    newStation.distance = 0;
                    newStation.time = 0;
                    lineRoute.Insert(locationInList, newStation);
                    firstStation = newStation;
                    lineRoute[locationInList + 1].distance = r.NextDouble() * (1000 - 100) + 100; ;
                    lineRoute[locationInList + 1].time = r.NextDouble() * (15 - 5) + 5;
                    return;

                }
                if (locationInList == (lineRoute.Count))
                {
                    lineRoute.Add(newStation);
                    lastStation = newStation;
                }
                else
                {
                    lineRoute.Insert(locationInList, newStation);
                    lineRoute[locationInList + 1].distance = r.NextDouble() * (1000 - 100) + 100; ;
                    lineRoute[locationInList + 1].time = r.NextDouble() * (15 - 5) + 5;
                }
            }
            else
            {
                throw new IndexOutOfRangeException("ERROR: index to large");
            }
        }

        /// <summary>
        /// Function for deleting a station from the line route
        /// </summary>
        /// <param name="oldStation"></Old station number>
        public void removeStation(int oldStation)
        {
            if (!searchNumStation(oldStation))
                throw new ArgumentException("station not exist in the line");
            foreach (LineStation item in lineRoute)
            {
                if(item.StationNum == oldStation)
                {
                    lineRoute.Remove(item);
                    break;
                }
            }  
        }

        /// <summary>
        /// Search for a station on a route by station number
        /// </summary>
        /// <param name="stationNum"></param>
        /// <returns></Returns true if the station exists>
        public bool searchNumStation(int stationNum)
        {
            foreach (LineStation temp in lineRoute)
            {
                if(temp.StationNum == stationNum)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Search for a station by station body
        /// </summary>
        /// <param name="stationNum"></param>
        /// <returns></returns>
        public bool searchStation(LineStation stationNum)
        {
            foreach (LineStation temp in lineRoute)
            {
                if (temp == stationNum)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Measuring distance between two stations
        /// </summary>
        /// <param name="firstStation"></firstStation>
        /// <param name="secondStation"></secondStation>
        /// <returns></distance>
        public double distanceBetweenStations(LineStation firstStation, LineStation secondStation)
        {
            if (!searchStation(firstStation) || !searchStation(secondStation))
            {
                throw new ArgumentException("ERROR: one or more stations are not exist");
            }
            double distance = 0;
            int indexA = lineRoute.IndexOf(firstStation);
            int indexB = lineRoute.IndexOf(secondStation);
            for (int i = Math.Min(indexA, indexB)+1; i <= Math.Max(indexA, indexB); i++)
            {
                distance += lineRoute[i].distance;
            }
            
            
            return distance;
        }
        /// <summary>
        /// Measurement of travel time between stations
        /// </summary>
        /// <param name="firstStation"></firstStation>
        /// <param name="secondStation"></secondStation>
        /// <returns></Travel time>
        public double timeBetweenStations(LineStation firstStation, LineStation secondStation)
        {
            if (!searchStation(firstStation) || !searchStation(secondStation))
            {
                throw new ArgumentException("ERROR: one or more stations are not exist");
            }
            double time = 0;
            int indexA = lineRoute.IndexOf(firstStation);
            int indexB = lineRoute.IndexOf(secondStation);
            for (int i = Math.Min(indexA, indexB) + 1; i <= Math.Max(indexA, indexB); i++)
            {
                time += lineRoute[i].time;
            }
            return time;
        }

        /// <summary>
        /// Returns a new line bounded between two stations
        /// </summary>
        /// <param name="firstStation"></firstStation>
        /// <param name="secondStation"></secondStation>
        /// <returns></new line>
        public LineBus SubRouteLine(int firstStation, int secondStation)
        {
            if(!searchNumStation(firstStation) || !searchNumStation(secondStation))
            {
                throw new ArgumentException("ERROR: one or more stations are not exist");
            }
            LineBus newLineBus = new LineBus();
            int indexA = 0;
            int indexB = 0;

            foreach (LineStation item in lineRoute)
            {
                if(item.StationNum == firstStation)
                {
                    indexA = lineRoute.IndexOf(item);
                }
            }
            
            foreach (LineStation item in lineRoute)
            {
                if (item.StationNum == secondStation)
                {
                    indexB = lineRoute.IndexOf(item);
                }
            }
            if (indexB < indexA)
            {
                throw new ArgumentException("EROOR: A second stop cannot be before a first stop");
            }
            for(int i = 0; indexA<= indexB; i++, indexA++ )
            {
                newLineBus.lineRoute.Add(lineRoute[indexA]);
            }

            return newLineBus;
        }
        /// <summary>
        /// Compares whether two bus lines are back and forth by comparing
        /// the location of their stations
        /// </summary>
        /// <param name="other"></other line>
        /// <returns></returns>
        public bool compareBetweenStation(LineBus other)
        {
            bool a = false;
            for (int i = 1; i <= other.lineRoute.Count(); i++)
            {
                if (lineRoute[i-1].stationStreet == other.lineRoute[other.lineRoute.Count()-i].stationStreet)
                {
                    a = true;
                }
                else
                {
                    a = false;
                    return a;
                }
            }
            return a;
        }
        /// <summary>
        /// Compares two bus lines by comparing their total travel time
        /// </summary>
        /// <param name="other"></other line>
        /// <returns></returns>
        public int CompareTo(LineBus other)
        {
            double time = timeBetweenStations(firstStation, lastStation);
            return time.CompareTo(other.timeBetweenStations(other.firstStation, other.lastStation));   
        }

    }
}
