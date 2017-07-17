using Sorschia.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public interface IDataManager<T>
    {
        IProcessResult<T> Insert(T data);
        Task<IProcessResult<T>> InsertAsync(T data);
        Task<IProcessResult<T>> InsertAsync(T data, CancellationToken cancellationToken);
        IProcessResult<T> Update(T data);
        Task<IProcessResult<T>> UpdateAsync(T data);
        Task<IProcessResult<T>> UpdateAsync(T data, CancellationToken cancellationToken);
        IProcessResult<T> Delete(T data);
        Task<IProcessResult<T>> DeleteAsync(T data);
        Task<IProcessResult<T>> DeleteAsync(T data, CancellationToken cancellationToken);
        IEnumerableProcessResult<T> GetList();
        Task<IEnumerableProcessResult<T>> GetListAsync();
        Task<IEnumerableProcessResult<T>> GetListAsync(CancellationToken cancellationToken);
    }
}
