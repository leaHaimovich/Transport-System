using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BO.Emuns;

namespace BO
{
    public class LINE
    {
        public int Code { get; set; }        
        public AREA Area { get; set; }// area of line activitis
        public TimeSpan StartAt { get; set; }
        public TimeSpan FinishAt { get; set; }
        public TimeSpan Frequency { get; set; }//frequency

        public IEnumerable<STATIONLINE> StationListOfLine { get; set; }//רשימת התחנות שהקו עובר בהם

        public override string ToString()
        {
            string str = Code + "   " + Area + " ";
            return str ;
        }

    }
}
