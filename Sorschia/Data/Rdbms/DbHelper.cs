using Sorschia.Processes;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data.Rdbms
{
    public class DbHelper<TConnection, TCommand, TParameter> : IDbHelper<TConnection, TCommand, TParameter>
        where TConnection : DbConnection
        where TCommand : DbCommand
        where TParameter : DbParameter
    {
        protected readonly IDbConnectionEstablisher<TConnection> ConnectionEstablisher;

        public DbHelper(IDbConnectionEstablisher<TConnection> connectionEstablisher)
        {
            ConnectionEstablisher = connectionEstablisher ?? throw new ArgumentNullException(nameof(connectionEstablisher));
        }

        public IEnumerableProcessResult<T> ExecuteEnumerableReader<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T> converter)
        {
            try
            {
                using (var connection = ConnectionEstablisher.Establish())
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                return converter.EnumerableFromReader(reader);
                            }
                            else
                            {
                                return new EnumerableProcessResult<T>(ProcessResultStatus.NoData, "No result.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<T>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T> converter)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync())
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                return await converter.EnumerableFromReaderAsync(reader);
                            }
                            else
                            {
                                return new EnumerableProcessResult<T>(ProcessResultStatus.NoData, "No Result.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<T>(ex);
            }
        }

        public async Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T> converter, CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            if (reader.HasRows)
                            {
                                return await converter.EnumerableFromReaderAsync(reader, cancellationToken);
                            }
                            else
                            {
                                return new EnumerableProcessResult<T>(ProcessResultStatus.NoData, "No Result.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new EnumerableProcessResult<T>(ex);
            }
        }

        public IProcessResult ExecuteNonQuery(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo)
        {
            try
            {
                using (var connection = ConnectionEstablisher.Establish())
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        return queryInfo.GetProcessResult(command, command.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult(ex);
            }
        }

        public IProcessResult<T> ExecuteNonQuery<T>(IDbQueryInfo<T, TConnection, TCommand, TParameter> queryInfo)
        {
            try
            {
                using (var connection = ConnectionEstablisher.Establish())
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        return queryInfo.GetProcessResult(queryInfo.Data, command, command.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }

        public async Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync())
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        return queryInfo.GetProcessResult(command, await command.ExecuteNonQueryAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult(ex);
            }
        }

        public async Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        return queryInfo.GetProcessResult(command, await command.ExecuteNonQueryAsync(cancellationToken));
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, TConnection, TCommand, TParameter> queryInfo)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync())
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        return queryInfo.GetProcessResult(queryInfo.Data, command, await command.ExecuteNonQueryAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, TConnection, TCommand, TParameter> queryInfo, CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        return queryInfo.GetProcessResult(queryInfo.Data, command, await command.ExecuteNonQueryAsync(cancellationToken));
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }

        public IProcessResult<T> ExecuteReader<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T> converter)
        {
            try
            {
                using (var connection = ConnectionEstablisher.Establish())
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                return converter.FromReader(reader);
                            }
                            else
                            {
                                return new ProcessResult<T>(ProcessResultStatus.NoData, "No result.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T> converter)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync())
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.HasRows)
                            {
                                return await converter.FromReaderAsync(reader);
                            }
                            else
                            {
                                return new ProcessResult<T>(ProcessResultStatus.NoData, "No result.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T> converter, CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            if (reader.HasRows)
                            {
                                return await converter.FromReaderAsync(reader, cancellationToken);
                            }
                            else
                            {
                                return new ProcessResult<T>(ProcessResultStatus.NoData, "No result.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }

        public IProcessResult<T> ExecuteScalar<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, Func<object, T> converter)
        {
            try
            {
                using (var connection = ConnectionEstablisher.Establish())
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        return new ProcessResult<T>(converter(command.ExecuteScalar()), ProcessResultStatus.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, Func<object, T> converter)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync())
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        return new ProcessResult<T>(converter(await command.ExecuteScalarAsync()), ProcessResultStatus.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, Func<object, T> converter, CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = await ConnectionEstablisher.EstablishAsync(cancellationToken))
                {
                    using (var command = queryInfo.CreateCommand(connection))
                    {
                        return new ProcessResult<T>(converter(await command.ExecuteScalarAsync(cancellationToken)), ProcessResultStatus.Success);
                    }
                }
            }
            catch (Exception ex)
            {
                return new ProcessResult<T>(ex);
            }
        }
    }
}
