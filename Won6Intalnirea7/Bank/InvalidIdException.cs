using System;
using System.Runtime.Serialization;

namespace Won6Intalnirea7.Bank
{
    [Serializable]
    internal class InvalidIdException : Exception
    {
        public InvalidIdException()
        {
        }

        public InvalidIdException(string message) : base(message)
        {
        }

        public InvalidIdException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidIdException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}