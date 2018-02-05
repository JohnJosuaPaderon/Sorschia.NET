using Sorschia.Processing;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public abstract partial class DbProcessorBase<TCommand> : IDbProcessor<TCommand>
        where TCommand : DbCommand
    {
        public DbProcessorBase(IDbCommandCreator<TCommand> commandCreator)
        {
            _CommandCreator = commandCreator;
        }

        private readonly IDbCommandCreator<TCommand> _CommandCreator;

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
