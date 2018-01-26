using System;

namespace Sorschia.Events
{
    public class AppMessage
    {
        public AppMessage(AppMessageType type, string content)
        {
            Type = type;
            Content = content;
            Exception = null;
        }

        public AppMessage(Exception exception)
        {
            Exception = exception ?? throw SorschiaException.ParameterRequired(nameof(exception));
            Type = AppMessageType.Exception;
            Content = "An exception has occured.";
        }

        public AppMessageType Type { get; }
        public Exception Exception { get; }
        public string Content { get; }
    }
}
