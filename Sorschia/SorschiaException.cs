using System;

namespace Sorschia
{
    [Serializable]
    public sealed class SorschiaException : Exception
    {
        public SorschiaException(SorschiaExceptionType type = SorschiaExceptionType.Undefined)
        {
            Type = type;
        }

        public SorschiaException(string message, SorschiaExceptionType type = SorschiaExceptionType.Undefined) : base(message)
        {
            Type = type;
        }

        public SorschiaException(string message, Exception innerException, SorschiaExceptionType type = SorschiaExceptionType.Undefined) : base(message, innerException)
        {
            Type = type;
        }

        public SorschiaExceptionType Type { get; }
    }
}
