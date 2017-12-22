using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Repository
{
    public interface IAsyncRepository<T> : IRepository
    {
        Task AddAsync(T entity);
        Task AddAsync(T entity, CancellationToken cancellationToken);
        Task<bool> RemoveAsync(T entity);
        Task<bool> RemoveAsync(T entity, CancellationToken cancellationToken);
        Task UpdateAsync(T entity);
        Task UpdateAsync(T entity, CancellationToken cancellationToken);
    }
}
