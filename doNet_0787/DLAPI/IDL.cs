using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using static DO.Line;

namespace dl
{
    public interface IDL
    {
        #region Bus
        IEnumerable<Bus> GetAllBuss();
        IEnumerable<Bus> GetAllBusBy(Predicate<Bus> predicate);
        public Bus GetBus(int LicenseNumber);
        public void AddBus(Bus bus);
        public void DeleteBus(int LicenseNumber);
        public void UpdateBus(Bus bus);
        public void UpdateBus(int LicenseNumber, Action<Bus> update);
        #endregion

        #region Line
        IEnumerable<Line> GetAllLines();
        IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate);
        public Line GetLine(int code,AREA area);
       // public Line GetLine(int ID);
        public void AddLine(Line line);//add line
        public void DeleteLine(int code,AREA area);//delete line
        public void UpdateLine(Line line);
        public void UpdateLine(int Id, Action<Line> update);

        #endregion

        #region Station
        IEnumerable<Station> GetAllStations();
        IEnumerable<Station> GetAllStationsBy(Predicate<Station> predicate);
        public Station GetStation(int Code);
        public void AddStation(Station Station);//add Station
        public void DeleteStation(int Code);//delete Station
        public void UpdateStation(Station Station);
        public void UpdateStation(int code, Action<Station> update);
        #endregion

        #region User
        IEnumerable<User> GetAllUsers();
        IEnumerable<Station> GetAllUsersBy(Predicate<User> predicate);
        public User GetUser(int ID);
        public void AddUser(User user);//add Station
        public void DeleteUser(int ID);//delete Station
        public void UpdateUser(User user);
        public void UpdateUser(int ID, Action<User> update);
        #endregion

        #region LineStation
        IEnumerable<LineStation> GetAllLineStationsBy(Predicate<LineStation> predicate);
        IEnumerable<LineStation> GetAllLineStations();
        public bool UpdateLineStation(LineStation ls);
        public bool addLineStation(LineStation ls);
        LineStation GetLineStation(int lineCode, int StationCode);
        void DeleteLineStation(LineStation l);
        //public void UpdateLineStation()

        #endregion

        #region LineTrip
        void AddLineTrip(LineTrip lp);
        void DeleteLineTrip(int lineId);
        LineTrip GetLineTrip(int lineId);
        IEnumerable<LineTrip> GetAllLineTrip();
        IEnumerable<LineTrip> GetAllLineTripsBy(Predicate<LineTrip> predicate);
        #endregion

        #region AdjacentStations
        IEnumerable<AdjacentStations> GetAllAdjacentStations();
        IEnumerable<AdjacentStations> GetAllAdjacentStationsBy(Predicate<AdjacentStations> predicate);
        void UpdateAdjacentStations(AdjacentStations a);
        void AddAdjacentStations(AdjacentStations a);
        AdjacentStations GetAdjacentStations(int codeStation1, int codeStation2, int lineCode);
        void DeleteAdjacentStations(AdjacentStations adjd);
        #endregion
        //#region AdjacentStations
        //public void SetDistance(double distance, int station1Code, int station2Code);
        //public void SetTime(TimeSpan t, int station1Code, int station2Code);
        //#endregion
    }
}
