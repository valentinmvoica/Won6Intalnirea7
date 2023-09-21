using System;
using System.Runtime.Serialization;

namespace Won6Intalnirea7.Bank
{
    [Serializable]
    internal class InvalidSumException : Exception
    {
        public InvalidSumException()
        {
        }

        public InvalidSumException(string message) : base(message)
        {
        }

        public InvalidSumException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidSumException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}