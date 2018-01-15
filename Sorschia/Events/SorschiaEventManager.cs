using System;
using System.Collections.Generic;

namespace Sorschia.Events
{
    public class SorschiaEventManager : ISorschiaEventManager
    {
        public SorschiaEventManager()
        {
            _EventSubscribers = new Dictionary<Type, List<object>>();
            _Events = new Dictionary<Type, object>();
        }

        private readonly Dictionary<Type, List<object>> _EventSubscribers;
        private readonly Dictionary<Type, object> _Events;

        private Type GetKeyType<TFeed>()
            where TFeed : ISorschiaEventFeed
        {
            return typeof(ISorschiaEvent<TFeed>);
        }

        public void Subscribe<TFeed>(ISorschiaEvent<TFeed> sorschiaEvent, ISorschiaEventSubscriber<TFeed> subscriber)
            where TFeed : ISorschiaEventFeed
        {
            var subscribers = TryInitializeSubscribers<TFeed>();

            if (!subscribers.Contains(subscriber))
            {
                subscribers.Add(subscriber);
            }
        }

        public void Unsubscribe<TFeed>(ISorschiaEvent<TFeed> sorschiaEvent, ISorschiaEventSubscriber<TFeed> subscriber)
            where TFeed : ISorschiaEventFeed
        {
            var subscribers = TryInitializeSubscribers<TFeed>();

            if (subscribers.Contains(subscriber))
            {
                subscribers.Remove(subscriber);
            }
        }

        private List<object> TryInitializeSubscribers<TFeed>()
            where TFeed : ISorschiaEventFeed
        {
            var type = GetKeyType<TFeed>();
            if (!_EventSubscribers.ContainsKey(type))
            {
                _EventSubscribers[type] = new List<object>();
            }

            return _EventSubscribers[type];
        }

        public IEnumerable<ISorschiaEventSubscriber<TFeed>> GetSubscribers<TFeed>() where TFeed : ISorschiaEventFeed
        {
            var type = GetKeyType<TFeed>();
            if (_EventSubscribers.ContainsKey(type))
            {
                var subscribers = _EventSubscribers[type];
                var list = new List<ISorschiaEventSubscriber<TFeed>>();

                foreach (var subscriber in subscribers)
                {
                    if (subscriber is ISorschiaEventSubscriber<TFeed> verifiedSubscriber)
                    {
                        list.Add(verifiedSubscriber);
                    }
                }

                return list;
            }
            else
            {
                return null;
            }
        }

        public ISorschiaEvent<TFeed> GetEvent<TFeed>() where TFeed : ISorschiaEventFeed
        {
            var type = GetKeyType<TFeed>();

            if (_Events.ContainsKey(type) && _Events[type] is ISorschiaEvent<TFeed> sorschiaEvent)
            {
                return sorschiaEvent;
            }
            else
            {
                var instance = new SorschiaEvent<TFeed>(this);
                _Events.Add(type, instance);
                return instance;
            }
        }
    }
}
