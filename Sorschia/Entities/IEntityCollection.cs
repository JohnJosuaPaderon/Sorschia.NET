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
        
        T this[TIdentifier id] { get; set; }

        void AddUpdate(T item);
        void Update(T item);
    }
}
