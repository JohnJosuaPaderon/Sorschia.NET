using Sorschia.Processing;
using System;

namespace Sorschia.Entity.Manager
{
    partial class EntityManagerBase<T, TIdentifier>
    {
        protected IProcessResult<T> TryInvoke(IProcessResult<T> result, Action callback)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                callback?.Invoke();
            }

            return result;
        }

        protected IEnumerableProcessResult<T> TryInvoke(IEnumerableProcessResult<T> result, Action callback)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                callback?.Invoke();
            }

            return result;
        }

        protected IAggregateProcessResult<T> TryInvoke(IAggregateProcessResult<T> aggregateResult, Action<T> callback)
        {
            foreach (var result in aggregateResult.Results)
            {
                if (result.Status == ProcessResultStatus.Success)
                {
                    callback?.Invoke(result.Data);
                }
            }

            return aggregateResult;
        }
    }
}
