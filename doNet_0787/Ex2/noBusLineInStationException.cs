using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex2
{
    class noBusLineInStationException:Exception
    {
        public noBusLineInStationException() : base() { }

        override public string ToString()
        {
            string str = "ther is no bus line that goipn throw this station";
            return str;
        }

    }
}
