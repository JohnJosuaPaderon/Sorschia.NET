using Sorschia.Processing;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public interface IDbProcessor<TCommand>
        where TCommand : DbCommand
    {
        IProcessResult ExecuteNonQuery(TCommand command, IProcessContext processContext);
        IProcessResult<T> ExecuteNonQuery<T>(TCommand command, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback);
        IProcessResult<T> ExecuteReader<T>(TCommand command, IProcessContext processContext, IDbDataReaderConverter<T> converter);
        IEnumerableProcessResult<T> ExecuteEnumerableReader<T>(TCommand command, IProcessContext processContext, IDbDataReaderConverter<T> converter);
        IProcessResult<T> ExecuteScalar<T>(TCommand command, IProcessContext processContext, Func<object, T> converter);
        Task<IProcessResult> ExecuteNonQueryAsync(TCommand command, IProcessContext processContext);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(TCommand command, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(TCommand command, IProcessContext processContext, IDbDataReaderConverter<T> converter);
        Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(TCommand command, IProcessContext processContext, IDbDataReaderConverter<T> converter);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(TCommand command, IProcessContext processContext, Func<object, T> converter);
        Task<IProcessResult> ExecuteNonQueryAsync(TCommand command, IProcessContext processContext, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(TCommand command, IProcessContext processContext, IDbProcessorCallback<T, TCommand> callback, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(TCommand command, IProcessContext processContext, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken);
        Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(TCommand command, IProcessContext processContext, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(TCommand command, IProcessContext processContext, Func<object, T> converter, CancellationToken cancellationToken);
    }
}
