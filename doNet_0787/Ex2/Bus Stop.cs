using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex2
{
    class Bus_Stop
    {
        private int BusStationKey;
        private double Latitude;//קו רוחב
        private double Longitude;//קו אורך
        private string stationAdress;

        public int BUStationKey
        {
            get { return BusStationKey; }
            set { BusStationKey = value; }
        }
        public double LAtitude
        {
            get { return Latitude; }
            set { Latitude = value; }
        }

        public double LOngitude
        {
            get { return Longitude; }
            set { Longitude = value; }
        }
        public string StationAdress
        {
            get { return stationAdress; }
            set { stationAdress = value; }
        }



        public override string ToString()
        {
            return "Bus Station Code:  " + BusStationKey + ", " + Latitude + "°N" + " " + Longitude + "°E";
        }
    }

    class BusLineStation : Bus_Stop//תחנת קו אוטובוס סעיף 2
    {
        private double DistanceFromPrevStaition;
        private double timeFromPrevStation;

        public double DIstanceFromPrevStaition
        {
            get { return DistanceFromPrevStaition; }
            set { DistanceFromPrevStaition = value; }
        }
        public double TimeFromPrevStation
        {
            get { return timeFromPrevStation; }
            set { timeFromPrevStation = value; }
        }
    }

    class Bus_Line : IComparable
    {
        public enum area { General, North, South, Center, Jerusalem }
        //private List<BusLineStation> Stations;
        //private int BusLine;
        public int BusLine;
        public List<BusLineStation> Stations;

        public int FirstStation;
        public int LastStation;
        public area Area;

        //Bus_Line()
        //{
        //    Stations = new List<BusLineStation>();
        //}
        public override string ToString()
        {
            string str1 = "Bus Line: " + BusLine + "Area: " + Area + " list station from first to end: ";
            foreach (BusLineStation buslineStation in Stations)
            {
                str1 += buslineStation.ToString();
                str1 += ", ";
            }

            str1 += "list station from last to first: ";
            foreach (BusLineStation buslineStation in Enumerable.Reverse(Stations))
            {
                str1 += buslineStation.ToString();
                str1 += ", ";
            }
            return str1;
        }

        public int CompareTo(object obj2)//compare between two bus line
        {
            Bus_Line s1 = this;
            Bus_Line s2 = (Bus_Line)obj2;

            int i = 0;
            foreach (BusLineStation buslineStation in Stations)
            {
                i++;
            }
            double t1 = timeBetweenStations(s1.Stations[0], s1.Stations[i]);

            i = 0;
            foreach (BusLineStation buslineStation in Stations)
            {
                i++;
            }
            double t2 = timeBetweenStations(s2.Stations[0], s2.Stations[i]);

            return t1.CompareTo(t2);
            //if (t1 > t2) return 1;
            //if (t1 < t2) return -1;
            //return 0;

        }



        public bool addNewStation(int staitioKOD, BusLineStation s)//   הוספת קו לרשימת קווים אחרי המפתח הנתון 
        {
            if (staitioKOD == -1) Stations.Add(s);

            int count = 0;
            foreach (BusLineStation buslineStation in Stations)
            {
                if (buslineStation.BUStationKey == staitioKOD)
                {
                    Stations.Insert(count, s);
                    return true;
                }
                count++;
            }
            return false;
        }

        public bool deletStation(int stationKeyForDelete)
        {
            foreach (BusLineStation buslineStation in Stations)
            {
                if (buslineStation.BUStationKey == stationKeyForDelete)
                {
                    Stations.Remove(buslineStation);
                    return true;
                }
            }
            return false;
        }

        public bool isStationExist(int stationKey)
        {
            foreach (BusLineStation buslineStation in Stations)
            {
                if (buslineStation.BUStationKey == stationKey)
                    return true;
            }
            return false;
        }

        public double dintanceStations(BusLineStation s1, BusLineStation s2)
        {
            double sum = 0;
            bool degel = false;
            if (Stations.IndexOf(s1) > Stations.IndexOf(s2))
            {
                foreach (BusLineStation buslineStation in Enumerable.Reverse(Stations))
                {
                    if (buslineStation.BUStationKey == s1.BUStationKey)
                    {
                        sum += buslineStation.DIstanceFromPrevStaition;
                        degel = true;

                    }
                    if (degel)
                    {
                        if (buslineStation.BUStationKey != s2.BUStationKey)
                            sum += buslineStation.DIstanceFromPrevStaition;
                    }

                }

                return sum;
            }


            if (Stations.IndexOf(s1) <= Stations.IndexOf(s2))
            {
                foreach (BusLineStation buslineStation in Enumerable.Reverse(Stations))
                {
                    if (buslineStation.BUStationKey == s2.BUStationKey)
                    {
                        sum += buslineStation.DIstanceFromPrevStaition;
                        degel = true;

                    }
                    if (degel)
                    {
                        if (buslineStation.BUStationKey != s1.BUStationKey)
                            sum += buslineStation.DIstanceFromPrevStaition;
                    }

                }

                return sum;
            }


            return sum;
        }


        public double timeBetweenStations(BusLineStation s1, BusLineStation s2)
        {
            double sum = 0;
            bool degel = false;
            if (Stations.IndexOf(s1) > Stations.IndexOf(s2))
            {
                foreach (BusLineStation buslineStation in Enumerable.Reverse(Stations))
                {
                    if (buslineStation.BUStationKey == s1.BUStationKey)
                    {
                        sum += buslineStation.TimeFromPrevStation;
                        degel = true;

                    }
                    if (degel)
                    {
                        if (buslineStation.BUStationKey != s2.BUStationKey)
                            sum += buslineStation.TimeFromPrevStation;
                    }

                }

                return sum;
            }


            if (Stations.IndexOf(s1) <= Stations.IndexOf(s2))
            {
                foreach (BusLineStation buslineStation in Enumerable.Reverse(Stations))
                {
                    if (buslineStation.BUStationKey == s2.BUStationKey)
                    {
                        sum += buslineStation.TimeFromPrevStation;
                        degel = true;

                    }
                    if (degel)
                    {
                        if (buslineStation.BUStationKey != s1.BUStationKey)
                            sum += buslineStation.TimeFromPrevStation;
                    }

                }

                return sum;
            }


            return sum;
        }





        public Bus_Line conectBetweenStations(BusLineStation s1, BusLineStation s2)
        {
            Bus_Line v = new Bus_Line();
            v.BusLine = s1.BUStationKey + s2.BUStationKey;
            v.FirstStation = s1.BUStationKey;
            v.LastStation = s2.BUStationKey;
            Random rnd = new Random();
            int num = rnd.Next(0, 5);//הגרלת מספרים מאפס עד 4 לenum
            v.Area = (area)num;

            int i = 0;
            foreach (BusLineStation buslineStation in Stations)
            {
                if (buslineStation.BUStationKey == s1.BUStationKey)
                {
                    while (buslineStation.BUStationKey != s2.BUStationKey)
                    {
                        BusLineStation t1 = new BusLineStation();
                        t1.BUStationKey = buslineStation.BUStationKey;
                        t1.DIstanceFromPrevStaition = buslineStation.DIstanceFromPrevStaition;
                        t1.TimeFromPrevStation = buslineStation.TimeFromPrevStation;
                        t1.LAtitude = buslineStation.LAtitude;
                        t1.LOngitude = buslineStation.LOngitude;
                        t1.StationAdress = buslineStation.StationAdress;
                        v.Stations.Insert(i, t1);
                        i++;
                    }

                    BusLineStation t = new BusLineStation();
                    t.BUStationKey = s2.BUStationKey;
                    t.DIstanceFromPrevStaition = s2.DIstanceFromPrevStaition;
                    t.TimeFromPrevStation = s2.TimeFromPrevStation;
                    t.LAtitude = s2.LAtitude;
                    t.LOngitude = s2.LOngitude;
                    t.StationAdress = s2.StationAdress;
                    v.Stations.Insert(i, t);
                }
            }
            return v;

        }

        public static implicit operator List<object>(Bus_Line v)
        {
            throw new NotImplementedException();
        }
    }
    class Buses_line : IEnumerable
    {
        public List<Bus_Line> busesCollect;
       

        public Bus_Line BusesCollect
        {
            //get => busesCollect;
            set => busesCollect .Add(value);
        }



        public IEnumerator GetEnumerator()
        {
            return busesCollect.GetEnumerator();
        }
        public bool addNewBussLine(Bus_Line newBusLine)//add new bus line to the list
        {
            int i = 0;
            foreach (Bus_Line bus_Line in busesCollect)
            {
                i++;
                if (bus_Line.BusLine == newBusLine.BusLine)//if the bus line exist allredy
                {
                    if (!((bus_Line.FirstStation == newBusLine.LastStation && bus_Line.LastStation == newBusLine.FirstStation) || (bus_Line.LastStation == newBusLine.FirstStation && bus_Line.FirstStation == newBusLine.LastStation)))
                        return false;

                }
            }

            busesCollect.Insert(i, newBusLine);
            return true;

        }

        public bool deleteBusLineFromList(int busKodForDelet)
        {
            foreach (Bus_Line bus_Line in busesCollect)
            {
                if (bus_Line.BusLine == busKodForDelet)
                { busesCollect.Remove(bus_Line);
                    return true;
                }
            }
            return false;
        }

        public List<Bus_Line> busesInThisStaition(int staitionKey)
        {
            bool flag = false;
            List<Bus_Line> a = new List<Bus_Line>();

            foreach (Bus_Line bus_Line in busesCollect)
            {
                foreach (BusLineStation busLineStation in bus_Line.Stations)
                {
                    if (busLineStation.BUStationKey == staitionKey)
                    { a.Add(bus_Line);
                        flag = true;
                        // break;
                    }

                }
            }
            if (flag == false) throw new noBusLineInStationException();
            return a;
        }


        public List<Bus_Line> sortBusLineByTime()//sort Bus Line By Time
        {
            List<Bus_Line> n = new List<Bus_Line>();
            List<Bus_Line> temp = new List<Bus_Line>();
            int i = 0;
            foreach (Bus_Line bus_Line in busesCollect)
            {
                temp.Insert(i, bus_Line);
            }
            int j = 0;
            Bus_Line max = new Bus_Line();
            Bus_Line min = new Bus_Line();

            foreach (Bus_Line bus_Line1 in temp)
            {
                max = temp[0];
                min = temp[0];

                foreach (Bus_Line bus_Line in temp)//lookinp for min number
                {
                    int a = min.CompareTo(bus_Line);
                    if (a >= 0) min = bus_Line;
                }
                n.Insert(j, min);
                j++;
                temp.Remove(min);
            }
            return n;
        }

        public Bus_Line this[int index]
        {
            get => busesCollect.ElementAt(index);
           
        }

    }
}