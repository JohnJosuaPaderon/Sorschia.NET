using Sorschia.Repository;

namespace Sorschia.Entity.Repository
{
    public interface IEntityRepository<T, TIdentifier> : IRepository<T>
        where T : IEntity<TIdentifier>
    {
        T Get(TIdentifier id);
    }
}
