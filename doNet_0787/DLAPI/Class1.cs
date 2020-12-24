using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;

namespace DLAPI
{
    public interface IDL
    {
        #region Bus
        IEnumerable<Bus> GetAllBuss();
        IEnumerable<Bus> GetAllBusy(Predicate<Bus> predicate);
        public Bus GetBus(int LicenseNumber);
        public void AddBus(Bus bus);
        public void DeleteBus(int LicenseNumber);
        public void UpdateBus(Bus bus);
        public void UpdateBus(int LicenseNumber, Action<Bus> update);
        #endregion

        #region Line
        IEnumerable<Line> GetAllLines();
        IEnumerable<Line> GetAllLinesBy(Predicate<Line> predicate);
        public Line GetLine(int Id);
        public void AddLine(Line line);//add line
        public void DeleteLine(int Id);//delete line
        public void UpdateLine(Line line);
        public void UpdateLine(int Id, Action<Line> update);

        #endregion

        #region Station
        IEnumerable<Station> GetAllStations();
        IEnumerable<Station> GetAllStationsBy(Predicate<Station> predicate);
        public Line GetStation(int Code);
        public void AddStation(Station line);//add Station
        public void DeleteStation(int Code);//delete Station
        public void UpdateStation(Station Station);
        public void UpdateStation(int code, Action<Station> update);
        #endregion

        #region User
        IEnumerable<User> GetAllUsers();
        IEnumerable<Station> GetAllUsersBy(Predicate<User> predicate);
        public Line GetUser(int ID);
        public void AddUser(User user);//add Station
        public void DeleteUser(int ID);//delete Station
        public void UpdateUser(User user);
        public void UpdateUser(int code, Action<User> update);
        #endregion
    }
}
