using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes
{
    public interface IProcess
    {
        IProcessResult Execute();
        Task<IProcessResult> ExecuteAsync();
        Task<IProcessResult> ExecuteAsync(CancellationToken cancellationToken);
    }

    public interface IProcess<T>
    {
        IProcessResult<T> Execute();
        Task<IProcessResult<T>> ExecuteAsync();
        Task<IProcessResult<T>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
