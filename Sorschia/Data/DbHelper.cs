using Sorschia.Processing;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public class DbHelper<TConnection, TCommand, TQueryParameter> : IDbHelper<TCommand, TQueryParameter>
        where TConnection : DbConnection
        where TCommand : DbCommand
        where TQueryParameter : IQueryParameter
    {
        public DbHelper(
            IDbConnectionProvider<TConnection> dbConnectionProvider,
            IDbCommandProvider<TCommand> dbCommandProvider)
        {
            _DbConnectionProvider = dbConnectionProvider;
            _DbCommandProvider = dbCommandProvider;
        }

        private readonly IDbConnectionProvider<TConnection> _DbConnectionProvider;
        private readonly IDbCommandProvider<TCommand> _DbCommandProvider;

        public IProcessResult ExecuteNonQuery(IQuery<TCommand, TQueryParameter> query)
        {
            try
            {
                using (var connection = _DbConnectionProvider.Establish(query.ConnectionStringKey))
                {
                    using (var command = _DbCommandProvider.Create(query))
                    {
                        try
                        {
                            return query.GetProcessResultCallback(command, command.ExecuteNonQuery());
                        }
                        catch (Exception ex)
                        {
                            return ProcessResult.Failed(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ProcessResult.Failed(ex);
            }
        }

        public async Task<IProcessResult> ExecuteNonQueryAsync(IQuery<TCommand, TQueryParameter> query)
        {
            try
            {
                using (var connection = await _DbConnectionProvider.EstablishAsync(query.ConnectionStringKey))
                {
                    using (var command = _DbCommandProvider.Create(query))
                    {
                        try
                        {
                            return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync());
                        }
                        catch (Exception ex)
                        {
                            return ProcessResult.Failed(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ProcessResult.Failed(ex);
            }
        }

        public async Task<IProcessResult> ExecuteNonQueryAsync(IQuery<TCommand, TQueryParameter> query, CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = await _DbConnectionProvider.EstablishAsync(query.ConnectionStringKey, cancellationToken))
                {
                    using (var command = _DbCommandProvider.Create(query))
                    {
                        try
                        {
                            return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync(cancellationToken));
                        }
                        catch (Exception ex)
                        {
                            return ProcessResult.Failed(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ProcessResult.Failed(ex);
            }
        }
    }
}
