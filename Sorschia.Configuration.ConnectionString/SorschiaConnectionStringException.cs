using System;

namespace Sorschia.Configuration
{
    public sealed class SorschiaConnectionStringException : Exception
    {
        public static SorschiaConnectionStringException InvalidKey()
        {
            return new SorschiaConnectionStringException(SorschiaConnectionStringExceptionKind.ParseError, "The supplied key of connection string is invalid.");
        }

        public static SorschiaConnectionStringException InvalidValue()
        {
            return new SorschiaConnectionStringException(SorschiaConnectionStringExceptionKind.ParseError, "The supplied value of connection string is invalid.");
        }

        public static SorschiaConnectionStringException Invalid()
        {
            return new SorschiaConnectionStringException(SorschiaConnectionStringExceptionKind.ParseError, "Connection string is invalid.");
        }

        public static SorschiaConnectionStringException EmptySource()
        {
            return new SorschiaConnectionStringException(SorschiaConnectionStringExceptionKind.ParseError, "Source of connection string is empty.");
        }

        public static SorschiaConnectionStringException ParseError()
        {
            return new SorschiaConnectionStringException(SorschiaConnectionStringExceptionKind.ParseError, "Failed to parse string to json.");
        }

        public SorschiaConnectionStringException(SorschiaConnectionStringExceptionKind kind)
        {
            Kind = kind;
        }

        public SorschiaConnectionStringException(SorschiaConnectionStringExceptionKind kind, string message) : base(message)
        {
            Kind = kind;
        }

        public SorschiaConnectionStringException(SorschiaConnectionStringExceptionKind kind, string message, Exception innerException) : base(message, innerException)
        {
            Kind = kind;
        }

        public SorschiaConnectionStringExceptionKind Kind { get; }
    }
}
