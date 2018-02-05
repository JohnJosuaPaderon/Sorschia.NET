using Sorschia.Processing;

namespace Sorschia.Entity.Manager
{
    partial class EntityManagerBase<T, TIdentifier>
    {
        protected IProcessResult<T> TryUpdate(IProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Update(result.Data));
        }

        protected IEnumerableProcessResult<T> TryUpdate(IEnumerableProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Update(result.DataCollection));
        }

        protected IAggregateProcessResult<T> TryUpdate(IAggregateProcessResult<T> result)
        {
            return TryInvoke(result, entity => Source.Update(entity));
        }
    }
}
