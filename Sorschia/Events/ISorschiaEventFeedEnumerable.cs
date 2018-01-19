using System;
using System.Collections.Generic;

namespace Sorschia.Events
{
    public interface ISorschiaEventFeedEnumerable<T> : IEnumerable<T>
        where T : ISorschiaEventFeed
    {
        T this[Guid id] { get; }
        IEnumerable<T> this[DateTime timestamp] { get; }
        IEnumerable<T> this[DateTime begin, DateTime end] { get; }
    }
}
