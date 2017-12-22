namespace Sorschia.Repository
{
    public interface IRepository
    {
        void TryInitialize();
        void Initialize();
    }
    
    public interface IRepository<T> : IRepository
    {
        void Add(T entity);
        bool Remove(T entity);
        void Update(T entity);
    }
}
