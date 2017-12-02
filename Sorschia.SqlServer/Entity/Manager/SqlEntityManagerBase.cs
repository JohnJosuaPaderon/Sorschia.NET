using Sorschia.Entities;
using Sorschia.Processing;

namespace Sorschia.Entity.Manager
{
    public abstract class SqlEntityManagerBase<T, TIdentifier> : EntityManagerBase<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        public SqlEntityManagerBase(IProcessContextFactory contextFactory, string connectionStringKey)
        {
            _ContextFactory = contextFactory;
            ConnectionStringKey = connectionStringKey;
        }

        private readonly IProcessContextFactory _ContextFactory;

        protected IProcessContext GenerateContext()
        {
            var context = _ContextFactory.Generate();

            if (context is DbProcessContext dbProcessContext)
            {
                dbProcessContext.ConnectionStringKey = ConnectionStringKey;
                return context; 
            }
            else
            {
                throw SorschiaException.InvalidOperation($"Type of '{typeof(DbProcessContext).FullName}' is expected.");
            }
        }

        private readonly string ConnectionStringKey;
    }
}
