using Sorschia.Processing;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    partial class DbProcessorBase<TCommand>
    {
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
    }
}
