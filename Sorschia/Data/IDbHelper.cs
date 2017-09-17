using Sorschia.Processing;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public interface IDbHelper<TConnection, TTransaction, TCommand, TQueryParameter>
        where TConnection : DbConnection
        where TTransaction : DbTransaction
        where TCommand : DbCommand
        where TQueryParameter : IQueryParameter
    {
        IProcessResult ExecuteNonQuery(IQuery<TCommand, TQueryParameter> query);
        Task<IProcessResult> ExecuteNonQueryAsync(IQuery<TCommand, TQueryParameter> query);
        Task<IProcessResult> ExecuteNonQueryAsync(IQuery<TCommand, TQueryParameter> query, CancellationToken cancellationToken);
        IProcessResult<T> ExecuteNonQuery<T>(IQuery<T, TCommand, TQueryParameter> query);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IQuery<T, TCommand, TQueryParameter> query);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IQuery<T, TCommand, TQueryParameter> query, CancellationToken cancellationToken);
        IProcessResult ExecuteNonQuery(TConnection connection, IQuery<TCommand, TQueryParameter> query);
        Task<IProcessResult> ExecuteNonQueryAsync(TConnection connection, IQuery<TCommand, TQueryParameter> query);
        Task<IProcessResult> ExecuteNonQueryAsync(TConnection connection, IQuery<TCommand, TQueryParameter> query, CancellationToken cancellationToken);
        IProcessResult<T> ExecuteNonQuery<T>(TConnection connection, IQuery<T, TCommand, TQueryParameter> query);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(TConnection connection, IQuery<T, TCommand, TQueryParameter> query);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(TConnection connection, IQuery<T, TCommand, TQueryParameter> query, CancellationToken cancellationToken);
        IProcessResult ExecuteNonQuery(TConnection connection, TTransaction transaction, IQuery<TCommand, TQueryParameter> query);
        Task<IProcessResult> ExecuteNonQueryAsync(TConnection connection, TTransaction transaction, IQuery<TCommand, TQueryParameter> query);
        Task<IProcessResult> ExecuteNonQueryAsync(TConnection connection, TTransaction transaction, IQuery<TCommand, TQueryParameter> query, CancellationToken cancellationToken);
        IProcessResult<T> ExecuteNonQuery<T>(TConnection connection, TTransaction transaction, IQuery<T, TCommand, TQueryParameter> query);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(TConnection connection, TTransaction transaction, IQuery<T, TCommand, TQueryParameter> query);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(TConnection connection, TTransaction transaction, IQuery<T, TCommand, TQueryParameter> query, CancellationToken cancellationToken);
        IProcessResult<T> ExecuteScalar<T>(IQuery<TQueryParameter> query, Func<object, T> converter);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IQuery<TQueryParameter> query, Func<object, T> converter);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IQuery<TQueryParameter> query, Func<object, T> converter, CancellationToken cancellationToken);
        IProcessResult<T> ExecuteScalar<T>(TConnection connection, IQuery<TQueryParameter> query, Func<object, T> converter);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(TConnection connection, IQuery<TQueryParameter> query, Func<object, T> converter);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(TConnection connection, IQuery<TQueryParameter> query, Func<object, T> converter, CancellationToken cancellationToken);
        IProcessResult<T> ExecuteReader<T>(IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken);
        IProcessResult<T> ExecuteReader<T>(TConnection connection, IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(TConnection connection, IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(TConnection connection, IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken);
        IEnumerableProcessResult<T> ExecuteReaderEnumerable<T>(IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter);
        Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter);
        Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken);
        IEnumerableProcessResult<T> ExecuteReaderEnumerable<T>(TConnection connection, IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter);
        Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(TConnection connection, IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter);
        Task<IEnumerableProcessResult<T>> ExecuteReaderEnumerableAsync<T>(TConnection connection, IQuery<TQueryParameter> query, IDbDataReaderConverter<T> converter, CancellationToken cancellationToken);
    }
}
