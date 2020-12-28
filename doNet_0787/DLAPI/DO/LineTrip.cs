using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
   public  class LineTrip
    {
        public int ID { get; set; }//id
        public int LineID { get; set; }//id of line
        public TimeSpan StartAt { get; set; }//Start Time
        public TimeSpan FinishAt { get; set; }//finish Time
        public TimeSpan Frequency { get; set; }//frequency

    }
}
