using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    class Trip
    {
        public int ID { get; set; }//id of line
        public string UserName { get; set; }//user name 
        public int LineID { get; set; }//id of line
        public int InStation { get; set; }//Boarding station
        public TimeSpan InAt { get; set; }//time of boarding
        public int OutStation { get; set; }//Drop station
        public TimeSpan outAt { get; set; }//time of Drop 
    }
}
