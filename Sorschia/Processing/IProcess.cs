using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processing
{
    public interface IProcess
    {
        IProcessResult Execute(IProcessContext context);
        Task<IProcessResult> ExecuteAsync(IProcessContext context);
        Task<IProcessResult> ExecuteAsync(IProcessContext context, CancellationToken cancellationToken);
    }

    public interface IProcess<T>
    {
        IProcessResult<T> Execute(IProcessContext context);
        Task<IProcessResult<T>> ExecuteAsync(IProcessContext context);
        Task<IProcessResult<T>> ExecuteAsync(IProcessContext context, CancellationToken cancellationToken);
    }
}
