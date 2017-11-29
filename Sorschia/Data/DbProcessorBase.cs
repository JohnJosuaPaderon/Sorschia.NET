using Sorschia.Processing;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public abstract class DbProcessorBase<TCommand> : IDbProcessor<TCommand>
        where TCommand : DbCommand
    {
        public DbProcessorBase(IDbCommandCreator<TCommand> commandCreator)
        {
            _CommandCreator = commandCreator;
        }

        private readonly IDbCommandCreator<TCommand> _CommandCreator;

        public IEnumerableProcessResult<T> ExecuteEnumerableReader<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter)
        {
            using (var command = _CommandCreator.Create(query, processContext))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return converter.EnumerableFromReader(reader);
                    }
                    else
                    {
                        return EnumerableProcessResult<T>.NoResult();
                    }
                }
            }
        }

        public async Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        return await converter.EnumerableFromReaderAsync(reader);
                    }
                    else
                    {
                        return EnumerableProcessResult<T>.NoResult();
                    }
                }
            }
        }

        public async Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext))
            {
                using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    if (reader.HasRows)
                    {
                        return await converter.EnumerableFromReaderAsync(reader, cancellationToken);
                    }
                    else
                    {
                        return EnumerableProcessResult<T>.NoResult();
                    }
                }
            }
        }

        public IProcessResult ExecuteNonQuery(IDbQuery query, IProcessContext processContext)
        {
            using (var command = _CommandCreator.Create(query, processContext))
            {
                try
                {
                    command.ExecuteNonQuery();
                    return ProcessResult.Success();
                }
                catch (Exception ex)
                {
                    processContext.IsFaulted = true;
                    return ProcessResult.Failed(ex);
                }
            }
        }

        public IProcessResult<T> ExecuteNonQuery<T>(IDbQuery query, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback)
        {
            using (var command = _CommandCreator.Create(query, processContext))
            {
                try
                {
                    return callback(command, command.ExecuteNonQuery());
                }
                catch (Exception ex)
                {
                    processContext.IsFaulted = true;
                    return ProcessResult<T>.Failed(ex);
                }
            }
        }

        public async Task<IProcessResult> ExecuteNonQueryAsync(IDbQuery query, IProcessContext processContext)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext))
            {
                try
                {
                    await command.ExecuteNonQueryAsync();
                    return ProcessResult.Success();
                }
                catch (Exception ex)
                {
                    processContext.IsFaulted = true;
                    return ProcessResult.Failed(ex);
                }
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQuery query, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext))
            {
                try
                {
                    return callback(command, await command.ExecuteNonQueryAsync());
                }
                catch (Exception ex)
                {
                    processContext.IsFaulted = true;
                    return ProcessResult<T>.Failed(ex);
                }
            }
        }

        public async Task<IProcessResult> ExecuteNonQueryAsync(IDbQuery query, IProcessContext processContext, CancellationToken cancellationToken)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext, cancellationToken))
            {
                try
                {
                    await command.ExecuteNonQueryAsync(cancellationToken);
                    return ProcessResult.Success();
                }
                catch (Exception ex)
                {
                    processContext.IsFaulted = true;
                    return ProcessResult.Failed(ex);
                }
            }
        }

        public async Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQuery query, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback, CancellationToken cancellationToken)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext, cancellationToken))
            {
                try
                {
                    return callback(command, await command.ExecuteNonQueryAsync(cancellationToken));
                }
                catch (Exception ex)
                {
                    processContext.IsFaulted = true;
                    return ProcessResult<T>.Failed(ex);
                }
            }
        }

        public IProcessResult<T> ExecuteReader<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter)
        {
            using (var command = _CommandCreator.Create(query, processContext))
            {
                using (var reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        return converter.FromReader(reader);
                    }
                    else
                    {
                        return ProcessResult<T>.NoResult();
                    }
                }
            }
        }

        public async Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext))
            {
                using (var reader = await command.ExecuteReaderAsync())
                {
                    if (reader.HasRows)
                    {
                        return await converter.FromReaderAsync(reader);
                    }
                    else
                    {
                        return ProcessResult<T>.NoResult();
                    }
                }
            }
        }

        public async Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext, cancellationToken))
            {
                using (var reader = await command.ExecuteReaderAsync(cancellationToken))
                {
                    if (reader.HasRows)
                    {
                        return await converter.FromReaderAsync(reader, cancellationToken);
                    }
                    else
                    {
                        return ProcessResult<T>.NoResult();
                    }
                }
            }
        }

        public IProcessResult<T> ExecuteScalar<T>(IDbQuery query, IProcessContext processContext, Func<object, T> converter)
        {
            using (var command = _CommandCreator.Create(query, processContext))
            {
                return ProcessResult<T>.Success(converter(command.ExecuteScalar()));
            }
        }

        public async Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQuery query, IProcessContext processContext, Func<object, T> converter)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext))
            {
                return ProcessResult<T>.Success(converter(await command.ExecuteScalarAsync()));
            }
        }

        public async Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQuery query, IProcessContext processContext, Func<object, T> converter, CancellationToken cancellationToken)
        {
            using (var command = await _CommandCreator.CreateAsync(query, processContext, cancellationToken))
            {
                return ProcessResult<T>.Success(converter(await command.ExecuteScalarAsync(cancellationToken)));
            }
        }
    }
}
