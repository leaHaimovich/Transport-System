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
                    if ((e + k1) >= 20000)
                    {
                        Console.WriteLine("ERROR: cant go, need a treatment");
                        return false;
                    }
                    if ((r + k1) > 1200)
                    {
                        Console.WriteLine("ERROR: cant go, need to refueling");
                        return false;
                    }
                    if(buss.LastTreat.Year> DateTime.Now.Year)
                    {
                        Console.WriteLine("ERROR: need to go to treatment, over a year");
                        return false;
                    }
                   buss.Km += (int)k1;
                    buss.KmafterRefueling += (int)k1;
                     buss.kMFromLastTreat += (int)k1;
                    return true;
                }
            }
            return true;
        }
            

        public static bool refueling( string lpn, List<Buss> listBuss)
        {
            foreach (Buss buss in listBuss)//goung thro all busses
            {

                if (buss.LicenseNumber == lpn) { buss.KmafterRefueling = 0; }
                return true;
             }
            return false;
        }


        public static bool tretment(string lpn, List<Buss> listBuss)
        {
            foreach (Buss buss in listBuss)//goung thro all busses
            {

                if (buss.LicenseNumber == lpn) { buss.kMFromLastTreat = 0;
                buss.LastTreat= DateTime.Now;
                }
                return true;
            }
            return false;
        }
   

        public static void printBusses( List<Buss> listBuss)
        {
            foreach (Buss buss in listBuss)//goung thro all busses
            {                 
                    Console.WriteLine($"license Number:{buss.LicenseNumber}");
                    Console.WriteLine($"General travel:{buss.Km}");
                    Console.WriteLine($"General travel then last treatment:{buss.kMFromLastTreat}");

                
            }
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
                        chooseBuss(lpn,k,listBuss);                                                        
                        break;


                case 't':
                        Console.WriteLine("Enter license plate number");
                        lpn = Console.ReadLine();
                        if (!isExist(lpn, listBuss)) break;// בודק האם האוטובוס נמצא
                        Console.WriteLine("For refueling press 1 for treatment press 2");                       
                       int n = int.Parse(Console.ReadLine());
                        if (n == 1) { refueling(lpn, listBuss); }
                        if (n == 2) { tretment(lpn, listBuss); }
                        
                        break;
                case 'k': printBusses(listBuss);

                    break;
                case 'e':
                    break;
            }
            } while (ch != 'e');












        }





    


    }
    }


