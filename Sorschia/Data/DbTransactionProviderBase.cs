using Sorschia.Processing;
using System.Collections.Generic;
using System.Data.Common;

namespace Sorschia.Data
{
    public abstract class DbTransactionProviderBase<TConnection, TTransaction> : IDbTransactionProvider<TTransaction>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
    {
        public DbTransactionProviderBase(IDbConnectionProvider<TConnection> connectionProvider)
        {
            _Source = new Dictionary<IProcessContext, TTransaction>();
            _ConnectionProvider = connectionProvider;
        }

        private readonly IDbConnectionProvider<TConnection> _ConnectionProvider;
        private readonly Dictionary<IProcessContext, TTransaction> _Source;

        protected abstract TTransaction BeginTransaction(TConnection connection);

        public void Dispose(IProcessContext processContext)
        {
            var transaction = _Source[processContext];

            if (transaction != null)
            {
                if (processContext.IsFaulted)
                {
                    transaction.Rollback();
                }
                else
                {
                    transaction.Commit();
                }

                transaction.Dispose();
                _Source.Remove(processContext);
            }
        }

        public TTransaction this[IProcessContext processContext]
        {
            get
            {
                if (!_Source.ContainsKey(processContext))
                {
                    var connection = _ConnectionProvider.Request(processContext);
                    var transaction = BeginTransaction(connection);

                    _Source.Add(processContext, transaction);
                    return transaction;
                }
                else
                {
                    return _Source[processContext];
                }
            }
        }
    }
}
