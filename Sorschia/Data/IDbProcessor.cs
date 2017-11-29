using Sorschia.Processing;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public interface IDbProcessor<TCommand> where TCommand : DbCommand
    {
        IProcessResult ExecuteNonQuery(IDbQuery query, IProcessContext processContext);
        IProcessResult<T> ExecuteNonQuery<T>(IDbQuery query, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback);
        IProcessResult<T> ExecuteReader<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter);
        IEnumerableProcessResult<T> ExecuteEnumerableReader<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter);
        IProcessResult<T> ExecuteScalar<T>(IDbQuery query, IProcessContext processContext, Func<object, T> converter);
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQuery query, IProcessContext processContext);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQuery query, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter);
        Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQuery query, IProcessContext processContext, Func<object, T> converter);
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQuery query, IProcessContext processContext, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQuery query, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken);
        Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQuery query, IProcessContext processContext, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQuery query, IProcessContext processContext, Func<object, T> converter, CancellationToken cancellationToken);
    }
}
