using System.Collections.Generic;

namespace Sorschia.Entity.Manager
{
    partial class EntityManagerBase<T, TIdentifier>
    {
        protected virtual void OnAdded(T entity)
        {
            // TODO: 
        }

        protected virtual void OnAdded(IEnumerable<T> entities)
        {
            // TODO:
        }

        protected virtual void OnUpdated(T entity)
        {
            // TODO:
        }

        protected virtual void OnUpdated(IEnumerable<T> entities)
        {
            // TODO:
        }

        protected virtual void OnDeleted(T entity)
        {
            // TODO:
        }

        protected virtual void OnDeleted(IEnumerable<T> entities)
        {
            // TODO:
        }
    }
}
