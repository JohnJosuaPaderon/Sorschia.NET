using System;
using System.Collections;
using System.Collections.Generic;

namespace Sorschia.Events
{
    internal class SorschiaEventFeedList<TFeed> : ISorschiaEventFeedEnumerable<TFeed>
        where TFeed : ISorschiaEventFeed
    {
        public SorschiaEventFeedList()
        {
            _Source = new Dictionary<Guid, TFeed>();
        }

        private readonly Dictionary<Guid, TFeed> _Source;

        public TFeed this[Guid id]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ISorschiaEventFeedEnumerable<TFeed> this[DateTime timestamp]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public ISorschiaEventFeedEnumerable<TFeed> this[DateTime begin, DateTime end]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Add(TFeed feed)
        {
            throw new NotImplementedException();
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
