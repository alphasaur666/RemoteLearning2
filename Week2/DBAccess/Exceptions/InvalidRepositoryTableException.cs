using System;
using System.Runtime.Serialization;

namespace DBAccess.Exceptions
{
    [Serializable]
    internal class InvalidRepositoryTableException : Exception
    {
        public InvalidRepositoryTableException()
        {
        }

        public InvalidRepositoryTableException(string message) : base(message)
        {
        }

        public InvalidRepositoryTableException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidRepositoryTableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}