using Sorschia.Processing;

namespace Sorschia.Entity.Manager
{
    partial class EntityManagerBase<T, TIdentifier>
    {
        protected IProcessResult<T> TryAddUpdate(IProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.AddUpdate(result.Data));
        }

        protected IEnumerableProcessResult<T> TryAddUpdate(IEnumerableProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.AddUpdate(result.DataCollection));
        }

        protected IAggregateProcessResult<T> TryAddUpdate(IAggregateProcessResult<T> result)
        {
            return TryInvoke(result, entity => Source.AddUpdate(entity));
        }
    }
}
