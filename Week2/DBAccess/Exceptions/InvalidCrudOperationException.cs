using System;
using System.Runtime.Serialization;

namespace DBAccess.Exceptions
{
    [Serializable]
    internal class InvalidCrudOperationException : Exception
    {
        public InvalidCrudOperationException()
        {
        }

        public InvalidCrudOperationException(string message) : base(message)
        {
        }

        public InvalidCrudOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidCrudOperationException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}