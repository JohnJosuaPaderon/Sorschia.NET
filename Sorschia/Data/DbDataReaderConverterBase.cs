﻿using Sorschia.Processing;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public abstract class DbDataReaderConverterBase<T>
    {
        protected IProcessResult<T> FromReader(DbDataReader reader, Func<DbDataReader, T> converter)
        {
            if (reader.HasRows)
            {
                try
                {
                    reader.Read();
                    return ProcessResult<T>.Success(converter(reader));
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

        protected async Task<IProcessResult<T>> AsyncFromReaderAsync(DbDataReader reader, Func<DbDataReader, Task<T>> convertAsync)
        {
            if (reader.HasRows)
            {
                try
                {
                    await reader.ReadAsync();
                    return ProcessResult<T>.Success(await convertAsync(reader));
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

        protected async Task<IProcessResult<T>> AsyncFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken, Func<DbDataReader, CancellationToken, Task<T>> convertAsync)
        {
            if (reader.HasRows)
            {
                try
                {
                    await reader.ReadAsync(cancellationToken);
                    return ProcessResult<T>.Success(await convertAsync(reader, cancellationToken));
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

        protected async Task<IProcessResult<T>> FromReaderAsync(DbDataReader reader, Func<DbDataReader, T> convert)
        {
            if (reader.HasRows)
            {
                try
                {
                    await reader.ReadAsync();
                    return ProcessResult<T>.Success(convert(reader));
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

        protected async Task<IProcessResult<T>> FromReaderAsync(DbDataReader reader, CancellationToken cancellationToken, Func<DbDataReader, T> convert)
        {
            if (reader.HasRows)
            {
                try
                {
                    await reader.ReadAsync(cancellationToken);
                    return ProcessResult<T>.Success(convert(reader));
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

        protected IEnumerableProcessResult<T> EnumerableFromReader(DbDataReader reader, Func<DbDataReader, T> convert)
        {
            if (reader.HasRows)
            {
                try
                {
                    var list = new List<T>();

                    while (reader.Read())
                    {
                        list.Add(convert(reader));
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

        protected async Task<IEnumerableProcessResult<T>> AsyncEnumerableFromReaderAsync(DbDataReader reader, Func<DbDataReader, Task<T>> convertAsync)
        {
            if (reader.HasRows)
            {
                try
                {
                    var list = new List<T>();

                    while (await reader.ReadAsync())
                    {
                        list.Add(await convertAsync(reader));
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

        protected async Task<IEnumerableProcessResult<T>> AsyncEnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken, Func<DbDataReader, CancellationToken, Task<T>> convertAsync)
        {
            if (reader.HasRows)
            {
                try
                {
                    var list = new List<T>();

                    while (await reader.ReadAsync(cancellationToken))
                    {
                        list.Add(await convertAsync(reader, cancellationToken));
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

        protected async Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync(DbDataReader reader, Func<DbDataReader, T> convert)
        {
            if (reader.HasRows)
            {
                try
                {
                    var list = new List<T>();

                    while (await reader.ReadAsync())
                    {
                        list.Add(convert(reader));
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

        protected async Task<IEnumerableProcessResult<T>> EnumerableFromReaderAsync(DbDataReader reader, CancellationToken cancellationToken, Func<DbDataReader, T> convert)
        {
            if (reader.HasRows)
            {
                try
                {
                    var list = new List<T>();

                    while (await reader.ReadAsync(cancellationToken))
                    {
                        list.Add(convert(reader));
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
