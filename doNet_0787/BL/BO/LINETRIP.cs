using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class LINETRIP
    {
        public int LineTripID { get; set; }//Line Trip ID מספר רץ
         public int LineID { get; set; }
        public TimeSpan StartAt { get; set; }
    }
}
