using Sorschia.Processing;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public class DbHelper<TConnection, TTransaction, TCommand, TQueryParameter> : IDbHelper<TConnection, TTransaction, TCommand, TQueryParameter>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
        where TCommand : DbCommand
        where TQueryParameter : IQueryParameter
    {
        public DbHelper(
            IDbConnectionProvider<TConnection> dbConnectionProvider,
            IDbCommandProvider<TConnection, TTransaction, TCommand> dbCommandProvider)
        {
            _ConnectionProvider = dbConnectionProvider;
            _CommandProvider = dbCommandProvider;
        }

        private readonly IDbConnectionProvider<TConnection> _ConnectionProvider;
        private readonly IDbCommandProvider<TConnection, TTransaction, TCommand> _CommandProvider;

        public IProcessResult ExecuteNonQuery(IQuery<TCommand, TQueryParameter> query)
        {
            try
            {
                using (var connection = _ConnectionProvider.Establish(query.ConnectionStringKey))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        return query.GetProcessResultCallback(command, command.ExecuteNonQuery());
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
                using (var connection = await _ConnectionProvider.EstablishAsync(query.ConnectionStringKey))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync());
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
                using (var connection = await _ConnectionProvider.EstablishAsync(query.ConnectionStringKey, cancellationToken))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync(cancellationToken));
                    }
                }
            }
            catch (Exception ex)
            {
                return ProcessResult.Failed(ex);
            }
        }

        public IProcessResult<T> ExecuteNonQuery<T>(IQuery<T, TCommand, TQueryParameter> query)
        {
            try
            {
                using (var connection = _ConnectionProvider.Establish(query.ConnectionStringKey))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        return query.GetProcessResultCallback(command, command.ExecuteNonQuery());
                    }
                }
            }
            catch (Exception ex)
            {
                return ProcessResult<T>.Failed(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IQuery<T, TCommand, TQueryParameter> query)
        {
            try
            {
                using (var connection = await _ConnectionProvider.EstablishAsync(query.ConnectionStringKey))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync());
                    }
                }
            }
            catch (Exception ex)
            {
                return ProcessResult<T>.Failed(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IQuery<T, TCommand, TQueryParameter> query, CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = await _ConnectionProvider.EstablishAsync(query.ConnectionStringKey))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync(cancellationToken));
                    }
                }
            }
            catch (Exception ex)
            {
                return ProcessResult<T>.Failed(ex);
            }
        }

        public IProcessResult ExecuteNonQuery(TConnection connection, IQuery<TCommand, TQueryParameter> query)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                return query.GetProcessResultCallback(command, command.ExecuteNonQuery());
            }
        }

        public async Task<IProcessResult> ExecuteNonQueryAsync(TConnection connection, IQuery<TCommand, TQueryParameter> query)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync());
            }
        }

        public async Task<IProcessResult> ExecuteNonQueryAsync(TConnection connection, IQuery<TCommand, TQueryParameter> query, CancellationToken cancellationToken)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync(cancellationToken));
            }
        }

        public IProcessResult<T> ExecuteNonQuery<T>(TConnection connection, IQuery<T, TCommand, TQueryParameter> query)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                return query.GetProcessResultCallback(command, command.ExecuteNonQuery());
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(TConnection connection, IQuery<T, TCommand, TQueryParameter> query)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync());
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(TConnection connection, IQuery<T, TCommand, TQueryParameter> query, CancellationToken cancellationToken)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync(cancellationToken));
            }
        }

        public IProcessResult ExecuteNonQuery(TConnection connection, TTransaction transaction, IQuery<TCommand, TQueryParameter> query)
        {
            using (var command = _CommandProvider.Create(connection, transaction, query))
            {
                return query.GetProcessResultCallback(command, command.ExecuteNonQuery());
            }
        }

        public async Task<IProcessResult> ExecuteNonQueryAsync(TConnection connection, TTransaction transaction, IQuery<TCommand, TQueryParameter> query)
        {
            using (var command = _CommandProvider.Create(connection, transaction, query))
            {
                return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync());
            }
        }

        public async Task<IProcessResult> ExecuteNonQueryAsync(TConnection connection, TTransaction transaction, IQuery<TCommand, TQueryParameter> query, CancellationToken cancellationToken)
        {
            using (var command = _CommandProvider.Create(connection, transaction, query))
            {
                return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync(cancellationToken));
            }
        }

        public IProcessResult<T> ExecuteNonQuery<T>(TConnection connection, TTransaction transaction, IQuery<T, TCommand, TQueryParameter> query)
        {
            using (var command = _CommandProvider.Create(connection, transaction, query))
            {
                return query.GetProcessResultCallback(command, command.ExecuteNonQuery());
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(TConnection connection, TTransaction transaction, IQuery<T, TCommand, TQueryParameter> query)
        {
            using (var command = _CommandProvider.Create(connection, transaction, query))
            {
                return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync());
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(TConnection connection, TTransaction transaction, IQuery<T, TCommand, TQueryParameter> query, CancellationToken cancellationToken)
        {
            using (var command = _CommandProvider.Create(connection, transaction, query))
            {
                return query.GetProcessResultCallback(command, await command.ExecuteNonQueryAsync(cancellationToken));
            }
        }

        public IProcessResult<T> ExecuteScalar<T>(IQuery<TQueryParameter> query, Func<object, T> converter)
        {
            try
            {
                using (var connection = _ConnectionProvider.Establish(query.ConnectionStringKey))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        return ProcessResult<T>.Success(converter(command.ExecuteScalar()));
                    }
                }
            }
            catch (Exception ex)
            {
                return ProcessResult<T>.Failed(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteScalarAsync<T>(IQuery<TQueryParameter> query, Func<object, T> converter)
        {
            try
            {
                using (var connection = await _ConnectionProvider.EstablishAsync(query.ConnectionStringKey))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        return ProcessResult<T>.Success(converter(await command.ExecuteScalarAsync()));
                    }
                }
            }
            catch (Exception ex)
            {
                return ProcessResult<T>.Failed(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteScalarAsync<T>(IQuery<TQueryParameter> query, Func<object, T> converter, CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = await _ConnectionProvider.EstablishAsync(query.ConnectionStringKey, cancellationToken))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        return ProcessResult<T>.Success(converter(await command.ExecuteScalarAsync(cancellationToken)));
                    }
                }
            }
            catch (Exception ex)
            {
                return ProcessResult<T>.Failed(ex);
            }
        }

        public IProcessResult<T> ExecuteScalar<T>(TConnection connection, IQuery<TQueryParameter> query, Func<object, T> converter)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                return ProcessResult<T>.Success(converter(command.ExecuteScalar()));
            }
        }

        public async Task<IProcessResult<T>> ExecuteScalarAsync<T>(TConnection connection, IQuery<TQueryParameter> query, Func<object, T> converter)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                return ProcessResult<T>.Success(converter(await command.ExecuteScalarAsync()));
            }
        }

        public async Task<IProcessResult<T>> ExecuteScalarAsync<T>(TConnection connection, IQuery<TQueryParameter> query, Func<object, T> converter, CancellationToken cancellationToken)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                return ProcessResult<T>.Success(converter(await command.ExecuteScalarAsync(cancellationToken)));
            }
        }

        public IProcessResult<T> ExecuteReader<T>(IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter)
        {
            try
            {
                using (var connection = _ConnectionProvider.Establish(query.ConnectionStringKey))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            return converter.FromReader(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ProcessResult<T>.Failed(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteReaderAsync<T>(IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter)
        {
            try
            {
                using (var connection = await _ConnectionProvider.EstablishAsync(query.ConnectionStringKey))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            return await converter.FromReaderAsync(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ProcessResult<T>.Failed(ex);
            }
        }

        public async Task<IProcessResult<T>> ExecuteReaderAsync<T>(IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = await _ConnectionProvider.EstablishAsync(query.ConnectionStringKey, cancellationToken))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            return await converter.FromReaderAsync(reader, cancellationToken);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return ProcessResult<T>.Failed(ex);
            }
        }

        public IProcessResult<T> ExecuteReader<T>(TConnection connection, IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                using (var reader = command.ExecuteReader())
                {
                    return converter.FromReader(reader);
                }
            }
        }

        public async Task<IProcessResult<T>> ExecuteReaderAsync<T>(TConnection connection, IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    return await converter.FromReaderAsync(reader);
                }
            }
        }

        public async Task<IProcessResult<T>> ExecuteReaderAsync<T>(TConnection connection, IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await converter.FromReaderAsync(reader, cancellationToken);
                }
            }
        }

        public IEnumerableProcessResult<T> ExecuteReaderEnumerable<T>(IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter)
        {
            try
            {
                using (var connection = _ConnectionProvider.Establish(query.ConnectionStringKey))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            return converter.EnumerableFromReader(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return EnumerableProcessResult<T>.Failed(ex);
            }
        }

        public async Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter)
        {
            try
            {
                using (var connection = await _ConnectionProvider.EstablishAsync(query.ConnectionStringKey))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        using (var reader = await command.ExecuteReaderAsync())
                        {
                            return await converter.EnumerableFromReaderAsync(reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return EnumerableProcessResult<T>.Failed(ex);
            }
        }

        public async Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken)
        {
            try
            {
                using (var connection = await _ConnectionProvider.EstablishAsync(query.ConnectionStringKey, cancellationToken))
                {
                    using (var command = _CommandProvider.Create(connection, query))
                    {
                        using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                        {
                            return await converter.EnumerableFromReaderAsync(reader, cancellationToken);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return EnumerableProcessResult<T>.Failed(ex);
            }
        }

        public IEnumerableProcessResult<T> ExecuteReaderEnumerable<T>(TConnection connection, IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                using (var reader = command.ExecuteReader())
                {
                    return converter.EnumerableFromReader(reader);
                }
            }
        }

        public async Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(TConnection connection, IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    return await converter.EnumerableFromReaderAsync(reader);
                }
            }
        }

        public async Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(TConnection connection, IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken)
        {
            using (var command = _CommandProvider.Create(connection, query))
            {
                using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    return await converter.EnumerableFromReaderAsync(reader, cancellationToken);
                }
            }
        }
    }
}
