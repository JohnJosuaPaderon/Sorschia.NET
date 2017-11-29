using Sorschia.Data;
using System.Data.Common;

namespace Sorschia.Processing
{
    public sealed class DbProcessContextFactory<TConnection, TTransaction> : IProcessContextFactory
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
        public DbProcessContextFactory(IDbConnectionProvider<TConnection> connectionProvider, IDbTransactionProvider<TTransaction> transactionProvider)
        {
            _ConnectionProvider = connectionProvider;
            _TransactionProvider = transactionProvider;
        }

        private readonly IDbConnectionProvider<TConnection> _ConnectionProvider;
        private readonly IDbTransactionProvider<TTransaction> _TransactionProvider;

        public void Finish(IProcessContext context)
        {
            _TransactionProvider.Dispose(context);
            _ConnectionProvider.CloseDispose(context);
        }

        public IProcessContext Generate()
        {
            return new DbProcessContext();
        }
    }
}
