using System;
using System.Runtime.Serialization;

namespace ZLand.Actions
{
    public class NotEnoughActionPointsException : DisplayOnUIException
    {
        public NotEnoughActionPointsException(int currentActionPoints, int pointsToSpend)
            : base(string.Format("Unable to spend {0} points as you only have {1} points to spend", currentActionPoints, pointsToSpend))
        {
        }

        public NotEnoughActionPointsException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public NotEnoughActionPointsException(string message) : base(message)
        {
        }

        public NotEnoughActionPointsException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}