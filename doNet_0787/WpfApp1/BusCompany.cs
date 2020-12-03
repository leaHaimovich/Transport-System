using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    /// <summary>
    /// class for the implementation of a collection of bus lines
    /// </summary>
    public class BusCompany: IEnumerable
    {
        public List<LineBus> listOfBuses = new List<LineBus>();
        /// <summary>
        /// Add a line to the file
        /// </summary>
        /// <param name="newLine"></param>
        public void addLine(LineBus newLine)
        {
            LineBus temp = new LineBus();
            int count = countLineInList(newLine, ref temp);
            if (count == 2)
            {
                throw new ArgumentException("ERROR: bus exist in the list");
            }
            if (count == 0)
            {
                listOfBuses.Add(newLine);
            }
            if (count == 1)
            {
                if (newLine.compareBetweenStation(temp))
                {
                    listOfBuses.Add(newLine);

                }
                else
                {
                    throw new ArgumentException("ERROR: bus exist in the list");

                }
            }

        }

        /// <summary>
        /// Delete a line from the collection
        /// </summary>
        /// <param name="oldLine"></param>
        public void deleteLine(int oldLine)
        {
            if(!isBusExist(oldLine))
                throw new ArgumentException("ERROR: the bos not exsist in the list");
            foreach (LineBus item in listOfBuses)
            {
                if(item.numBus == oldLine)
                {
                    listOfBuses.Remove(item);
                    break;
                }
            }
            

        }
        /// <summary>
        /// A function that receives a station number and returns
        /// a list of lines passing through the station
        /// </summary>
        /// <param name="num"></Station number>
        /// <returns></Line list>
        public List<LineBus> linesInStation(int num)
        {
            List<LineBus> LinesInStation = new List<LineBus>();
            foreach (LineBus item in listOfBuses)
            {
                foreach (LineStation item1 in item.lineRoute)
                {
                    if (item1.StationNum == num)
                    {
                        LinesInStation.Add(item);
                    }
                }

            }
            if(LinesInStation.Count() == 0)
            {
                throw new ArgumentException("ERROR: no lines in station");
            }
            return LinesInStation;
        }

        /// <summary>
        /// A function that checks whether a line is in the collection
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public bool isBusExist(int num)
        {
            foreach (LineBus item in listOfBuses)
            {
                if (item.numBus == num)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Function for sorting a list by travel time
        /// </summary>
        /// <returns></returns>
        public List<LineBus> sortedListOfLines()
        {
            listOfBuses.Sort();
            return listOfBuses;
        }

        /// <summary>
        /// implementaion of indexer, Gets a line number
        /// and returns his show
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public LineBus this[int num]
        {
            get
            {
                foreach (LineBus item in listOfBuses)
                {
                    if (item.numBus == num)
                        return item;
                }
                throw new ArgumentException("ERROR: bus not exist");
            }
            set { }
        }
        /// <summary>
        /// The number of times a particular line is on the list
        /// </summary>
        /// <param name="bus"></param>
        /// <param name="temp"></param>
        /// <returns></returns>
        public int countLineInList(LineBus bus, ref LineBus temp)
        {
            int count = 0;
            foreach (LineBus item in listOfBuses)
            {
                if (item.numBus == bus.numBus)
                {
                    count++;
                    temp = item;
                }
            }

            return count;
        }

        /// <summary>
        /// implementaion iterator
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)listOfBuses).GetEnumerator();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
