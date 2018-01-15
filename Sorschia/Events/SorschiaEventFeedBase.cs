using System;

namespace Sorschia.Events
{
    public abstract class SorschiaEventFeedBase
    {
        public SorschiaEventFeedBase()
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.Now;
        }

        public Guid Id { get; }
        public DateTime Timestamp { get; }
    }
}
