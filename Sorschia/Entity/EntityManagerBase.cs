using Sorschia.Processing;
using System;

namespace Sorschia.Entity
{
    public abstract class EntityManagerBase<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        static EntityManagerBase()
        {
            StaticSource = new EntityCollection<T, TIdentifier>();
        }

        protected static IEntityCollection<T, TIdentifier> StaticSource { get; }

        protected IProcessResult<T> AddIfSuccess(IProcessResult<T> result)
        {
            return InvokeIfSuccess(result, () => StaticSource.Add(result.Data));
        }

        protected IEnumerableProcessResult<T> AddIfSuccess(IEnumerableProcessResult<T> result)
        {
            return InvokeIfSuccess(result, () => StaticSource.Add(result.DataCollection));
        }

        protected IProcessResult<T> AddUpdateIfSuccess(IProcessResult<T> result)
        {
            return InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.Data));
        }

        protected IEnumerableProcessResult<T> AddUpdateIfSuccess(IEnumerableProcessResult<T> result)
        {
            return InvokeIfSuccess(result, () => StaticSource.AddUpdate(result.DataCollection));
        }

        protected IProcessResult<T> RemoveIfSuccess(IProcessResult<T> result)
        {
            return InvokeIfSuccess(result, () => StaticSource.Remove(result.Data));
        }

        protected IEnumerableProcessResult<T> RemoveIfSuccess(IEnumerableProcessResult<T> result)
        {
            return InvokeIfSuccess(result, () => StaticSource.Remove(result.DataCollection));
        }

        protected IProcessResult<T> UpdateIfSuccess(IProcessResult<T> result)
        {
            return InvokeIfSuccess(result, () => StaticSource.Update(result.Data));
        }

        protected IEnumerableProcessResult<T> UpdateIfSuccess(IEnumerableProcessResult<T> result)
        {
            return InvokeIfSuccess(result, () => StaticSource.Update(result.DataCollection));
        }

        protected IProcessResult<T> InvokeIfSuccess(IProcessResult<T> result, Action expression)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                expression?.Invoke();
            }

            return result;
        }

        protected IEnumerableProcessResult<T> InvokeIfSuccess(IEnumerableProcessResult<T> result, Action expression)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                expression?.Invoke();
            }

            return result;
        }
    }
}
