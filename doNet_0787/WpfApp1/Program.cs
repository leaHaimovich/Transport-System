//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace WpfApp1
//{
//    /// <summary>
//    /// Main function for realizing all requested operations
//    /// </summary>
//    class Program
//    {
        
//        static Random r = new Random();
//        static List<BusStop> listOfStations = new List<BusStop>();
//        static BusCompany lines = new BusCompany();
//        static void Main(string[] args)
//        {
//            createStationsList(ref listOfStations);
//            createLinesList(ref lines, ref listOfStations);
 
//            bool sucsses;
//            int select;
//            CHOICE choice;
//            do
//            {
//                do
//                {
//                    Console.WriteLine("please enter your choice: ");
//                    Console.WriteLine("ADD, DELETE, FIND, PRINT, EXIT");
//                    sucsses = Enum.TryParse(Console.ReadLine(), out choice);
//                }
//                while (sucsses == false);
//                switch (choice)
//                {
//                    case CHOICE.ADD:
//                        Console.WriteLine("plese enter 1 to add a bus and 2 to add a station: ");
//                        do
//                        {
//                          select = int.Parse(Console.ReadLine());
//                        } while (select != 1 && select != 2);
//                        if(select == 1)
//                        {
//                            Console.WriteLine("enter the num of bus: ");
//                            int num = int.Parse(Console.ReadLine());
//                            Console.WriteLine("How many stations will you want to put in the line:");
//                            int count = int.Parse(Console.ReadLine());
//                            List<LineStation> rout = new List<LineStation>();
//                            createRoute(ref rout, count);
//                            AREA area;
//                            do
//                            {
//                                Console.WriteLine("In what area the bus travels?: ");
//                                Console.WriteLine("GENERAL, NORTH, SOUTH, EAET, WEST, GUSH_DAN");
//                                sucsses = Enum.TryParse(Console.ReadLine(), out area);
//                            } while (!sucsses);
//                            LineBus newLine = new LineBus(rout, num, area);
//                            try
//                            {
//                                lines.addLine(newLine);
//                            }
//                            catch (ArgumentException exception)
//                            {
//                                Console.WriteLine(exception.Message);
//                            }
//                        }
//                        if(select == 2)
//                        {
//                            Console.WriteLine("in which line do you wont to add a station?: ");
//                            printLines();
//                            int answer = int.Parse(Console.ReadLine());
//                            try
//                            {
//                                if (lines[answer] != null)
//                                {
//                                    Console.WriteLine("enter the new station num: ");
//                                    int num = int.Parse(Console.ReadLine());
//                                    Console.WriteLine("enter the location of the new station: ");
//                                    string location = Console.ReadLine();
//                                    Console.WriteLine("enter the distance from the previous station: ");
//                                    int distance = int.Parse(Console.ReadLine());
//                                    Console.WriteLine("enter the time travel from the previous station: ");
//                                    int time = int.Parse(Console.ReadLine());
//                                    double latitude = r.NextDouble() * (33.3 - 31) + 31;
//                                    double longitude = r.NextDouble() * (35.5 - 34.3) + 34.3;
//                                    BusStop newStop = new BusStop(num, location, latitude, longitude);
//                                    listOfStations.Add(newStop);
//                                    LineStation newLineStation = new LineStation(newStop, distance, time);
//                                    Console.WriteLine("Where in the list of stations would you like to add the new station");
//                                    int numLocation = int.Parse(Console.ReadLine());
//                                    lines[answer].addStation(newLineStation, numLocation);
//                                }
//                            }
//                            catch(ArgumentException exception)
//                            {
//                                Console.WriteLine(exception.Message);
//                            }

//                        }
//                        break;
//                    case CHOICE.DELETE:
//                        Console.WriteLine("plese enter 1 to delete a bus and 2 to delete a station: ");
//                        do
//                        {
//                            select = int.Parse(Console.ReadLine());
//                        } while (select != 1 && select != 2);
//                        if (select == 1)
//                        {
//                            try
//                            {
//                                Console.WriteLine("enter the num of bus: ");
//                                int answer = int.Parse(Console.ReadLine());
//                                lines.deleteLine(answer);
//                            }
//                            catch (ArgumentException exception)
//                            {
//                                Console.WriteLine(exception.Message);
//                            }
//                        }
//                        if (select == 2)
//                        {
//                            Console.WriteLine("in which line do you wont to add a station?: ");
//                            int line = int.Parse(Console.ReadLine());
//                            try
//                            {
//                                if (lines[line] != null)
//                                {
//                                    Console.WriteLine("enter the num of station: ");
//                                    int station = int.Parse(Console.ReadLine());
//                                    lines[line].removeStation(station);
//                                }
//                            }
//                            catch (ArgumentException exception)
//                            {
//                                Console.WriteLine(exception.Message);
//                            }
//                        }
//                        break;
//                    case CHOICE.FIND:
//                        Console.WriteLine("enter 1 to print the lines in station and 2 to compare routes");
//                        do
//                        {
//                            select = int.Parse(Console.ReadLine());
//                        } while (select != 1 && select != 2);
//                        if(select==1)
//                        {
//                            Console.WriteLine("enter the number of station: ");
//                            int station = int.Parse(Console.ReadLine());
//                            foreach (LineBus item in lines)
//                            {
//                                if (item.searchNumStation(station))
//                                {
//                                    Console.WriteLine(item);
//                                }
//                            }
//                        }
//                        if(select == 2)
//                        {
//                            Console.WriteLine("Enter the number of the departure station");
//                            int firstStation = int.Parse(Console.ReadLine());
//                            BusStop departureStation = new BusStop(); 
//                            foreach (BusStop item in listOfStations)
//                            {
//                                if (item.StationNum == firstStation)
//                                    departureStation = item;
//                                break;
//                            }
                            
//                            Console.WriteLine("Enter the number of the destination station");
//                            int secondStation = int.Parse(Console.ReadLine());
//                            BusStop destinationStation = new BusStop();
//                            foreach (BusStop item in listOfStations)
//                            {
//                                if (item.StationNum == secondStation)
//                                    destinationStation = item;
//                                break;
//                            }
//                            LineBus newSubLine = new LineBus();
//                            BusCompany subList = new BusCompany();
//                            foreach (LineBus item in lines)
//                            {
//                                if(item.searchNumStation(firstStation) && item.searchNumStation(secondStation))
//                                {
//                                    newSubLine = item.SubRouteLine(firstStation, secondStation);
//                                    subList.addLine(newSubLine);
//                                }
//                            }
//                            subList.sortedListOfLines();
//                            foreach (LineBus item in subList)
//                            {
//                                Console.WriteLine(item);
//                            }
//                        }
//                        break;
//                    case CHOICE.PRINT:
//                        Console.WriteLine("Enter 1 to print the list of lines and 2 to print the list of stations");
//                        do
//                        {
//                            select = int.Parse(Console.ReadLine());
//                        } while (select != 1 && select != 2);
//                        if (select == 1)
//                        {
//                            printLines();
//                        }
//                        if (select == 2)
//                        {
//                            printStations();
//                        }
//                        break;
//                    case CHOICE.EXIT:
//                        break;
//                    default:
//                        break;
//                }


//            } while (choice != CHOICE.EXIT);


//        }
//        private static void createStationsList(ref List<BusStop> listOfStations)
//        {
//            var linesFromTextNotepad = System.IO.File.ReadAllLines(@"C:\Users\Meir Bar Natan\source\repos\dotNet5781_9887_9517\dotNet5781_02_9887_9517\stationNames.txt");
//            for (int i = 0; i < 40; i++)
//            {
//                int stationNum;
//                double latitude;
//                double longitude;
//                //string location = " ";
//                bool check = false;
//                string location = linesFromTextNotepad[i];
//                do
//                {
//                    stationNum = r.Next(100000);
//                    latitude = r.NextDouble() * (33.3 - 31) + 31;
//                    longitude = r.NextDouble() * (35.5 - 34.3) + 34.3;
//              //      location = linesFromTextNotepad[i];
                    
//                    foreach (BusStop item in listOfStations)
//                    {
//                        if (item.StationNum == stationNum || item.Latitude == latitude || item.Longitude == longitude)
//                        {
//                            check = true;
//                        }
//                    }
//                } while (check);
//                BusStop newStop = new BusStop(stationNum, location, latitude, longitude);
//                listOfStations.Add(newStop);
//            }
//        }

//        private static void createLinesList(ref BusCompany lines, ref List<BusStop> listOfStations)
//        {
//            int countOfStations = 9;
//            int j = 0;
//            for (int i = 0; i < 10; i++)
//            {
//                List<LineStation> route = new List<LineStation>();
//                int numberLine = r.Next(100-1)+1;               
//                AREA area = (AREA)r.Next(5);

//                for (int k = 0; k < countOfStations; k++)
//                {
//                    double distance = r.NextDouble() * (1000 - 100) + 100;
//                    double time = r.NextDouble() * (15 - 5) + 5;
//                    LineStation newLineStation = new LineStation(listOfStations[j], distance, time);
//                    route.Add(newLineStation);
//                    j++;
//                }
//                j = j / 2;
//                LineBus newLine = new LineBus(route, numberLine, area);
//                try
//                {
//                    lines.addLine(newLine);
//                }
//                catch (ArgumentException exception)
//                {

//                    break; 
//                }
                
//                route[0].distance = 0;
//                route[0].time = 0;
//            }
       
//        }

//        private static void createRoute(ref List<LineStation> route, int count)
//        {
//            printStations();
//            for (int i = 0; i < count; i++)
//            {
//                Console.WriteLine("enter number of station from the list;");
//                int stationNum = int.Parse(Console.ReadLine());
//                double distance = r.NextDouble() * (1000 - 100) + 100;
//                double time = r.NextDouble() * (15 - 5) + 5;
//                foreach (BusStop item in listOfStations)
//                {
//                    if (item.StationNum == stationNum)
//                    {
//                        LineStation newStation = new LineStation(item, distance, time);
//                        route.Add(newStation);
//                        break;   
//                    }
//                }
//            }
//            route[0].distance = 0;
//            route[0].time = 0;

//        }

//        private static void printLines()
//        {
//            foreach (LineBus item in lines)
//            {
//                Console.WriteLine(item);
//            }
//        }

//        private static void printStations()
//        {
//            foreach (BusStop  item in listOfStations)
//            {
//                Console.WriteLine(item);
//            }
//        }


//    }
//}
