using System;

namespace Sorschia
{
    [Serializable]
    public sealed class SorschiaException : Exception
    {
        internal SorschiaException(SorschiaExceptionType type = SorschiaExceptionType.Unknown)
        {
            Type = type;
        }

        internal SorschiaException(string message, SorschiaExceptionType type = SorschiaExceptionType.Unknown) : base(message)
        {
            Type = type;
        }

        internal SorschiaException(string message, Exception innerException, SorschiaExceptionType type = SorschiaExceptionType.Unknown) : base(message, innerException)
        {
            Type = type;
        }

        public SorschiaExceptionType Type { get; }
    }
}
