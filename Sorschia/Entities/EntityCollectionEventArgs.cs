using System;

namespace Sorschia.Entities
{
    public class EntityCollectionEventArgs : EventArgs
    {
        public EntityCollectionEventArgs(EntityCollectionOperation operation)
        {
            Operation = operation;
        }

        public EntityCollectionOperation Operation { get; }
    }

    public class EntityCollectionEventArgs<T, TIdentifier> : EntityCollectionEventArgs
        where T : IEntity<TIdentifier>
    {
        public EntityCollectionEventArgs(EntityCollectionOperation operation) : base(operation)
        {
        }

        public EntityCollectionEventArgs(EntityCollectionOperation operation, T data) : base(operation)
        {
            Data = data;
        }

        public T Data { get; }
    }
}
