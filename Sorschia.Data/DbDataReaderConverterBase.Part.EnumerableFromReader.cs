using Sorschia.Processing;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    partial class DbDataReaderConverterBase<T>
    {
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
    }
}
