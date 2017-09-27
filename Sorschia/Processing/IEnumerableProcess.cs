using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processing
{
    public interface IEnumerableProcess<T>
    {
        IEnumerableProcessResult<T> Execute();
        Task<IEnumerableProcessResult<T>> ExecuteAsync();
        Task<IEnumerableProcessResult<T>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
