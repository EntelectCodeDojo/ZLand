using System;
using System.Runtime.Serialization;

namespace ZLand.Actions
{
    public abstract class DisplayOnUIException: Exception
    {
        protected DisplayOnUIException()
        {
        }

        protected DisplayOnUIException(string message, Exception innerException) 
            : base(message, innerException)
        {
        }

        protected DisplayOnUIException(string message) 
            : base(message)
        {
        }

        protected DisplayOnUIException(SerializationInfo info, StreamingContext context) 
            : base(info, context)
        {
        }
    }
}