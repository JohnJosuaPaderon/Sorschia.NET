using Sorschia.Processing;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public abstract class DbConnectionProviderBase<TConnection> : IDbConnectionProvider<TConnection>
        where TConnection : DbConnection
    {
        public DbConnectionProviderBase()
        {
            _Source = new Dictionary<IProcessContext, TConnection>();
        }

        protected readonly Dictionary<IProcessContext, TConnection> _Source;

        protected abstract TConnection Instantiate(IProcessContext processContext);

        public TConnection Establish(IProcessContext processContext)
        {
            if (_Source.ContainsKey(processContext))
            {
                return _Source[processContext];
            }
            else
            {
                try
                {
                    var connection = Instantiate(processContext);
                    connection.Open();
                    return connection;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<TConnection> EstablishAsync(IProcessContext processContext)
        {
            if (_Source.ContainsKey(processContext))
            {
                return _Source[processContext];
            }
            else
            {
                try
                {
                    var connection = Instantiate(processContext);
                    await connection.OpenAsync();
                    return connection;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public async Task<TConnection> EstablishAsync(IProcessContext processContext, CancellationToken cancellationToken)
        {
            if (_Source.ContainsKey(processContext))
            {
                return _Source[processContext];
            }
            else
            {
                try
                {
                    var connection = Instantiate(processContext);
                    await connection.OpenAsync(cancellationToken);
                    return connection;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
