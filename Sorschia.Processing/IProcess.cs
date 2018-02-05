using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processing
{
    public interface IProcess : IDisposable
    {
        IProcessResult Execute(IProcessContext context);
        Task<IProcessResult> ExecuteAsync(IProcessContext context);
        Task<IProcessResult> ExecuteAsync(IProcessContext context, CancellationToken cancellationToken);
    }

    public interface IProcess<T> : IDisposable
    {
        IProcessResult<T> Execute(IProcessContext context);
        Task<IProcessResult<T>> ExecuteAsync(IProcessContext context);
        Task<IProcessResult<T>> ExecuteAsync(IProcessContext context, CancellationToken cancellationToken);
    }
}
