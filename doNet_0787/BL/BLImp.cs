using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dl;
using BLAPI;
using BO;
using DO;
using System.Reflection;


namespace BL
{
    
    class BLImp : IBL
    {
        IDL dl = DLFactory.GetDL();

        public LineStation ConvertSTATIONToLineStation(STATIONLINE S, int LineID)// Convert STATION To  Line Station
        {
            DO.LineStation ls = new LineStation();
            ls.LineID = LineID;
            ls.Station = S.CodeStation;
            ls.NextStation = S.NextStation;
           // ls.PrevStation = S.PrevStation;
            return ls;
        }

        public void updateSTATIONLINE(STATIONLINE LS)
        {
            DO.LineStation s = new LineStation();
            s.Station = LS.CodeStation;
            s.NextStation=LS.NextStation;
            s.LineID = LS.LineCode;
            s.lineCode = LS.LineCode;
            try { dl.UpdateLineStation(s); }
            catch { throw new NotExistExceptionBO(); }
            DO.AdjacentStations adjs = new AdjacentStations();
            adjs.Station1 = LS.CodeStation;
            adjs.Station2 = LS.NextStation;
            adjs.Time = LS.Time;
            adjs.Distance = LS.Distance;
            adjs.lineCode = LS.LineCode;

            try { dl.UpdateAdjacentStations(adjs); }
            catch { throw new NotExistExceptionBO(); }
            DO.Station std = new Station();
            std.Code = LS.CodeStation;
            std.Name = LS.StationName;
            try { dl.UpdateStation(std); }
            catch { throw new NotExistExceptionBO(); }
          
        }
        public void AddLINE(LINE l)
        {
            DO.Line ld = new Line();
            ld.Area = (Line.AREA)l.Area;
            ld.Code = l.Code;
            try { dl.AddLine(ld); }
            catch { throw new OlreadtExistExceptionBO(); }

            // findig line id to creat line trip
            DO.Line temp = new Line();
            try { temp=dl.GetLine(l.Code, (Line.AREA)l.Area); }
            catch { throw new NotExistExceptionBO(); }
            int id = temp.ID;

            DO.LineTrip lt = new LineTrip();         
            lt.LineID = id;
            lt.StartAt = l.StartAt;
            lt.FinishAt = l.FinishAt;
            lt.Frequency = l.Frequency;
            try { dl.AddLineTrip(lt); }
            catch { throw new OlreadtExistExceptionBO(); }

            if (l.StationListOfLine != null)
            {
                var v = from a in l.StationListOfLine
                        select ConvertSTATIONToLineStation(a, id);//רשימה של תחנות קו
        
                 
            try
            {
                var v1 = from b in v
                         select  dl.addLineStation(b);
            }
            catch { throw new OlreadtExistExceptionBO(); }
            }
        }

        public void AddSTATION(STATION newSTATION)
        {
            throw new NotImplementedException();
        }

        public void DeleteLINE(int code, Emuns.AREA area)
        {            
            LINE l = GetLINE(code, area);
            int c = l.Code;            
            BO.Emuns.AREA ar = l.Area;
            DO.Line a = dl.GetLine(c, (Line.AREA)ar);
            try { dl.DeleteLine(l.Code, (Line.AREA)l.Area); }
            catch { throw new NotExistExceptionBO(); }
                    
            dl.DeleteLineTrip(a.Code);
            
        }

        public void DeleteSTATION(int code)
        {
            throw new NotImplementedException();
        }
        public bool  DeleteSTATIONLINE(STATIONLINE sl)
        {
            try
            {
                DO.LineStation l = dl.GetLineStation(sl.LineCode, sl.CodeStation);
                dl.DeleteLineStation(l);
                DO.AdjacentStations adj = dl.GetAdjacentStations(sl.CodeStation, sl.NextStation, sl.LineCode);
                dl.DeleteAdjacentStations(adj);
            }
            catch { throw new NotExistException(); }
            return true;

        }
        public LINE ConvertLineToLINE(DO.Line l)
        {
            LINE L = new LINE();
            L.Code = l.Code;
            L.Area = (Emuns.AREA)l.Area;
            return L;
        }
        public LINE AddLineTripToLINE(LINE L,LineTrip lp)
        {
            L.StartAt = lp.StartAt;
            L.FinishAt = lp.FinishAt;
            L.Frequency = lp.Frequency;
            return L;
        }
        public void AddSTATIONLINE(STATIONLINE sl)
        {
            DO.LineStation a = new LineStation();
            a.lineCode = sl.LineCode;
            a.Station = sl.CodeStation;
            a.NextStation = sl.NextStation;
            dl.addLineStation(a);
            DO.AdjacentStations adj = new AdjacentStations();
            adj.Station1 = sl.CodeStation;
            adj.Station2 = sl.NextStation;
            adj.Distance = sl.Distance;
            adj.Time = sl.Time;
            adj.lineCode = sl.LineCode;
            dl.AddAdjacentStations(adj);
           // L.StationListOfLine.
           // dl.add
        }
        public STATIONLINE ConvertLineStationToSTATIONLINE(LineStation ls,TimeSpan t,double dis,string name)
        {
            STATIONLINE SL = new STATIONLINE();
            SL.CodeStation = ls.Station;
            SL.NextStation = ls.NextStation;
           // SL.PrevStation = ls.PrevStation;
            SL.LineCode = ls.lineCode;
           SL.Time = t;
           SL.Distance = dis;
            SL.StationName = name;
            return SL;
        }
        public IEnumerable<LINE> GetAllLINES()
        {

           IEnumerable<Line> ls = dl.GetAllLines();

            var v = from a in ls
                    select GetLINE(a.Code, (Emuns.AREA)a.Area);
            return v;
            // //try { IEnumerable<Line> ls = dl.GetAllLines(); }
            // //catch { throw new NotExistExceptionBO(); }
            // IEnumerable<Line> ls = dl.GetAllLines();
            // IEnumerable<LINE> L = from a in ls//מחזיר רשימת קווים של ביאו שיש בהם רק קוד ואיזור
            //                       select ConvertLineToLINE(a);
            // var v = from a in L//מחזיר רשימת קווים עם כל פרטי הליין טריפ שלהם
            //         from b in ls
            //         from c in dl.GetAllLineTripsBy(x => x.LineID == b.ID)
            //         select AddLineTripToLINE(a,c);

            // L = v;

            // var v1 = from a in L
            //          from b in ls
            //          from c in dl.GetAllLineStationsBy(x => x.LineID == b.ID)
            //          //select ConvertLineStationToSTATIONLINE(c);




            //// IEnumerable<LineStation> lnst = dl.GetAllLineStationsBy(x=>x.)


            // throw new NotImplementedException();
        }

        public LINE GetLINE(int code, Emuns.AREA area)
        {
            DO.Line l = dl.GetLine(code, (Line.AREA)area);
            LINE L = new LINE();
            L.Code = l.Code;
            L.Area = (Emuns.AREA)l.Area;
            //DO.LineTrip lp = dl.GetLineTrip(l.ID);
            //L.StartAt = lp.StartAt;
            //L.FinishAt = lp.FinishAt;
            //L.Frequency = lp.Frequency;
            IEnumerable<DO.LineStation> ls = dl.GetAllLineStationsBy(x => x.lineCode == l.Code);
          //  IEnumerable<DO.Station> st = dl.GetAllStations();
            IEnumerable<STATIONLINE> SL = from a in ls
                                          from b in dl.GetAllAdjacentStationsBy(x => x.Station1 == a.Station || x.Station2 == a.NextStation)
                                          from v in dl.GetAllStationsBy(y=>y.Code==a.Station)
                                          select ConvertLineStationToSTATIONLINE(a, b.Time, b.Distance,v.Name);

           
            L.StationListOfLine = SL;
            return L;
        
            //throw new NotImplementedException();
        }

        public STATION GetSTATION(int code)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<STATION> GetALLSTATION()
        {
            //מחזיר את רשימת כל התחנות הפיזיות 
            
                return from station in dl.GetAllStations()
                       let BOstation = station.CopyPropertiesToNew(typeof(BO.STATION)) as BO.STATION
                       select BOstation;          
        }
        public void SetDistance(double distance, int station1Code, int station2Code)
        {
            throw new NotImplementedException();
        }

        public void SetTime(TimeSpan ts, int station1Code, int station2Code)
        {
            throw new NotImplementedException();
        }

        public LineStation convertSTATIONLINEToLineStation(STATIONLINE SL,int lineID)
        {
            DO.LineStation ls = new LineStation();
            ls.lineCode = SL.LineCode;
            ls.Station = SL.CodeStation;
            ls.NextStation = SL.NextStation;
            ls.LineID = lineID;
            return ls;
        }
        public void UpdateLINE(LINE upline)
        {
            DO.Line ld = new Line();
            ld.Area = (Line.AREA)upline.Area;
            ld.Code = upline.Code;
            
            //DO.Line ld = dl.GetLine(upline.Code, (Line.AREA)upline.Area);
            dl.UpdateLine(ld);

            var v = from a in upline.StationListOfLine
                    select convertSTATIONLINEToLineStation(a, ld.ID);
            var v1 = from z in v
                     select dl.UpdateLineStation(z);
                    //from b in dl.GetAllLineStationsBy(x=>x.lineCode==a.LineCode && x.Station==a.CodeStation)

                    //dl.UpdateLineStation(dl.GetLineStation(upline.Code, a.CodeStation));
            //throw new NotImplementedException();
        }

        public void UpdateSTATION(STATION upstation)
        {
            throw new NotImplementedException();
        }



        //#region bus
        //public Bus1 BusDoBoAdapter(Bus busDo)
        //{
        //    Bus1 b = new Bus1();
        //    b.LicenseNum = busDo.LicenseNum;
        //    b.IsExist = busDo.IsExist;
        //    b.FuelTank = busDo.FuelTank;
        //    b.LicensingDate = busDo.LicensingDate;
        //    b.Mileage = busDo.Mileage;
        //    b.Status = (Bus1.STATUS)busDo.Status;
        //    return b;
        //}
        //public Bus1 GetBus1(int LicenseNum)
        //{
        //    DO.Bus busDo;
        //    try
        //    { busDo = dl.GetBus(LicenseNum); }
        //    catch { throw new BO.NotExistExceptionBO(); }
        //    return BusDoBoAdapter(busDo);
        //}

        //public void AddBus1(Bus1 newBus)
        //{
        //    DO.Bus b = new Bus();
        //    newBus.CopyPropertiesTo(b);
        //    try { dl.AddBus(b); }
        //    catch { throw new OlreadtExistException("this bus ia allreadt exist"); }
        //}
        //public void DeleteBus1(int licenseNum)// delete bus
        //{
        //    Bus1 delteBus1=GetBus1(licenseNum);
        //    DO.Bus b = new Bus();
        //    delteBus1.CopyPropertiesTo(b);
        //    try { dl.DeleteBus(b.LicenseNum); }
        //    catch { throw new NotExistException(); }
        //}
        //public void UpdateBus1(Bus1 upBus)
        //{
        //    DO.Bus b = new Bus();
        //    upBus.CopyPropertiesTo(b);
        //    try { dl.UpdateBus(b); }
        //    catch { throw new NotExistException(); }
        //}
        //public void UpdateBus1(int LicenseNumber, Action<Bus1> update)
        //{
        //    //try { dl.UpdateBus(LicenseNumber, update); }
        //    // catch { }
        //    throw new NotImplementedException();
        //}
        //#endregion



        //#region line/lineStation
        //public LineStation1 LineStationDOBOAdaptor(LineStation ls, string stationName)
        //{
        //    LineStation1 ls1 = new LineStation1();
        //    ls1.LineID = ls.LineID;
        //    ls1.LineStationIndex = ls.LineStationIndex;
        //    ls1.NextStation = ls.NextStation;
        //    ls1.PrevStation = ls.PrevStation;
        //    ls1.Station = ls.Station;
        //    ls1.StationName = stationName;
        //    return ls1;
        //}
        //public Line1 LineDoBoAdapter(Line lineDo)
        //{
        //    Line1 l = new Line1();
        //    l.Area = (Line1.AREA)lineDo.Area;
        //    l.Code = lineDo.Code;
        //    l.FirstStation = lineDo.FirstStation;
        //    l.LastStation = lineDo.LastStation;
        //    l.StationNum = lineDo.StationNum;
        //    return l;
        //}
        //public Line1 GetLine1(int Id)
        //{
        //    DO.Line lineDo;
        //    try { lineDo = dl.GetLine(Id); }
        //    catch { throw new BO.NotExistExceptionBO(); }

        //    return LineDoBoAdapter(lineDo);
        //}
        //public IEnumerable<LineStation1> GetAllStationInThisLine(int lineID)//רשימת כל התחנות שהקו עובר בהם
        //{
        //    return from s in dl.GetAllLineStations()
        //           where s.LineID == lineID
        //           from st in dl.GetAllStationsBy(x => x.Code == s.Station)
        //           select LineStationDOBOAdaptor(s, st.Name);//מוסיף לאובייקט החדש שלנו בביאל את שם התחנה שזה מה שירצה בסוף בתצוגה           
        //}
        //public void AddLine1(Line1 NewLine1)
        //{
        //    DO.Line l = new Line();
        //    NewLine1.CopyPropertiesTo(l);
        //    try { dl.AddLine(l); }
        //    catch { throw new NotExistException(); }
        //}
        //public void DeleteLine1(int lineID)
        //{
        //    //Line1 L1 = GetLine1(lineID);
        //    //DO.Line l = new Line();
        //   // L1.CopyPropertiesTo(l);
        //    try { dl.DeleteLine(lineID); }
        //    catch { throw new NotExistException(); }
        //}
        //public void updateLine1(Line1 l1)
        //{
        //    DO.Line l = new Line();
        //    l1.CopyPropertiesTo(l);
        //    try { dl.UpdateLine(l); }
        //    catch { throw new NotExistException(); }
        //}
        //public void updateLine1(int Id, Action<Line1> update)//???????????????????
        //{

        //}
        //#endregion


        //#region station
        //public Station1 stationDoBoAdapter(DO.Station s)
        //{
        //    Station1 sb = new Station1();
        //    sb.Address = s.Address;
        //    sb.Code = s.Code;
        //    sb.Latitude = s.Latitude;
        //    sb.Name = s.Name;
        //    sb.longitude = s.longitude;
        //    return sb;

        //}

        //public IEnumerable<Line1> GetAllLinesThatGoInStation(int code)//רשימת כל קויים שעוברים באותה תחנה
        //{
        //    var v = from line in dl.GetAllLineStationsBy(ls=>ls.Station==code)
        //            select line;
        //    return from ln in v
        //           from stln in dl.GetAllLinesBy(l => l.ID == ln.LineID)
        //           select LineDoBoAdapter(stln);

        //   // throw new NotImplementedException();
        //}

        //public Station1 GetStation1(int Code)
        //{
        //    DO.Station stationDo;
        //    try { stationDo = dl.GetStation(Code); }
        //    catch { throw new BO.NotExistExceptionBO(); }
        //    return stationDoBoAdapter(stationDo);
        //}
        //public void UpdateLineStation1(LineStation1 ls1)
        //{
        //    DO.LineStation ls = new LineStation();
        //    ls1.CopyPropertiesTo(ls);
        //    try { dl.UpdateLineStation(ls); }
        //    catch { throw new NotExistException(); }

        //}
        //public void AddStation1(Station1 s1)
        //{
        //    DO.Station s = new Station();
        //    s1.CopyPropertiesTo(s);
        //    try { dl.AddStation(s); }
        //    catch { throw new OlreadtExistException(); }
        //}
        //public void DeleteStation1(int code)
        //{
        //    try { dl.DeleteStation(code); }
        //    catch { throw new NotExistException(); }          
        //}
        //public void UpdateStation1(Station1 s1)
        //{
        //    DO.Station s = new Station();
        //    s1.CopyPropertiesTo(s);
        //    try { dl.UpdateStation(s); }
        //    catch { throw new NotExistException(); }
        //}
        //public void UpdateStation1(int code, Action<Station1> update)//??????????????????????????????????????
        //{

        //}
        //#endregion


        //public void SetDistance(double D, int station1Code, int station2Code)
        //{

        //}

        //public void SetTime(TimeSpan t, int station1Code, int station2Code)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
