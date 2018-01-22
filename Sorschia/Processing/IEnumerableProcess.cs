using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processing
{
    public interface IEnumerableProcess<T> : IDisposable
    {
        IEnumerableProcessResult<T> Execute(IProcessContext context);
        Task<IEnumerableProcessResult<T>> ExecuteAsync(IProcessContext context);
        Task<IEnumerableProcessResult<T>> ExecuteAsync(IProcessContext context, CancellationToken cancellationToken);
    }
}
