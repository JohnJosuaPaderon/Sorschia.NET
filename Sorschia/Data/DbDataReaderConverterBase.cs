using Sorschia.Processing;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public abstract partial class DbDataReaderConverterBase<T>
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
    }
}
