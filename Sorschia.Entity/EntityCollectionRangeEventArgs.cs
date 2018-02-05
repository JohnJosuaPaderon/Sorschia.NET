using System.Collections.Generic;

namespace Sorschia.Entity
{
    public class EntityCollectionRangeEventArgs<T, TIdentifier> : EntityCollectionEventArgs
        where T : IEntity<TIdentifier>
    {
        public EntityCollectionRangeEventArgs(EntityCollectionOperation operation, IEnumerable<T> dataCollection) : base(operation)
        {
            DataCollection = dataCollection;
        }

        public IEnumerable<T> DataCollection { get; }
    }
}
