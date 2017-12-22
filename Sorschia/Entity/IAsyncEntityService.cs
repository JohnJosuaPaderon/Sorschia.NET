using Sorschia.Data;
using Sorschia.Processing;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Entity
{
    public interface IAsyncEntityService<T> : IDataService
    {
        Task<IProcessResult<T>> InsertAsync(T entity);
        Task<IProcessResult<T>> InsertAsync(T entity, CancellationToken cancellationToken);
        Task<IProcessResult<T>> DeleteAsync(T entity);
        Task<IProcessResult<T>> DeleteAsync(T entity, CancellationToken cancellationToken);
        Task<IProcessResult<T>> UpdateAsync(T entity);
        Task<IProcessResult<T>> UpdateAsync(T entity, CancellationToken cancellationToken);
    }

    public interface IAsyncEntityService<T, TIdentifier> : IAsyncEntityService<T>
        where T : IEntity<TIdentifier>
    {
        Task<IProcessResult<T>> GetAsync(TIdentifier id);
        Task<IProcessResult<T>> GetAsync(TIdentifier id, CancellationToken cancellationToken);
    }
}
