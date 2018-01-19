using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sorschia.Events
{
    public sealed class SorschiaEventFeedList<TFeed> : ISorschiaEventFeedEnumerable<TFeed>
        where TFeed : ISorschiaEventFeed
    {
        internal SorschiaEventFeedList()
        {
            _Source = new Dictionary<Guid, TFeed>();
        }

        private readonly Dictionary<Guid, TFeed> _Source;

        public TFeed this[Guid id]
        {
            get
            {
                if (id != default(Guid) && _Source.ContainsKey(id))
                {
                    return _Source[id];
                }
                else
                {
                    return default(TFeed);
                }
            }
        }

        public IEnumerable<TFeed> this[DateTime timestamp]
        {
            get
            {
                if (timestamp != default(DateTime))
                {
                    return _Source.Values.Where(f => f.Timestamp == timestamp);
                }
                else
                {
                    return null;
                }
            }
        }

        public IEnumerable<TFeed> this[DateTime begin, DateTime end]
        {
            get
            {
                if (begin != default(DateTime) && end != default(DateTime))
                {
                    return _Source.Values.Where(f => f.Timestamp >= begin && f.Timestamp <= end);
                }
                else
                {
                    return null;
                }
            }
        }

        public void Add(TFeed feed)
        {
            if (feed != null && !_Source.ContainsKey(feed.Id))
            {
                _Source.Add(feed.Id, feed);
            }
        }

        public IEnumerator<TFeed> GetEnumerator()
        {
            return _Source.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
