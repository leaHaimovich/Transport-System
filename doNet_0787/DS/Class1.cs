using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DO;
using static DO.Bus;
using static DO.Line;

     
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
        public static object listUser;


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
                    LicenseNum = 1245670 + i,
                    Mileage = 100.0,
                    FuelTank = 50.3,
                    Status = STATUS.ReadyForRide
                };
                listBus.Add(b);
            }
            listStations = new List<Station>
            {
                #region Boot stations//איתחול תחנות
                new Station
                {
                    Code = 73,
                    Name = "שדרות גולדה מאיר/המשורר אצ''ג",
                    Address = "רחוב:שדרות גולדה מאיר  עיר: ירושלים ",
                    Latitude = 31.825302,
                    longitude = 35.188624
                },
                new Station
                {
                    Code = 76,
                    Name = "בית ספר צור באהר בנות/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים",
                    Latitude = 31.738425,
                    longitude = 35.228765
                },
                new Station
                {
                    Code = 77,
                    Name = "בית ספר אבן רשד/אלמדינה אלמונוורה",
                    Address = "רחוב:אל מדינה אל מונאוורה  עיר: ירושלים ",
                    Latitude = 31.738676,
                    longitude = 35.226704
                },
                new Station
                {
                    Code = 78,
                    Name = "שרי ישראל/יפו",
                    Address = "רחוב:שדרות שרי ישראל 15 עיר: ירושלים",
                    Latitude = 31.789128,
                    longitude = 35.206146
                },
                new Station
                {
                    Code = 83,
                    Name = "בטן אלהווא/חוש אל מרג",
                    Address = "רחוב:בטן אל הווא  עיר: ירושלים",
                    Latitude = 31.766358,
                    longitude = 35.240417
                },
                new Station
                {
                    Code = 84,
                    Name = "מלכי ישראל/הטורים",
                    Address = " רחוב:מלכי ישראל 77 עיר: ירושלים ",
                    Latitude = 31.790758,
                    longitude = 35.209791
                },
                new Station
                {
                    Code = 85,
                    Name = "בית ספר לבנים/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Latitude = 31.768643,
                    longitude = 35.238509
                },
                new Station
                {
                    Code = 86,
                    Name = "מגרש כדורגל/אלמדארס",
                    Address = "רחוב:אלמדארס  עיר: ירושלים",
                    Latitude = 31.769899,
                    longitude = 35.23973
                },
                new Station
                {
                    Code = 88,
                    Name = "בית ספר לבנות/בטן אלהוא",
                    Address = " רחוב:בטן אל הווא  עיר: ירושלים",
                    Latitude = 31.767064,
                    longitude = 35.238443
                },
                new Station
                {
                    Code = 89,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Latitude = 31.765863,
                    longitude = 35.247198
                },
                new Station
                {
                    Code = 90,
                    Name = "גולדה/הרטום",
                    Address = "רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.799804,
                    longitude = 35.213021
                },
                new Station
                {
                    Code = 91,
                    Name = "דרך בית לחם הישה/ואדי קדום",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים ",
                    Latitude = 31.765717,
                    longitude = 35.247102
                },
                new Station
                {
                    Code = 93,
                    Name = "חוש סלימה 1",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.767265,
                    longitude = 35.246594
                },
                new Station
                {
                    Code = 94,
                    Name = "דרך בית לחם הישנה ב",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.767084,
                    longitude = 35.246655
                },
                new Station
                {
                    Code = 95,
                    Name = "דרך בית לחם הישנה א",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.768759,
                    longitude = 31.768759
                },
                new Station
                {
                    Code = 97,
                    Name = "שכונת בזבז 2",
                    Address = " רחוב:דרך בית לחם הישנה  עיר: ירושלים",
                    Latitude = 31.77002,
                    longitude = 35.24348
                },
                new Station
                {
                    Code = 102,
                    Name = "גולדה/שלמה הלוי",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Latitude = 31.8003,
                    longitude = 35.208257
                },
                new Station
                {
                    Code = 103,
                    Name = "גולדה/הרטום",
                    Address = " רחוב:שדרות גולדה מאיר  עיר: ירושלים",
                    Latitude = 31.8,
                    longitude = 35.214106
                },
                new Station
                {
                    Code = 105,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 2 עיר: ירושלים",
                    Latitude = 31.797708,
                    longitude = 35.217133
                },
                new Station
                {
                    Code = 106,
                    Name = "גבעת משה",
                    Address = " רחוב:גבעת משה 3 עיר: ירושלים",
                    Latitude = 31.797535,
                    longitude = 35.217057
                },
                //20
                new Station
                {
                    Code = 108,
                    Name = "עזרת תורה/עלי הכהן",
                    Address = "  רחוב:עזרת תורה 25 עיר: ירושלים",
                    Latitude = 31.797535,
                    longitude = 35.213728
                },
                new Station
                {
                    Code = 109,
                    Name = "עזרת תורה/דורש טוב",
                    Address = "  רחוב:עזרת תורה 21 עיר: ירושלים ",
                    Latitude = 31.796818,
                    longitude = 35.212936
                },
                new Station
                {
                    Code = 110,
                    Name = "עזרת תורה/דורש טוב",
                    Address = " רחוב:עזרת תורה 12 עיר: ירושלים",
                    Latitude = 31.796129,
                    longitude = 35.212698
                },
                new Station
                {
                    Code = 111,
                    Name = "יעקובזון/עזרת תורה",
                    Address = "  רחוב:יעקובזון 1 עיר: ירושלים",
                    Latitude = 31.794631,
                    longitude = 35.21161
                },
                new Station
                {
                    Code = 112,
                    Name = "יעקובזון/עזרת תורה",
                    Address = " רחוב:יעקובזון  עיר: ירושלים",
                    Latitude = 31.79508,
                    longitude = 35.211684
                },
                //25
                new Station
                {
                    Code = 113,
                    Name = "זית רענן/אוהל יהושע",
                    Address = "  רחוב:זית רענן 1 עיר: ירושלים",
                    Latitude = 31.796255,
                    longitude = 35.211065
                },
                new Station
                {
                    Code = 115,
                    Name = "זית רענן/תורת חסד",
                    Address = " רחוב:זית רענן  עיר: ירושלים",
                    Latitude = 31.798423,
                    longitude = 35.209575
                },
                new Station
                {
                    Code = 116,
                    Name = "זית רענן/תורת חסד",
                    Address = "  רחוב:הרב סורוצקין 48 עיר: ירושלים ",
                    Latitude = 31.798689,
                    longitude = 35.208878
                },
                new Station
                {
                    Code = 117,
                    Name = "קרית הילד/סורוצקין",
                    Address = "  רחוב:הרב סורוצקין  עיר: ירושלים",
                    Latitude = 31.799165,
                    longitude = 35.206918
                },
                new Station
                {
                    Code = 119,
                    Name = "סורוצקין/שנירר",
                    Address = "  רחוב:הרב סורוצקין 31 עיר: ירושלים",
                    Latitude = 31.797829,
                    longitude = 35.205601
                },

                //#endregion //30
                new Station
                {
                    Code = 1485,
                    Name = "שדרות נווה יעקוב/הרב פרדס ",
                    Address = "רחוב: שדרות נווה יעקוב  עיר:ירושלים ",
                    Latitude = 31.840063,
                    longitude = 35.240062

                },
                new Station
                {
                    Code = 1486,
                    Name = "מרכז קהילתי /שדרות נווה יעקוב",
                    Address = "רחוב:שדרות נווה יעקוב ירושלים עיר:ירושלים ",
                    Latitude = 31.838481,
                    longitude = 35.23972
                },


                new Station
                {
                    Code = 1487,
                    Name = " מסוף 700 /שדרות נווה יעקוב ",
            Address = "חוב:שדרות נווה יעקב 7 עיר: ירושלים  ",
                    Latitude = 31.837748,
                    longitude = 35.231598
                },
                new Station
                {
                    Code = 1488,
                    Name = " הרב פרדס/אסטורהב ",
                    Address = "רחוב:מעגלות הרב פרדס  עיר: ירושלים רציף  ",
                    Latitude = 31.840279,
                    longitude = 35.246272
                },
                new Station
                {
                    Code = 1490,
                    Name = "הרב פרדס/צוקרמן ",
                    Address = "רחוב:מעגלות הרב פרדס 24 עיר: ירושלים   ",
                    Latitude = 31.843598,
                    longitude = 35.243639
                },
                new Station
                {
                    Code = 1491,
                    Name = "ברזיל ",
                    Address = "רחוב:ברזיל 14 עיר: ירושלים",
                    Latitude = 31.766256,
                    longitude = 35.173
                },
                new Station
                {
                    Code = 1492,
                    Name = "בית וגן/הרב שאג ",
                    Address = "רחוב:בית וגן 61 עיר: ירושלים ",
                    Latitude = 31.76736,
                    longitude = 35.184771
                },
                new Station
                {
                    Code = 1493,
                    Name = "בית וגן/עוזיאל ",
                    Address = "רחוב:בית וגן 21 עיר: ירושלים    ",
                    Latitude = 31.770543,
                    longitude = 35.183999
                },
                new Station
                {
                    Code = 1494,
                    Name = " קרית יובל/שמריהו לוין ",
                    Address = "רחוב:ארתור הנטקה  עיר: ירושלים    ",
                    Latitude = 31.768465,
                    longitude = 35.178701
                },
                new Station
                {
                    Code = 1510,
                    Name = " קורצ'אק / רינגלבלום ",
                    Address = "רחוב:יאנוש קורצ'אק 7 עיר: ירושלים",
                    Latitude = 31.759534,
                    longitude = 35.173688
                },
                new Station
                {
                    Code = 1511,
                    Name = " טהון/גולומב ",
                    Address = "רחוב:יעקב טהון  עיר: ירושלים     ",
                    Latitude = 31.761447,
                    longitude = 35.175929
                },
                new Station
                {
                    Code = 1512,
                    Name = "הרב הרצוג/שח''ל ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Latitude = 31.761447,
                    longitude = 35.199936
                },
                new Station
                {
                    Code = 1514,
                    Name = "פרץ ברנשטיין/נזר דוד ",
                    Address = "רחוב:הרב הרצוג  עיר: ירושלים רציף",
                    Latitude = 31.759186,
                    longitude = 35.189336
                },
               
        
             new Station
            {
            Code = 1518,
            Name = "פרץ ברנשטיין/נזר דוד",
            Address = " רחוב:פרץ ברנשטיין 56 עיר: ירושלים ",
            Latitude = 31.759121,
            longitude = 35.189178
        },
              new Station
              {
            Code = 1522,
            Name = "מוזיאון ישראל/רופין",
            Address = "  רחוב:דרך רופין  עיר: ירושלים ",
            Latitude = 31.774484,
            longitude = 35.204882
                },

             new Station
                  {
             Code = 1523,
            Name = "הרצוג/טשרניחובסקי",
            Address = "   רחוב:הרב הרצוג  עיר: ירושלים  ",
            Latitude = 31.769652,
            longitude = 35.208248
                },
              new Station
                {
              Code = 1524,
            Name = "רופין/שד' הזז",
            Address = "    רחוב:הרב הרצוג  עיר: ירושלים   ",
            Latitude = 31.769652,
            longitude = 35.208248,
                 },
                new Station
                {
                    Code = 121,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = " רחוב:הרב סורוצקין 13 עיר: ירושלים",
                    Latitude = 31.796033,
                    longitude =35.206094
                },
                new Station
                {
                    Code = 123,
                    Name = "אוהל דוד/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 9 עיר: ירושלים",
                    Latitude = 31.794958,
                    longitude =35.205216
                },
                new Station
                {
                    Code = 122,
                    Name = "מרכז סולם/סורוצקין ",
                    Address = "  רחוב:הרב סורוצקין 28 עיר: ירושלים",
                    Latitude = 31.79617,
                    longitude =35.206158
                }

                
                #endregion
            };
            listUsers = new List<User>();

            listLine = new List<Line>
            {
          #region Initialize lines//איתחול קווים
                new Line
                {
                    ID=1,
                    Code=32,
                    Area=AREA.CENTER,
                    FirstStation=73,
                   LastStation = 89,
                   StationNum=10
                },
                new Line
                {
                     ID=2,
                    Code=45,
                    Area=AREA.CENTER,
                    FirstStation=89,
                   LastStation = 105,
                   StationNum=10
                },
                new Line
                {
                    ID=3,
                    Code=36,
                    Area=AREA.CENTER,
                    FirstStation=105,
                   LastStation = 116,
                   StationNum=10
                },
                new Line
                {
                    ID=4,
                    Code=50,
                    Area=AREA.CENTER,
                    FirstStation=73,
                   LastStation = 122,
                   StationNum=50
                },
                new Line
                {
                    ID=5,
                    Code=56,
                    Area=AREA.CENTER,
                    FirstStation=122,
                   LastStation = 1511,
                   StationNum=11
                },
                new Line
                {
                    ID=6,
                    Code=28,
                    Area=AREA.CENTER,
                    FirstStation=1492,
                   LastStation = 1523,
                   StationNum=12
                },
                new Line
                {
                    ID=7,
                    Code=69,
                    Area=AREA.CENTER,
                    FirstStation=1485,
                   LastStation = 1510,
                   StationNum=10
                },
                new Line
                {
                    ID=8,
                    Code=58,
                    Area=AREA.CENTER,
                    FirstStation=105,
                   LastStation = 119,
                   StationNum=12
                },
                new Line
                {
                    ID=9,
                    Code=92,
                    Area=AREA.CENTER,
                    FirstStation=77,
                   LastStation = 95,
                   StationNum=13
                },
                new Line
                {
                    ID=10,
                    Code=55,
                    Area=AREA.CENTER,
                    FirstStation=1485,
                   LastStation = 1514,
                   StationNum=13
                },

#endregion
                
        };
            DO.StaticRunNumbers.RUNNUMBERLineID += 10;

            listLineStation = new List<LineStation>
            {
                new LineStation{ lineCode=32,Station=73, LineStationIndex=1, NextStation=76, PrevStation=0},
                new LineStation{ lineCode=32,Station=76, LineStationIndex=2, NextStation=77, PrevStation=73},
                new LineStation{ lineCode=32,Station=77, LineStationIndex=3, NextStation=78, PrevStation=76},
                new LineStation{ lineCode=32,Station=78, LineStationIndex=4, NextStation=83, PrevStation=77},
                new LineStation{ lineCode=32,Station=83, LineStationIndex=5, NextStation=84, PrevStation=78},
                new LineStation{ lineCode=32,Station=84, LineStationIndex=6, NextStation=85, PrevStation=83},
                new LineStation{ lineCode=32,Station=85, LineStationIndex=7, NextStation=86, PrevStation=84},
                new LineStation{ lineCode=32,Station=86, LineStationIndex=8, NextStation=88, PrevStation=85},
                new LineStation{ lineCode=32,Station=88, LineStationIndex=9, NextStation=89, PrevStation=86}



            };

            listAdjacentStation = new List<AdjacentStations>
            {
                new AdjacentStations{ Distance=10, Station1=73, Station2=76, Time=new TimeSpan(0,10,30),lineCode=32},
                new AdjacentStations{ Distance=10, Station1=76, Station2=77, Time=new TimeSpan(0,10,30),lineCode=32},
                new AdjacentStations{ Distance=5.5, Station1=77, Station2=78, Time=new TimeSpan(0,10,30),lineCode=32},
                new AdjacentStations{ Distance=2, Station1=78, Station2=83, Time=new TimeSpan(0,1,30),lineCode=32},
                new AdjacentStations{ Distance=6, Station1=83, Station2=84, Time=new TimeSpan(0,7,30),lineCode=32},
                new AdjacentStations{ Distance=10, Station1=84, Station2=85, Time=new TimeSpan(0,6,30),lineCode=32},
                new AdjacentStations{ Distance=10, Station1=85, Station2=86, Time=new TimeSpan(0,10,30),lineCode=32},
                 new AdjacentStations{ Distance=12, Station1=86, Station2=88, Time=new TimeSpan(0,12,30),lineCode=32},
                  new AdjacentStations{ Distance=12, Station1=88, Station2=89, Time=new TimeSpan(0,12,30), lineCode=32}
            };
            listLineTrip = new List<LineTrip>
            {
                new LineTrip{ ID=1, LineID=1, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=2, LineID=2, StartAt=new TimeSpan(7,30,0), FinishAt=new TimeSpan(23,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=3, LineID=3, StartAt=new TimeSpan(8,0,0), FinishAt=new TimeSpan(22,30,0), Frequency=new TimeSpan(0,20,0)},
                new LineTrip{ ID=4, LineID=4, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=5, LineID=5, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=6, LineID=6, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=7, LineID=7, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=8, LineID=8, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=9, LineID=55, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)},
                new LineTrip{ ID=10, LineID=32, StartAt=new TimeSpan(7,0,0), FinishAt=new TimeSpan(10,30,0), Frequency=new TimeSpan(0,30,0)}
            };
        }

    }
}

