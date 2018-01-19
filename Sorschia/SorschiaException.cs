using System;
using System.Runtime.Serialization;

namespace Sorschia
{
    [Serializable]
    public partial class SorschiaException : Exception
    {
        public static bool EnableReporting { get; set; }

        public SorschiaException(SorschiaExceptionType type)
        {
            Type = type;
        }

        public SorschiaException(string message, SorschiaExceptionType type) : base(message)
        {
            Type = type;
        }

        public SorschiaException(string message, Exception inner, SorschiaExceptionType type) : base(message, inner)
        {
            Type = type;
        }

        protected SorschiaException(SerializationInfo info, StreamingContext context, SorschiaExceptionType type) : base(info, context)
        {
            Type = type;
        }

        public SorschiaExceptionType Type { get; }
    }
}
