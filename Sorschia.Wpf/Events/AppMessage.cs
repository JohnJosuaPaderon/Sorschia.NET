using System;

namespace Sorschia.Events
{
    public class AppMessage
    {
        public AppMessage(AppMessageType type, string message)
        {
            Type = type;
            Message = message;
            Exception = null;
        }

        public AppMessage(Exception exception)
        {
            Exception = exception ?? throw SorschiaException.ParameterRequired(nameof(exception));
            Type = AppMessageType.Exception;
            Message = "An exception has occured.";
        }

        public AppMessageType Type { get; }
        public Exception Exception { get; }
        public string Message { get; }
    }
}
