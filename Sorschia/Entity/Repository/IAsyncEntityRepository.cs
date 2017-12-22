using Sorschia.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Entity.Repository
{
    public interface IAsyncEntityRepository<T, TIdentifier> : IAsyncRepository<T>
        where T : IEntity<TIdentifier>
    {
        Task<T> GetAsync(TIdentifier id);
        Task<T> GetAsync(TIdentifier id, CancellationToken cancellationToken);
    }
}
