﻿using System.Threading;
using System.Threading.Tasks;

namespace Sorschia
{
    public interface IDataManager<T>
    {
        IDataProcessResult<T> Insert(T data);
        IDataProcessResult<T> Update(T data);
        IDataProcessResult<T> Delete(T data);
        IEnumerableDataProcessResult<T> GetList();
    }

    public interface IAsyncDataManager<T>
    {
        Task<IDataProcessResult<T>> InsertAsync(T data);
        Task<IDataProcessResult<T>> UpdateAsync(T data);
        Task<IDataProcessResult<T>> DeleteAsync(T data);
        Task<IEnumerableDataProcessResult<T>> GetListAsync();
    }

    public interface ICancellableAsyncDataManager<T>
    {
        Task<IDataProcessResult<T>> InsertAsync(T data, CancellationToken cancellationToken);
        Task<IDataProcessResult<T>> UpdateAsync(T data, CancellationToken cancellationToken);
        Task<IDataProcessResult<T>> DeleteAsync(T data, CancellationToken cancellationToken);
        Task<IEnumerableDataProcessResult<T>> GetListAsync(CancellationToken cancellationToken);
    }
}
