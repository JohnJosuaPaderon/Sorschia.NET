using Sorschia.Processing;
using System;

namespace Sorschia.Entity.Manager
{
    public abstract class EntityManagerBase<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        public EntityManagerBase()
        {
            Source = new EntityCollection<T, TIdentifier>();
        }

        protected IEntityCollection<T, TIdentifier> Source { get; }

        protected IProcessResult<T> TryAdd(IProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Add(result.Data));
        }

        protected IEnumerableProcessResult<T> TryAdd(IEnumerableProcessResult<T> result)
        {
            return InvokeIfSuccess(result, () => Source.Add(result.DataCollection));
        }

        protected IProcessResult<T> TryAddUpdate(IProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.AddUpdate(result.Data));
        }

        protected IEnumerableProcessResult<T> TryAddUpdate(IEnumerableProcessResult<T> result)
        {
            return InvokeIfSuccess(result, () => Source.AddUpdate(result.DataCollection));
        }

        protected IProcessResult<T> TryRemove(IProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Remove(result.Data));
        }

        protected IEnumerableProcessResult<T> TryRemove(IEnumerableProcessResult<T> result)
        {
            return InvokeIfSuccess(result, () => Source.Remove(result.DataCollection));
        }

        protected IProcessResult<T> TryUpdate(IProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Update(result.Data));
        }

        protected IEnumerableProcessResult<T> TryUpdate(IEnumerableProcessResult<T> result)
        {
            return InvokeIfSuccess(result, () => Source.Update(result.DataCollection));
        }

        protected IProcessResult<T> TryInvoke(IProcessResult<T> result, Action callback)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                callback?.Invoke();
            }

            return result;
        }

        protected IEnumerableProcessResult<T> InvokeIfSuccess(IEnumerableProcessResult<T> result, Action callback)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                callback?.Invoke();
            }

            return result;
        }
    }
}
