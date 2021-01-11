using dl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DS;
using DO;
using static DO.Line;

namespace DL
{
    sealed class DLObject : IDL
    {

        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion

        #region addFunc
        public void AddAdjacentStations(AdjacentStations a)
        {
            if (DataSource.listAdjacentStation.FirstOrDefault(x => x.Station1 == a.Station1 && x.Station2 == a.Station2 && x.lineCode == a.lineCode) != null)
                throw new DO.OlreadtExistException(" ALLREADY EXIST ");
            DataSource.listAdjacentStation.Add(a);
        }
        public bool addLineStation(LineStation ls)
        {
            if (DataSource.listLineStation.FirstOrDefault(b => b.LineID == ls.LineID && b.Station==ls.Station) != null)
            {
                throw new DO.OlreadtExistException("THIS BUS ALLREADY EXIST ");
            }
            DataSource.listLineStation.Add(ls);
            return true;
        }
        public void AddLineTrip(LineTrip lp)
        {
            if (DataSource.listLineTrip.FirstOrDefault(b => b.ID == lp.ID) != null)
            {
                throw new DO.OlreadtExistException("THIS BUS ALLREADY EXIST ");
            }
            DataSource.listLineTrip.Add(lp);
        }

        public void AddBus(Bus bus)
        {
           if( DataSource.listBus.FirstOrDefault(b => b.LicenseNum == bus.LicenseNum) != null)
                    {
                throw new DO.OlreadtExistException("THIS BUS ALLREADY EXIST ");
                     }
            DataSource.listBus.Add(bus);
        }

        public void AddLine(Line line)//לברר בדיוקק
        {
            if (DataSource.listLine.FirstOrDefault(l => l.StationNum == line.StationNum 
                             && l.FirstStation == line.FirstStation && l.LastStation == line.LastStation && l.Code==line.Code) != null)
            {
                    throw new DO.OlreadtExistException("THIS LINE ALLREADY EXIST ");
            }
            DO.StaticRunNumbers.RUNNUMBERLineID++;
             //UPDATA RUN NUMBER
            line.ID = DO.StaticRunNumbers.RUNNUMBERLineID;
            DataSource.listLine.Add(line);
            
        }

        public void AddStation(Station station)
        {
            if (DataSource.listStations.FirstOrDefault(s => s.Code == station.Code) != null)
            {
                throw new DO.OlreadtExistException("THIS STATION ALLREADY EXIST ");
            }
            DataSource.listStations.Add(station);
        }

        public void AddUser(User user)
        {
            if (DataSource.listUsers.FirstOrDefault(u => u.ID == user.ID) != null)
            {
                throw new DO.OlreadtExistException("THIS USER ALLREADY EXIST ");
            }
            DataSource.listUsers.Add(user);
        }
        #endregion

        #region deleteFunc
        public void DeleteBus(int LicenseNumber)
        {
            Bus bus = DataSource.listBus.Find(b => b.LicenseNum == LicenseNumber);
            if (bus != null)
            {
                DataSource.listBus.Remove(bus);
            }
            else throw new DO.NotExistException("THIS BUS DOSENT EXIST");
        }

        public void DeleteLine(int code,AREA area)
        {
            Line line = DataSource.listLine.Find(b => b.Code ==code && b.Area==area );
            if (line != null)
            {
                DataSource.listLine.Remove(line);
            }
            else throw new DO.NotExistException("THIS LINE DOSENT EXIST");
        }

        public void DeleteStation(int Code)
        {
            Station station = DataSource.listStations.Find(b => b.Code == Code);
            if (station != null)
            {
                DataSource.listStations.Remove(station);
            }
            else throw new DO.NotExistException("THIS STATION DOSENT EXIST");
        }

        public void DeleteUser(int ID)
        {
            User user = DataSource.listUsers.Find(b => b.ID == ID);
            if (user != null)
            {
                DataSource.listUsers.Remove(user);
            }
            else throw new DO.NotExistException("THIS USER DOSENT EXIST");
        }
        public void DeleteLineTrip(int lineCode)
        {
            LineTrip lt = DataSource.listLineTrip.Find(b=>b.LineID== lineCode);
            if (lt != null)
            { DataSource.listLineTrip.Remove(lt); }
            else throw new DO.NotExistException();

        }
        #endregion

        #region GetAll
        public IEnumerable<Bus> GetAllBuss()
        {
            return from bus in DataSource.listBus
                   select bus.Clone();          
        }

        public IEnumerable<Bus> GetAllBusBy(Predicate<Bus> predicate)
        {
            return from bus in DataSource.listBus
                   where predicate(bus)
                   select bus.Clone();
        }

        public IEnumerable<Line> GetAllLines()
        {
            return from person in DataSource.listLine
                   select person.Clone();
        }

        public IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate)
        {
            return from line in DataSource.listLine
                   where predicate(line)
                   select line.Clone();
        }

        public IEnumerable<Station> GetAllStations()
        {
            return from person in DataSource.listStations
                   select person.Clone();
           // throw new NotImplementedException();
        }

        public IEnumerable<Station> GetAllStationsBy(Predicate<Station> predicate)
        {
            return from station in DataSource.listStations
                   where predicate(station)
                   select station.Clone();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return from person in DataSource.listUsers
                   select person.Clone();
            //throw new NotImplementedException();
        }

        public IEnumerable<Station> GetAllUsersBy(Predicate<User> predicate)
        {
            return (IEnumerable<Station>)(from user in DataSource.listUsers
                   where predicate(user)
                   select user.Clone());
        }
         public IEnumerable<LineTrip> GetAllLineTrip()
        {
            return from lp in DataSource.listLineTrip
                   select lp.Clone();
        }

        public IEnumerable<LineTrip> GetAllLineTripsBy(Predicate<LineTrip> predicate)
        {
            return from a in DataSource.listLineTrip
                   where predicate(a)
                   select a.Clone();
        }

        public IEnumerable<AdjacentStations> GetAllAdjacentStations()
        {
            return from a in DataSource.listAdjacentStation
                   select a.Clone();
        }
        public IEnumerable<AdjacentStations> GetAllAdjacentStationsBy(Predicate<AdjacentStations> predicate)
        {
            return from a in DataSource.listAdjacentStation
                   where predicate(a)
                   select a.Clone();
        }
        #endregion

        #region Get


        public Bus GetBus(int LicenseNumber)
        {
            Bus bus = DataSource.listBus.Find(b => b.LicenseNum == LicenseNumber);
            if (bus != null)
                return bus.Clone();
            else { throw new DO.NotExistException("THIS BUS DOSENT EXIST"); }//trhow
        }

        public Line GetLine(int code,AREA area)
        {
            Line line = DataSource.listLine.Find(b => b.Code == code && b.Area==area);
            if (line != null)
                return line.Clone();
            else throw new DO.NotExistException("THIS LINE DOSENT EXIST");
            
        }
        //public Line GetLine(int ID) 
        //{
        //    Line l = DataSource.listLine.Find(b => b.ID==ID);
        //    if (l != null)
        //        return l.Clone();
        //    else { throw new DO.NotExistException("THIS LINE DOSENT EXIST"); }//trhow
        //}
        public Station GetStation(int Code)
        {
            Station st = DataSource.listStations.Find(s => s.Code == Code);
            if (st != null)
                return st.Clone();
            else throw new DO.NotExistException("THIS STATION DOSENT EXIST");//trhow
        }

        public User GetUser(int ID)
        {
            User us = DataSource.listUsers.Find(s => s.ID == ID);
            if (us != null)
                return us.Clone();
            else throw new DO.NotExistException("THIS USER DOSENT EXIST");
       
        }

        public LineTrip GetLineTrip(int lineId)
        {
            LineTrip st = DataSource.listLineTrip.Find(s => s.LineID == lineId);
            if (st != null)
                return st.Clone();
            else throw new DO.NotExistException("THIS LineTrip DOSENT EXIST");//trhow
        }
        public LineStation GetLineStation(int lineCode1, int StationCode)
        {
            LineStation a = DataSource.listLineStation.Find(x => x.lineCode == lineCode1 && x.Station == StationCode);
            if (a != null) return a.Clone();
            else throw new NotExistException();
        }
        #endregion

        #region Update
        public void UpdateBus(Bus bus)
        {
            Bus per = DataSource.listBus.Find(p => p.LicenseNum == bus.LicenseNum);

            if (per != null)
            {
                DataSource.listBus.Remove(per);
                DataSource.listBus.Add(per.Clone());
            }
            else
                 throw new DO.NotExistException("THIS BUS DOSENT EXIST");
        }

        public void UpdateBus(int LicenseNumber, Action<Bus> update)
        {
            if (DataSource.listBus.Find(b => b.LicenseNum == LicenseNumber) == null)
                throw new DO.NotExistException("THIS BUS DOSENT EXIST");
            else
            update(DataSource.listBus.Find(b => b.LicenseNum == LicenseNumber));
            
        }

        public void UpdateLine(Line line)
        {
            Line per = DataSource.listLine.Find(p => p.Code == line.Code);

            if (per != null)
            {
                DataSource.listLine.Remove(per);
                DataSource.listLine.Add(line);
            }
            else
                throw new DO.NotExistException("THIS LINE DOSENT EXIST");
        }

        public void UpdateLine(int Id, Action<Line> update)
        {
            if (DataSource.listLine.Find(l => l.ID == Id) == null)
                throw new DO.NotExistException("THIS LINE DOESNT EXIST");
              else  update(DataSource.listLine.Find(l => l.ID == Id));
           
        }

        public void UpdateStation(Station Station)
        {
            Station per = DataSource.listStations.Find(p => p.Code == Station.Code);

            if (per != null)
            {
                DataSource.listStations.Remove(per);
                DataSource.listStations.Add(per.Clone());
            }
            else
                throw new DO.NotExistException("THIS STATION DOSENT EXIST");
        }

        public void UpdateStation(int code, Action<Station> update)
        {
            if (DataSource.listStations.Find(s => s.Code == code) == null)
                throw new DO.NotExistException("THIS STATION DOSENT EXIST");
           else  update(DataSource.listStations.Find(s => s.Code == code));
 
        }

        public void UpdateUser(User user)
        {
            User per = DataSource.listUsers.Find(p => p.ID == user.ID);

            if (per != null)
            {
                DataSource.listUsers.Remove(per);
                DataSource.listUsers.Add(per.Clone());
            }
            else
                throw new DO.NotExistException("THIS USER DOSENT EXIST");
        }

        public void UpdateUser(int ID, Action<User> update)
        {
            if (DataSource.listUsers.Find(s => s.ID == ID)==null)
                throw new DO.NotExistException("THIS USER DOSENT EXIST");
          else  update(DataSource.listUsers.Find(s => s.ID == ID));
              
        }

        public void UpdateAdjacentStations(AdjacentStations a)
        {
            AdjacentStations b = DataSource.listAdjacentStation.Find(x => x.Station1 == a.Station1 && x.Station2 == a.Station2);
              if(b!=null)
            {
                DataSource.listAdjacentStation.Remove(b);
                DataSource.listAdjacentStation.Add(a.Clone());
            }
            else
                throw new DO.NotExistException();
            
        }
        #endregion

        #region LineStation
        public bool UpdateLineStation(LineStation ls)
        {
            LineStation per = DataSource.listLineStation.Find(p => p.lineCode == ls.lineCode && p.Station==ls.Station);

            if (per != null)
            {
                DataSource.listLineStation.Remove(per);
                DataSource.listLineStation.Add(per.Clone());
                return true;
            }
            else
                throw new DO.NotExistException("THIS LINE STATION DOSENT EXIST");
        }
        public  IEnumerable<LineStation> GetAllLineStationsBy(Predicate<LineStation> predicate)
        {
            return from LineStation in DataSource.listLineStation
                   where predicate(LineStation)
                   select LineStation.Clone();
        }
       public  IEnumerable<LineStation> GetAllLineStations()
        {
            return from lineStation in DataSource.listLineStation
                   select lineStation.Clone();
        }
        #endregion

        //#region set
        //public void SetDistance(double distance, int station1Code, int station2Code)
        //{

        //}
        //public void SetTime(TimeSpan t, int station1Code, int station2Code)
        //{

        //}
        //#endregion

    }
}

