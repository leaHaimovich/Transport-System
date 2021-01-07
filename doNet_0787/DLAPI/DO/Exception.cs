using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    //class Exception
  


        [Serializable]
        public class OlreadtExistException : Exception
        {         
            public OlreadtExistException() : base() { }
            public OlreadtExistException(string message) : base(message) { }
            public OlreadtExistException(string message, Exception inner) : base(message, inner) { }
            protected OlreadtExistException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }
            // special constructor for our custom exception
            
            override public string ToString()
            {
                return "OlreadtExistException: " + Message;
            }
        }

    public class NotExistException : Exception
    {
        public NotExistException() : base() { }
        public NotExistException(string message) : base(message) { }
        public NotExistException(string message, Exception inner) : base(message, inner) { }
        protected NotExistException(SerializationInfo info, StreamingContext context)
        : base(info, context) { }
        // special constructor for our custom exception

        override public string ToString()
        {
            return "NotExistException:" + Message;
        }
    }
}

