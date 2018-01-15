using System;

namespace Sorschia.Events
{
    public interface ISorschiaEventFeed
    {
        Guid Id { get; }
        DateTime Timestamp { get; }
        object Data { get; }
    }
}
