using System;

namespace Sorschia
{
    [Serializable]
    public sealed class SorschiaException : Exception
    {
        public SorschiaException(SorschiaExceptionKind kind = SorschiaExceptionKind.Undefined)
        {
            Kind = kind;
        }

        public SorschiaException(string message, SorschiaExceptionKind kind = SorschiaExceptionKind.Undefined) : base(message)
        {
            Kind = kind;
        }

        public SorschiaException(string message, Exception innerException, SorschiaExceptionKind kind = SorschiaExceptionKind.Undefined) : base(message, innerException)
        {
            Kind = kind;
        }

        public SorschiaExceptionKind Kind { get; }
    }
}
