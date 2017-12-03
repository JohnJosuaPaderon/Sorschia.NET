using Sorschia.Processing;

namespace Sorschia.Entity.Manager
{
    public abstract class SqlManagerBase
    {
        public SqlManagerBase(IProcessContextFactory contextFactory, string connectionStringKey)
        {
            _ContextFactory = contextFactory;
            _ConnectionStringKey = connectionStringKey;
        }

        private readonly IProcessContextFactory _ContextFactory;
        private readonly string _ConnectionStringKey;

        protected IProcessContext GenerateContext()
        {
            var context = _ContextFactory.Generate();

            if (context is DbProcessContext dbProcessContext)
            {
                dbProcessContext.ConnectionStringKey = _ConnectionStringKey;
                return context;
            }
            else
            {
                throw SorschiaException.InvalidOperation($"Type of '{typeof(DbProcessContext).FullName}' is expected.");
            }
        }
    }
}
