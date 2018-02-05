using System.Collections.Generic;

namespace Sorschia.Entity
{
    partial class EntityCollection<T, TIdentifier>
    {
        protected virtual void OnAdded(T item)
        {
            Added?.Invoke(this, new EntityCollectionEventArgs<T, TIdentifier>(EntityCollectionOperation.Add, item));
        }

        protected virtual void OnAdded(IEnumerable<T> items)
        {
            RangeAdded?.Invoke(this, new EntityCollectionRangeEventArgs<T, TIdentifier>(EntityCollectionOperation.Add, items));
        }

        protected virtual void OnCleared()
        {
            Cleared?.Invoke(this, new EntityCollectionEventArgs(EntityCollectionOperation.Clear));
        }

        protected virtual void OnRemoved(T item)
        {
            Removed?.Invoke(this, new EntityCollectionEventArgs<T, TIdentifier>(EntityCollectionOperation.Remove, item));
        }

        protected virtual void OnRemoved(IEnumerable<T> items)
        {
            RangeRemoved?.Invoke(this, new EntityCollectionRangeEventArgs<T, TIdentifier>(EntityCollectionOperation.Remove, items));
        }

        protected virtual void OnUpdated(T item)
        {
            Updated?.Invoke(this, new EntityCollectionEventArgs<T, TIdentifier>(EntityCollectionOperation.Update, item));
        }

        protected virtual void OnUpdated(IEnumerable<T> items)
        {
            RangeUpdated?.Invoke(this, new EntityCollectionRangeEventArgs<T, TIdentifier>(EntityCollectionOperation.Update, items));
        }
    }
}
