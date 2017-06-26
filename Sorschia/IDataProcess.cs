﻿using System.Threading;
using System.Threading.Tasks;

namespace Sorschia
{
    public interface IDataProcess<T>
    {
        IDataProcessResult<T> Execute();
    }

    public interface IAsyncDataProcess<T>
    {
        Task<IDataProcessResult<T>> ExecuteAsync();
    }

    public interface ICancellableAsyncDataProcess<T>
    {
        Task<IDataProcessResult<T>> ExecuteAsync(CancellationToken cancellationToken);
    }
}
