using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;


namespace Ex11
{
    class Program
    {

        public static bool CheckLicenseNumber(string lpn)
        {
            int size = lpn.Length;
            if (size != 7 || size != 8)//אם הלוחית רישוי בגודל תקין
            {
                Console.WriteLine("ERROR: the license Number is Illegal");
                return false;
            }
            return true;
        }
              
        public static bool isExist(string lpn, List<Buss> listBuss)//אם קיים אוטובוס אם לוח הרשאה דומה
        {
            bool degel = false;
            foreach(Buss buss in listBuss)
            {
                if (buss.LicenseNumber == lpn) degel = true;
            }
            if(degel)
            return true;
            Console.WriteLine("bus dosnt exit");
            return false;
        }

        public static Buss returnBussObject(string lpn, List<Buss> listBus)//מקבלת לוח רישוי ומחזירה את האובייקט המתאים לו
        {
            foreach (Buss buss in listBus)
            {
                if (buss.LicenseNumber == lpn) return buss;
            }
            Buss s = new Buss();
            return s;
        }
        public static bool isDangaras(Buss s,int kiml)//בודק האם האוטובוס יכול לנסוע או זקוק לתידלוק או טיפול
        {
            int e = (int)s.kMFromLastTreat;
            int r = (int)s.KmafterRefueling;
            if ((e + kiml) >= 20000)
                                     {
                                        Console.WriteLine("ERROR: cant go, need a treatment");
                                       return false; }
            if ((r + kiml) > 1200) {
                                      Console.WriteLine(  "ERROR: cant go, need to refueling");
                                    return false; }
            else return true;
        }



        static void Main(string[] args)
        {
            List<Buss> listBuss = new List<Buss>();//רשימת האוטובוסים
            char ch;
            do
            {
                Console.WriteLine("Choose one of the following:");
                Console.WriteLine("a: to add new bus to the company");//הןספת אוטובוס לחברה
                Console.WriteLine("b: to choose a buss for a ride");//בחירת אואטובוס לנסיעה
                Console.WriteLine("t: for tret or Refueling");//תידלוק או טיפול
                Console.WriteLine("k:Traveled since the last treatment");
                Console.WriteLine("e: to Exit");
                ch = char.Parse(Console.ReadLine());
            

            Random r=new Random(DateTime.Now.Millisecond);
            string lpn;
            DateTime t;

            switch (ch)
            {
                case 'a':
                    Console.WriteLine("Enter license plate number and start date of activity");
                    lpn = Console.ReadLine();
                    if(!CheckLicenseNumber(lpn))break;
                    bool check = DateTime.TryParse(Console.ReadLine(), out t);
                    Buss newBus1 = new Buss(lpn,t);
                    listBuss.Add(newBus1);
                    break;

                case 'b':
                    Console.WriteLine("Enter license plate number of the needed buss");
                    lpn=Console.ReadLine();
                        if (!isExist(lpn,listBuss))break ;// בודק האם האוטובוס נמצא
                    double k=r.NextDouble();//מגריל מספר של ק"מ
                        if(!isDangaras(returnBussObject(lpn, listBuss), (int)k))break;
                        Buss b = returnBussObject(lpn, listBuss);
                        b.Km += (int)k;
                        b.KmafterRefueling += (int)k;
                        b.kMFromLastTreat += (int)k;                  
                    break;
                case 't':
                    break;
                case 'k':
                    break;
                case 'e':
                    break;
            }
            } while (ch != 'e');












        }





    


    }
    }


