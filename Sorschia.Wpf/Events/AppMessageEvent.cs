using System;

namespace Sorschia.Events
{
    public sealed class AppMessageEvent : SorschiaPubSubEventBase<AppMessage>
    {
        private bool ValidateMessage(string message)
        {
            return !string.IsNullOrWhiteSpace(message);
        }

        public void Unknown(string message)
        {
            if (ValidateMessage(message))
            {
                Raise(new AppMessage(AppMessageType.NotSet, message));
            }
        }

        public void Error(string message)
        {
            if (ValidateMessage(message))
            {
                Raise(new AppMessage(AppMessageType.Error, message));
            }
        }

        public void Information(string message)
        {
            if (ValidateMessage(message))
            {
                Raise(new AppMessage(AppMessageType.Information, message));
            }
        }

        public void Exception(Exception exception)
        {
            if (exception != null)
            {
                Raise(new AppMessage(exception));
            }
        }

        public void Warning(string message)
        {
            if (ValidateMessage(message))
            {
                Raise(new AppMessage(AppMessageType.Warning, message));
            }
        }
    }
}
