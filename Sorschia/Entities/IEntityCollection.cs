using System.Collections.Generic;

namespace Sorschia.Entities
{
    public interface IEntityCollection<T, TIdentifier> : ICollection<T>
        where T : IEntity<TIdentifier>
    {
        event EntityCollectionEventHandler<T, TIdentifier> Added;
        event EntityCollectionEventHandler<T, TIdentifier> Removed;
        event EntityCollectionEventHandler<T, TIdentifier> Updated;
        event EntityCollectionEventHandler Cleared;
        event EntityCollectionRangeEventHandler<T, TIdentifier> RangeAdded;
        event EntityCollectionRangeEventHandler<T, TIdentifier> RangeRemoved;
        event EntityCollectionRangeEventHandler<T, TIdentifier> RangeUpdated;
        
        T this[TIdentifier id] { get; set; }

        void AddUpdate(T item);
        void Update(T item);
        void Add(IEnumerable<T> items);
        void Remove(IEnumerable<T> items);
        void Update(IEnumerable<T> items);
        void AddUpdate(IEnumerable<T> items);
    }
}
