using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Emuns;

namespace BLAPI
{
    public interface IBL
    {

        #region LINE
        LINE GetLINE(int code, AREA area);
        IEnumerable<LINE> GetAllLINES();
        void AddLINE(LINE l);
        void DeleteLINE(int code, AREA area);
        void UpdateLINE(LINE upline);
        LINE ConvertLineToLINE(DO.Line l);


        //פונקציית עזר שהופכת מתחנה של בי לתחנת קו בדי
        DO.LineStation ConvertSTATIONToLineStation(STATIONLINE S, int LineID);
        #endregion


        #region STATION
        STATION GetSTATION(int code);
        void SetTime(TimeSpan ts, int station1Code, int station2Code);
        void SetDistance(double distance, int station1Code, int station2Code);
        void AddSTATION(STATION newSTATION);
        void DeleteSTATION(int code);
        void UpdateSTATION(STATION upstation);
        #endregion



        STATIONLINE ConvertLineStationToSTATIONLINE(DO.LineStation ls, TimeSpan t, double dis, string name);
        void updateSTATIONLINE(STATIONLINE L);



        //#region bus
        //BO.Bus1 GetBus1(int LicenseNum);
        //BO.Bus1 BusDoBoAdapter(DO.Bus busDo);
        //void AddBus1(Bus1 newBus);
        //void DeleteBus1(int licenseNum);
        //void UpdateBus1(Bus1 upBus);
        //void UpdateBus1(int LicenseNumber, Action<Bus1> update);
        //#endregion

        //#region Line

        //BO.Line1 GetLine1(int Id);
        //BO.Line1 LineDoBoAdapter(DO.Line lineDo);
        //void AddLine1(Line1 NewLine1);//Add Line
        //void DeleteLine1(int lineID);//Delete Line 
        //void updateLine1(Line1 l1);
        //void updateLine1(int Id, Action<Line1> update);

        //#endregion

        //#region LineStation
        //LineStation1 LineStationDOBOAdaptor(DO.LineStation ls ,string stationName);
        //IEnumerable<BO.LineStation1> GetAllStationInThisLine(int lineID);
        //void UpdateLineStation1(LineStation1 ls1);

        //#endregion

        //#region Station
        //BO.Station1 GetStation1(int Code);
        //IEnumerable<BO.Line1> GetAllLinesThatGoInStation(int code);
        //BO.Station1 stationDoBoAdapter(DO.Station s);
        //void AddStation1(Station1 s1);
        //void DeleteStation1(int code);
        //void UpdateStation1(Station1 s1);
        //void UpdateStation1(int code, Action<Station1> update);
        //#endregion

        //#region AdjacentStations1
        //void SetDistance(double D,int station1Code,int station2Code);
        //void SetTime(TimeSpan t,int station1Code,int station2Code);
        //#endregion
    }
}
