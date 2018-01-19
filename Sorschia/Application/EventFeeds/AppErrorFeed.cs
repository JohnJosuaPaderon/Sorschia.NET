using Sorschia.Events;
using System;

namespace Sorschia.Application.EventFeeds
{
    public sealed class AppErrorFeed : SorschiaEventFeedBase, ISorschiaEventFeed
    {
        public AppErrorFeed(Exception exception)
        {
            Exception = exception;
            Message = "An exception has been thrown.";
        }

        public AppErrorFeed(string message)
        {
            Exception = null;
            Message = message;
        }

        public AppErrorFeed(Exception exception, string message)
        {
            Exception = exception;
            Message = message;
        }

        public Exception Exception { get; }
        public string Message { get; }
    }
}
