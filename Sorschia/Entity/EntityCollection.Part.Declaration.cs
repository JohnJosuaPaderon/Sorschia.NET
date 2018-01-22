using System.Collections.Generic;

namespace Sorschia.Entity
{
    partial class EntityCollection<T, TIdentifier>
    {
        protected Dictionary<TIdentifier, T> Source { get; }
        public int Count => Source.Count;
        public bool IsReadOnly => false;

        public event EntityCollectionEventHandler<T, TIdentifier> Added;
        public event EntityCollectionEventHandler<T, TIdentifier> Removed;
        public event EntityCollectionEventHandler<T, TIdentifier> Updated;
        public event EntityCollectionEventHandler Cleared;
        public event EntityCollectionRangeEventHandler<T, TIdentifier> RangeAdded;
        public event EntityCollectionRangeEventHandler<T, TIdentifier> RangeRemoved;
        public event EntityCollectionRangeEventHandler<T, TIdentifier> RangeUpdated;
    }
}
