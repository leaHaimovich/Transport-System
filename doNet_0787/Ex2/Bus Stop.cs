using System;
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
        private int Latitude;//קו רוחב
        private int Longitude;//קו אורך
        private string stationAdress;

        public int BUStationKey
            {
                get{return BusStationKey ;}
               set { BusStationKey=value;}
             }
        public int LAtitude
        {
            get { return Latitude; }
            set { Latitude = value; }
        }

        public int LOngitude
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

    class Bus_Line
    {
        //private List<BusLineStation> Stations;
        //private int BusLine;
        public int BusLine;
        public List<BusLineStation> Stations;

        private int FirstStation;
        private int LastStation;
        private string Area;

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

    public bool addNewStation(int staitioKOD, BusLineStation s)//הוספת קו לרשימת קווים
        {
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


            if(Stations.IndexOf(s1) <= Stations.IndexOf(s2))
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
            v.BusLine=s1.BUStationKey + s2.BUStationKey;
            v.FirstStation = s1.BUStationKey;
            v.LastStation = s2.BUStationKey;
            v.Area=s1.
        }








    }
}