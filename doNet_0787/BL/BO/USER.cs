using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class User
    {
        public int ID { get; set; }//id of user
        public string UserName { get; set; }//user name 
        public bool Admit { get; set; }//Management permission
    }
}
