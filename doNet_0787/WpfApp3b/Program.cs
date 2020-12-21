/*Lea haimovich 324240787
 * Bat sheva cohen 211735626
 */
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using static Buss;

namespace WpfApp3b
{
    class Program
    {
        private static Buss.STATUS inRide;

        public static Buss.STATUS Rufueling { get; private set; }
        public static Buss.STATUS Treat { get; private set; }
        public static Buss.STATUS ReadyForRide { get; private set; }

        public static void RandomBuses(List<Buss> lsb)//3b// random  10 buses
        {
           // List<Buss> listbuss = new List<Buss>();
            for(int i=1;i<=10;i++)
            {
                Random r = new Random();
                Buss t = new Buss();
                t.LicenseNumber = i.ToString();
                t.Km = i * 10;
                t.KmafterRefueling = r.Next(0, 100);
                t.kMFromLastTreat = r.Next(0, 100);
                 DateTime d = new DateTime(r.Next(2000, 2020), r.Next(1, 12), r.Next(1, 30));
                t.LastTreat = d;//להגריל תאריך
                lsb.Add(t);
            }
            lsb[0].kMFromLastTreat = 19999;
            lsb[1].KmafterRefueling = 1100;
            lsb[2].LastTreat = new DateTime(2019, 12, 13);

           // return lsb;
        }



        public static bool CheckLicenseNumber(string lpn, List<Buss> listBuss)
        {
            int size = lpn.Length;
            int s;///x,o
            if (size != 7 && size != 8)//אם הלוחית רישוי בגודל תקין
            {
                Console.WriteLine("ERROR: the license Number is Illegal");
                return false;


            }
            bool degel = false;
            foreach (Buss buss in listBuss)
            {
                if (buss.LicenseNumber == lpn) degel = true;
            }
            if (degel)
            {
                Console.WriteLine("ERROR: the bus already exist\n");
                return false;
            }

            return true;
        }

        public static bool isExist(string lpn, List<Buss> listBuss)//אם קיים אוטובוס אם לוח הרשאה דומה
        {
            bool degel = false;
            foreach (Buss buss in listBuss)
            {
                if (buss.LicenseNumber == lpn) degel = true;
            }
            if (degel)
                return true;
            Console.WriteLine("bus dosnt exit");
            return false;
        }


        public static bool isDangaras(Buss s, int kiml)//בודק האם האוטובוס יכול לנסוע או זקוק לתידלוק או טיפול
        {
            int e = (int)s.kMFromLastTreat;
            int r = (int)s.KmafterRefueling;
            if ((e + kiml) >= 20000)
            {
                Console.WriteLine("ERROR: cant go, need a treatment/t");
                return false;
            }
            if ((r + kiml) > 1200)
            {
                Console.WriteLine("ERROR: cant go, need to refueling");
                return false;
            }
            else

                return true;
        }








        public static bool chooseBuss(string lpn, double k1, List<Buss> listbus)
        {

            foreach (Buss buss in listbus)//goung thro all busses
            {
                int e, r;
                if (buss.LicenseNumber == lpn)
                {
                    e = (int)buss.kMFromLastTreat;
                    r = (int)buss.KmafterRefueling;
                    if ((e + k1) >= 20000 || (buss.LastTreat.Year + 1) < DateTime.Now.Year)
                    {
                        Console.WriteLine("ERROR: cant go, need a treatment\n");
                        return false;
                    }
                    if ((r + k1) > 1200)
                    {
                        Console.WriteLine("ERROR: cant go, need to refueling\n");
                        return false;
                    }
                    if (buss.LastTreat.Year > DateTime.Now.Year)
                    {
                        Console.WriteLine("ERROR: need to go to treatment, over a year\n");
                        return false;
                    }
                    buss.Status = 0;
                    //buss.Status = ReadyForRide;//לבדוקקק
                    
                    buss.Km += (int)k1;
                    buss.KmafterRefueling += (int)k1;
                    buss.kMFromLastTreat += (int)k1;
                    //buss.Status = 1;
                    buss.Status = StatusBus.inMiddleOfRide;
                    return true;
                }
            }
            return true;
        }


        public static bool refueling(string lpn, List<Buss> listBuss)
        {
            foreach (Buss buss in listBuss)//goung thro all busses
            {

                if (buss.LicenseNumber == lpn) { buss.KmafterRefueling = 0;
                    buss.Status = StatusBus.Rufueling;
                }
                return true;
            }
            return false;
        }


        public static bool tretment(string lpn, List<Buss> listBuss)
        {
            foreach (Buss buss in listBuss)//goung thro all busses
            {

                if (buss.LicenseNumber == lpn)
                {
                    buss.kMFromLastTreat = 0;
                    buss.LastTreat = DateTime.Now;
                    buss.Status = StatusBus.inTreat;
                }
                return true;
            }
            return false;
        }


        public static void printBusses(List<Buss> listBuss)
        {
            foreach (Buss buss in listBuss)//goung thro all busses
            {
                //Console.WriteLine($"license Number:  {buss.LicenseNumber}");
                if (buss.LicenseNumber.Length == 7)
                {
                    Console.WriteLine("license Number: " + buss.LicenseNumber.Substring(0, 2) + "-" + buss.LicenseNumber.Substring(3, 3) + "-" + buss.LicenseNumber.Substring(5, 2));
                    //Console.WriteLine("-");


                }
                if (buss.LicenseNumber.Length == 8)
                {
                    Console.WriteLine("license Number: " + buss.LicenseNumber.Substring(0, 3) + "-" + buss.LicenseNumber.Substring(3, 2) + "-" + buss.LicenseNumber.Substring(5, 3));
                    //Console.WriteLine(buss.LicenseNumber.Substring(3, 2)+"-");
                    //Console.WriteLine(buss.LicenseNumber.Substring(6, 3));

                }

                Console.WriteLine($"General travel:  {buss.Km}");
                Console.WriteLine($"General travel then last treatment:  {buss.kMFromLastTreat}\n");


            }
        }

        //static void Main(string[] args)
        //{
        //    List<Buss> listBuss = new List<Buss>();//רשימת האוטובוסים
        //    char ch;
        //    do
        //    {
        //        Console.WriteLine("\nChoose one of the following:");
        //        Console.WriteLine("a: to add new bus to the company");//הןספת אוטובוס לחברה
        //        Console.WriteLine("b: to choose a buss for a ride");//בחירת אואטובוס לנסיעה
        //        Console.WriteLine("t: for tret or Refueling");//תידלוק או טיפול
        //        Console.WriteLine("p:Traveled since the last treatment");
        //        Console.WriteLine("e: to Exit\n");
        //        ch = char.Parse(Console.ReadLine());


        //        Random r = new Random(DateTime.Now.Millisecond);
        //        string lpn;
        //        DateTime t;

        //        switch (ch)
        //        {
        //            case 'a':
        //                Console.WriteLine("Enter license plate number  ");
        //                lpn = Console.ReadLine();
        //                if (!CheckLicenseNumber(lpn, listBuss)) break;
        //                Console.WriteLine("Enter start date of activity as follows: 12 Juni 2008(day month year) ");
        //                string dateString = Console.ReadLine();
        //                DateTime dTime; bool check = DateTime.TryParse(dateString, out dTime);
        //                if (!check) { Console.WriteLine("ERROR: the date wrong"); break; }
        //                var cultureInfo = new CultureInfo("de-DE");
        //                var dateTime = DateTime.Parse(dateString, cultureInfo);
        //                if (dateTime > DateTime.Now) { Console.WriteLine("ERROR: the date is wrong"); break; }
        //                // The example displays the following output:
        //                //       6/12/2008 00:00:00
        //                if (lpn.Length == 8 && dateTime.Year < 2018) { Console.WriteLine("ERROR: license plate number not mutch the start date of activity"); break; }
        //                Buss newBus1 = new Buss(lpn, dateTime);
        //                listBuss.Add(newBus1);
        //                break;


        //            case 'b':
        //                bool isEmpty = !listBuss.Any();
        //                if (isEmpty) { Console.WriteLine("there os n busses yet"); break; }
        //                Console.WriteLine("Enter license plate number of the needed buss");
        //                lpn = Console.ReadLine();
        //                if (!isExist(lpn, listBuss)) break;// בודק האם האוטובוס נמצא
        //                double k = r.NextDouble();//מגריל מספר של ק"מ
        //                chooseBuss(lpn, k, listBuss);
        //                break;


        //            case 't':
        //                bool iEmpty = !listBuss.Any();
        //                if (iEmpty) { Console.WriteLine("there os n busses yet"); break; }
        //                Console.WriteLine("Enter license plate number");
        //                lpn = Console.ReadLine();
        //                if (!isExist(lpn, listBuss)) break;// בודק האם האוטובוס נמצא
        //                Console.WriteLine("For refueling press 1 for treatment press 2");
        //                int n = int.Parse(Console.ReadLine());
        //                if (n == 1) { refueling(lpn, listBuss); }
        //                if (n == 2) { tretment(lpn, listBuss); }

        //                break;
        //            case 'p':
        //                bool isEmpt = !listBuss.Any();
        //                if (isEmpt) { Console.WriteLine("there os n busses yet"); break; }
        //                printBusses(listBuss);

        //                break;
        //            case 'e':
        //                Console.WriteLine("BYE BYE");
        //                break;

        //            default: Console.WriteLine("ERROR"); break;
        //        }
        //    } while (ch != 'e');












        //}








    }
}


