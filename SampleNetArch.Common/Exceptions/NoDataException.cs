using System.Runtime.Serialization;

namespace SampleNetArch.Common.Exceptions
{
    [Serializable]
    public class NoDataException : Exception
    {
        public NoDataException(string message) : base(message) { }

        public NoDataException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        // Without this constructor, deserialization will fail
        protected NoDataException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
