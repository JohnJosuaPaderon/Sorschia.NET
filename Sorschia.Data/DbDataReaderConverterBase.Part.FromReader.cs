using Sorschia.Processing;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    partial class DbDataReaderConverterBase<T>
    {
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
