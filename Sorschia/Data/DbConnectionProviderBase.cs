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
                    _Source.Add(processContext, connection);
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
                    _Source.Add(processContext, connection);
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
                    _Source.Add(processContext, connection);
                    return connection;
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        public TConnection Request(IProcessContext processContext)
        {
            return _Source[processContext];
        }

        public void CloseDispose(IProcessContext processContext)
        {
            var connection = _Source[processContext];

            if (connection != null)
            {
                connection.Close();
                connection.Dispose();
                _Source.Remove(processContext);
            }
        }
    }
}
