using System;

namespace Sorschia
{
    [Serializable]
    public sealed class SorschiaException : Exception
    {
        public SorschiaException(SorschiaExceptionKind type = SorschiaExceptionKind.Undefined)
        {
            Type = type;
        }

        public SorschiaException(string message, SorschiaExceptionKind type = SorschiaExceptionKind.Undefined) : base(message)
        {
            Type = type;
        }

        public SorschiaException(string message, Exception innerException, SorschiaExceptionKind type = SorschiaExceptionKind.Undefined) : base(message, innerException)
        {
            Type = type;
        }

        public SorschiaExceptionKind Type { get; }
    }
}
