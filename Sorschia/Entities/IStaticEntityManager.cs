using Sorschia.Processes;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Entities
{
    public interface IStaticEntityManager<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        IProcessResult<T> GetById(TIdentifier id);
        Task<IProcessResult<T>> GetByIdAsync(TIdentifier id);
        Task<IProcessResult<T>> GetByIdAsync(TIdentifier id, CancellationToken cancellationToken);
        IEnumerableProcessResult<T> GetList();
        Task<IEnumerableProcessResult<T>> GetListAsync();
        Task<IEnumerableProcessResult<T>> GetListAsync(CancellationToken cancellationToken);
    }
}
