using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using static DO.Bus;

namespace DS
{

    public static class DataSource
    {
        public static List<Bus> listBus;
        public static List<Station> listStations;
        public static List<User> listUsers;
        public static List<AdjacentStations> listAdjacentStation;
        public static List<Trip> listTrip;
        public static List<LineTrip> listLineTrip;
        public static List<LineStation> listLineStation;
        public static List<Line> listLine;
        public static List<BusOnTrip> listBusOnTrip;

        static DataSource()
        {
            InitAllLists();
        }
        static void InitAllLists()
        {
            listBus = new List<Bus>();
            for (int i = 0; i < 20; i++)
            {
                Bus b = new Bus          
                {
                    LicenseNumber = 1245670+i,
                    Mileage = 100.0,
                    FuelTank = 50.3,
                    Status = STATUS.ReadyForRide
                };
                listBus.Add(b);
            }

            listStations=new List<Station>
            { 
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                },
                new Station
                {
                    Code=
                    Name=
                    Address=
                    Latitude=
                    longitude=
                }

            }
            //listBus = new List<Bus>
            //{

            //    new Bus{
            //    LicenseNumber=1245678,
            //    Mileage = 100.0,
            //      FuelTank = 50.3,
            //          Status = STATUS.ReadyForRide
            //            },

            //        new Bus{
            //         LicenseNumber=12345679,
            //         Mileage = 100.0,
            //          FuelTank = 50.3,
            //          Status = STATUS.ReadyForRide
            //               },
            //        new Bus
            //        {
            //         LicenseNumber=12345689,
            //         Mileage = 100.0,
            //          FuelTank = 50.3,
            //          Status = STATUS.ReadyForRide

            //        },
            //    new Bus
            //    {
            //        LicenseNumber=12345789,
            //         Mileage = 100.0,
            //          FuelTank = 50.3,
            //          Status = STATUS.ReadyForRide
            //    },
            //    new Bus
            //    {
            //        LicenseNumber=12346789,
            //         Mileage = 100.0,
            //          FuelTank = 50.3,
            //          Status = STATUS.ReadyForRide
            //    }
            // }

            //}//

        } 
   


    }


}

