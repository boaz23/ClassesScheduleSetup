using System;
using System.Runtime.Serialization;

namespace ClassesScheduleSetup
{
    public class InvalidScheduleException : Exception
    {
        public InvalidScheduleException() : base() { }
        public InvalidScheduleException(string? message) : base(message) { }
        public InvalidScheduleException(string? message, Exception? innerException) : base(message, innerException) { }
        protected InvalidScheduleException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
