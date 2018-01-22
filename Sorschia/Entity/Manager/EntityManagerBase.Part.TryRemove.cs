using Sorschia.Processing;

namespace Sorschia.Entity.Manager
{
    partial class EntityManagerBase<T, TIdentifier>
    {
        protected IProcessResult<T> TryRemove(IProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Remove(result.Data));
        }

        protected IEnumerableProcessResult<T> TryRemove(IEnumerableProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Remove(result.DataCollection));
        }

        protected IAggregateProcessResult<T> TryRemove(IAggregateProcessResult<T> result)
        {
            return TryInvoke(result, entity => Source.Remove(entity));
        }
    }
}
