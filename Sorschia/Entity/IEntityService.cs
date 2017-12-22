using Sorschia.Data;
using Sorschia.Processing;

namespace Sorschia.Entity
{
    public interface IEntityService<T> : IDataService
    {
        IProcessResult<T> Insert(T entity);
        IProcessResult<T> Delete(T entity);
        IProcessResult<T> Update(T entity);
    }

    public interface IEntityService<T, TIdentifier> : IEntityService<T>
        where T : IEntity<TIdentifier>
    {
        IProcessResult<T> Get(TIdentifier id);
    }
}
