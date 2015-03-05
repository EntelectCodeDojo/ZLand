using System;
using System.Runtime.Serialization;

namespace ZLand.Actions
{
    public class CantMoveException : DisplayOnUIException
    {
        public CantMoveException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public CantMoveException(string message) : base(message)
        {
        }

        public CantMoveException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}