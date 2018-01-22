using Sorschia.Processing;

namespace Sorschia.Entity.Manager
{
    partial class EntityManagerBase<T, TIdentifier>
    {
        protected IProcessResult<T> TryAdd(IProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Add(result.Data));
        }

        protected IAggregateProcessResult<T> TryAdd(IAggregateProcessResult<T> result)
        {
            return TryInvoke(result, entity => Source.Add(entity));
        }

        protected IEnumerableProcessResult<T> TryAdd(IEnumerableProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Add(result.DataCollection));
        }
    }
}
