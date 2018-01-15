using System.Collections.Generic;

namespace Sorschia.Events
{
    public interface ISorschiaEventManager
    {
        ISorschiaEvent<TFeed> GetEvent<TFeed>() where TFeed : ISorschiaEventFeed;
        void Subscribe<TFeed>(ISorschiaEvent<TFeed> sorschiaEvent, ISorschiaEventSubscriber<TFeed> subscriber) where TFeed : ISorschiaEventFeed;
        void Unsubscribe<TFeed>(ISorschiaEvent<TFeed> sorschiaEvent, ISorschiaEventSubscriber<TFeed> subscriber) where TFeed : ISorschiaEventFeed;
        IEnumerable<ISorschiaEventSubscriber<TFeed>> GetSubscribers<TFeed>() where TFeed : ISorschiaEventFeed;
    }
}
