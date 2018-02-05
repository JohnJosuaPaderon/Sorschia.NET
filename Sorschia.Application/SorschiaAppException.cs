using System;

namespace Sorschia.Application
{
    public sealed class SorschiaAppException : Exception
    {
        public static SorschiaAppException InvalidSettingName()
        {
            return new SorschiaAppException(SorschiaAppExceptionKind.InvalidSettingName, "Application setting's name is invalid.");
        }

        public static SorschiaAppException InvalidSettingName(string message)
        {
            return new SorschiaAppException(SorschiaAppExceptionKind.InvalidSettingName, message);
        }

        public static SorschiaAppException BuildingError(Exception innerException)
        {
            return new SorschiaAppException(SorschiaAppExceptionKind.BuildingError, "An error occured during building application, see InnerException.", innerException);
        }

        public static SorschiaAppException FatalError(string message)
        {
            return new SorschiaAppException(SorschiaAppExceptionKind.FatalError, message);
        }

        public SorschiaAppException(SorschiaAppExceptionKind kind)
        {
            Kind = kind;
        }

        public SorschiaAppException(SorschiaAppExceptionKind kind, string message) : base(message)
        {
            Kind = kind;
        }

        public SorschiaAppException(SorschiaAppExceptionKind kind, string message, Exception innerException) : base(message, innerException)
        {
            Kind = kind;
        }

        public SorschiaAppExceptionKind Kind { get; }
    }
}
