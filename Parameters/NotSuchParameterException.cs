using System;
using System.Runtime.Serialization;

namespace SpectrumVisor.Parameters
{
    [Serializable]
    internal class NotSuchParameterException : Exception
    {
        public NotSuchParameterException()
        {
        }

        public NotSuchParameterException(string message) : base(message)
        {
        }

        public NotSuchParameterException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotSuchParameterException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}