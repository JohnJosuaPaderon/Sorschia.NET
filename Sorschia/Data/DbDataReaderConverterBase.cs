using Sorschia.Processing;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public abstract class DbDataReaderConverterBase<T> : IDbDataReaderConverter<T>
    {
        protected abstract T Convert(DbDataReader reader);

        protected virtual Task<T> ConvertAsync(DbDataReader reader)
        {
            return Task.FromResult(Convert(reader));
        }

        protected virtual Task<T> ConvertAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            return Task.FromResult(Convert(reader));
        }

        public IEnumerableProcessResult<T> EnumerableFromReader(DbDataReader reader)
        {
            if (reader.HasRows)
            {
                var list = new List<T>();

                try
                {
                    while (reader.Read())
                    {
                        list.Add(Convert(reader));
                    }

                    return EnumerableProcessResult<T>.Success(list);
                }
                catch (Exception ex)
                {
                    return EnumerableProcessResult<T>.Failed(ex);
                }

            }
            else
            {
                return EnumerableProcessResult<T>.NoResult();
            }
        }

        public async Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync(DbDataReader reader)
        {
            if (reader.HasRows)
            {
                var list = new List<T>();

                try
                {
                    while (await reader.ReadAsync())
                    {
                        list.Add(await ConvertAsync(reader));
                    }

                    return EnumerableProcessResult<T>.Success(list);
                }
                catch (Exception ex)
                {
                    return EnumerableProcessResult<T>.Failed(ex);
                }

            }
            else
            {
                return EnumerableProcessResult<T>.NoResult();
            }
        }

        public async Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            if (reader.HasRows)
            {
                var list = new List<T>();

                try
                {
                    while (await reader.ReadAsync(cancellationToken))
                    {
                        list.Add(await ConvertAsync(reader, cancellationToken));
                    }

                    return EnumerableProcessResult<T>.Success(list);
                }
                catch (Exception ex)
                {
                    return EnumerableProcessResult<T>.Failed(ex);
                }

            }
            else
            {
                return EnumerableProcessResult<T>.NoResult();
            }
        }

        public IProcessResult<T> FromReader(DbDataReader reader)
        {
            if (reader.HasRows)
            {
                try
                {
                    reader.Read();
                    return ProcessResult<T>.Success(Convert(reader));
                }
                catch (Exception ex)
                {
                    return ProcessResult<T>.Failed(ex);
                }
            }
            else
            {
                return ProcessResult<T>.NoResult();
            }
        }

        public async Task<IProcessResult<T>> FromReaderAsync(DbDataReader reader)
        {
            if (reader.HasRows)
            {
                try
                {
                    await reader.ReadAsync();
                    return ProcessResult<T>.Success(await ConvertAsync(reader));
                }
                catch (Exception ex)
                {
                    return ProcessResult<T>.Failed(ex);
                }
            }
            else
            {
                return ProcessResult<T>.NoResult();
            }
        }

        public async Task<IProcessResult<T>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken)
        {
            if (reader.HasRows)
            {
                try
                {
                    await reader.ReadAsync(cancellationToken);
                    return ProcessResult<T>.Success(await ConvertAsync(reader, cancellationToken));
                }
                catch (Exception ex)
                {
                    return ProcessResult<T>.Failed(ex);
                }
            }
            else
            {
                return ProcessResult<T>.NoResult();
            }
        }
    }
}
