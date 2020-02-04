using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CustomException
{
    class DivideBySelfException : Exception
    {
        public DivideBySelfException()
        {        
        }

        public DivideBySelfException(string message) : base(message)
        {
        }

        public DivideBySelfException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DivideBySelfException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
