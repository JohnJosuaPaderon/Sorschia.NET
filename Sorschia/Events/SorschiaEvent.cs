using System;
using System.Linq;

namespace Sorschia.Events
{
    public sealed class SorschiaEvent<TFeed> : ISorschiaEvent<TFeed>
        where TFeed : ISorschiaEventFeed
    {
        internal SorschiaEvent(ISorschiaEventManager manager)
        {
            _Manager = manager;
            _Feeds = new SorschiaEventFeedList<TFeed>();
        }

        private readonly ISorschiaEventManager _Manager;
        private readonly SorschiaEventFeedList<TFeed> _Feeds;

        public ISorschiaEventFeedEnumerable<TFeed> Feeds => _Feeds;
        public TFeed LastFeed { get; private set; }

        public void Raise(TFeed feed)
        {
            Validate(feed);

            var subscribers = _Manager.GetSubscribers<TFeed>();

            if (subscribers != null && subscribers.Any())
            {
                foreach (var subscriber in subscribers)
                {
                    subscriber.CaptureEventFeed(this, feed);
                }
            }

            _Feeds.Add(feed);
            LastFeed = feed;
        }

        private void Validate(TFeed feed)
        {
            if (feed == null)
            {
                throw SorschiaException.ParameterRequired(nameof(feed));
            }
            else if (feed.Id == Guid.Empty)
            {
                throw SorschiaException.ParameterRequired(nameof(feed), "Feed has invalid unique identifier.");
            }
        }
    }
}
