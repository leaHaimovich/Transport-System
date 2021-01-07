using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    
  
   //class Exception
  


        [Serializable]
        public class OlreadtExistExceptionBO : Exception
        {         
            public OlreadtExistExceptionBO() : base() { }
            public OlreadtExistExceptionBO(string message) : base(message) { }
            public OlreadtExistExceptionBO(string message, Exception inner) : base(message, inner) { }
            protected OlreadtExistExceptionBO(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
            // special constructor for our custom exception
            
            override public string ToString()
            {
                return "OlreadtExistException: " + Message;
            }
        }

    public class NotExistExceptionBO : Exception
    {
        public NotExistExceptionBO() : base() { }
        public NotExistExceptionBO(string message) : base(message) { }
        public NotExistExceptionBO(string message, Exception inner) : base(message, inner) { }
        protected NotExistExceptionBO(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
        // special constructor for our custom exception

        override public string ToString()
        {
            return "NotExistException:" + Message;
        }
    }
}


 

