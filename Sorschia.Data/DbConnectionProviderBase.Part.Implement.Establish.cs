using Sorschia.Processing;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    partial class DbConnectionProviderBase<TConnection>
    {
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
    }
}
