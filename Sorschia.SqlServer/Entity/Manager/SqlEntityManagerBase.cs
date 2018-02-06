using Sorschia.Data.Processing;
using Sorschia.Events;
using Sorschia.Processing;
using System.Security;

namespace Sorschia.Entity.Manager
{
    public abstract class SqlEntityManagerBase<T, TIdentifier> : EntityManagerBase<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        public SqlEntityManagerBase(ISorschiaEventManager eventManager, IProcessContextFactory contextFactory, SecureString secureConnectionString = null) : base(eventManager)
        {
            _ContextFactory = contextFactory;
            _SecureConnectionString = secureConnectionString ?? throw SorschiaException.ParameterRequired(nameof(secureConnectionString));
        }

        private readonly IProcessContextFactory _ContextFactory;

        protected IProcessContext GenerateContext()
        {
            var context = _ContextFactory.Generate();

            if (context is DbProcessContext dbProcessContext)
            {
                dbProcessContext.SecureConnectionString = _SecureConnectionString;
                return context; 
            }
            else
            {
                throw SorschiaException.InvalidOperation($"Type of '{typeof(DbProcessContext).FullName}' is expected.");
            }
        }

        private readonly SecureString _SecureConnectionString;
    }
}
