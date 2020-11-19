using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Buses_line f = new Buses_line();
            List<BusLineStation> s = new List<BusLineStation>();
            Random rnd = new Random();
            for (int i = 0; i < 40; i++)
            {
                BusLineStation o = new BusLineStation();
                //Random rnd = new Random();
                int num = rnd.Next(0, 1000);
                o.BUStationKey = num;
                //Random rnd = new Random();
                int d = rnd.Next(0, 100);
                o.DIstanceFromPrevStaition = d;
                int t = rnd.Next(0, 100);//rand time im miniute
                o.TimeFromPrevStation = t;
                double x = rnd.NextDouble();
                int x1 = rnd.Next(0, 100);
                double y = rnd.NextDouble();
                int y1 = rnd.Next(0, 100);
                o.LAtitude = x + x1;
                o.LOngitude = y + y1;
                s.Add(o);
            }
            int j = 0;
            for (int i = 0; i < 10; i++)
            {
                Bus_Line a = new Bus_Line();
                a.BusLine = i;
                // f.BusesCollect = a;
                a.FirstStation = s[j].BUStationKey;
                for (int r = 0; r < 4; r++)
                { a.Stations.Add(s[j]);
                    j++; }
                a.LastStation = s[j - 1].BUStationKey;//בעיות באינדקס
                f.addNewBussLine(a);


            }
            int c = 4;
            for (int i = 0; i < 10; i++)
            {
                f.busesCollect[c].addNewStation(s[i].BUStationKey, s[i]);
                //c++;//בעיות באינדקס
            }
            //foreach (Bus_Line item in f)
            //{


            //}





            Console.WriteLine("\nChoose one of the following:");
            Console.WriteLine("a: to add new bus line");//קו אוטובוס חדש
            Console.WriteLine("d: to add new staition to bus line");//הוספת תחנה לקו אוטובוס
            Console.WriteLine("u: to delete bus line");//גריעת קו אוטובוס
            Console.WriteLine("l:to delete staition from bus line ");// מחיקת תחנה ממסלול קו אוטובוס
            Console.WriteLine("k: for getting buses lines  that going throw a station");//קווים שעוברים בתחנה ע"פ מספר תחנה
            Console.WriteLine("o:print options for travel between two stations");// הדפסת האפשרויות לנסיעה בין 2 תחנות
            Console.WriteLine("p;print all buses lines");  //כל קווי האוטובוס במערכת
            Console.WriteLine("z:print all stations and number of buses lines that go throw them");//רשימת כל התחנות ומספרי הקווים שעוברים דרכם
            Console.WriteLine("e: to Exit\n");

            //try
            //{


                char ch1;
                do
                {
                
                    ch1 = char.Parse(Console.ReadLine());
                try
                {
                    switch (ch1)
                    {
                        case 'a':
                            Bus_Line n = new Bus_Line();
                            Console.WriteLine("enter bus line number");
                            n.BusLine = int.Parse(Console.ReadLine());// bus number
                            f.addNewBussLine(n);
                            break;

                        case 'd':
                            Console.WriteLine("enter bus line number and station number ");
                            int d = int.Parse(Console.ReadLine());// bus number
                            int q = int.Parse(Console.ReadLine());// station number
                            BusLineStation s1 = new BusLineStation();
                            s1.BUStationKey = q;
                            bool f1 = false;
                            foreach (Bus_Line bus_Line in f)
                            {
                                if (bus_Line.BusLine == d) { bus_Line.addNewStation(-1, s1); f1 = true; break; }
                            }
                            if (f1) Console.WriteLine("the bus line number is wrong");//במקום חריגההה
                            break;

                        case 'u':
                            Console.WriteLine("enter bus line number for delete");
                            int g = int.Parse(Console.ReadLine());// bus number
                            f.deleteBusLineFromList(g);

                            break;
                        case 'l'://מחיקת תחנה ממסלול קו אוטובוס
                            Console.WriteLine("enter bus line number and staition number for delete");
                            int d1 = int.Parse(Console.ReadLine());// bus number
                            int q1 = int.Parse(Console.ReadLine());// station number
                            bool f2 = false;
                            foreach (Bus_Line bus_Line in f)
                            {
                                if (bus_Line.BusLine == d1) { bus_Line.deletStation(q1); f2 = true; break; }
                            }
                            if (f2) Console.WriteLine("the bus line number is wrong");//במקום חריגההה
                            break;


                        case 'k'://ווים שעוברים בתחנה ע"פ מספר תחנה
                            Console.WriteLine(" Enter station number");
                            int q2 = int.Parse(Console.ReadLine());// station number
                            foreach(Bus_Line bus_Line in f.busesInThisStaition(q2))
                            {
                                Console.WriteLine("bus line: ");
                                Console.WriteLine(bus_Line.BusLine);
                            }
                           // Console.WriteLine(f.busesInThisStaition(q2));
                            break;

                        case 'o':
                            Console.WriteLine("Enter departure station and destination station");


                            break;


                        case 'p':
                            foreach (Bus_Line bus_Line in f)
                            {
                                Console.WriteLine(bus_Line.ToString());
                                Console.WriteLine("\n");
                            }
                            break;

                        case 'z':

                        case 'e':
                            Console.WriteLine("BYE BYE");
                            break;

                        default:
                            break;
                    }
                }
                catch (BusException massege)
                {
                    Console.WriteLine(massege);
                }
                catch (Exception)
                {

                    throw;
                }
            } while (ch1 != 'e');

            //}
            //catch (BusException massege)
            //{
            //    Console.WriteLine(massege);
            //}
            //catch (Exception)
            //{

            //    throw;
            //}






     





    }

        }
    }
//}
