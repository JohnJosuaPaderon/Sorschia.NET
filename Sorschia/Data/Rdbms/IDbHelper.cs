using Sorschia.Processes;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data.Rdbms
{
    public interface IDbHelper<TConnection, TCommand, TParameter, TDataReader>
        where TConnection : DbConnection
        where TCommand : DbCommand
        where TParameter : DbParameter
        where TDataReader : DbDataReader
    {
        IProcessResult ExecuteNonQuery(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo);
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo);
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, CancellationToken cancellationToken);
        IProcessResult<T> ExecuteNonQuery<T>(IDbQueryInfo<T, TConnection, TCommand, TParameter> queryInfo);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, TConnection, TCommand, TParameter> queryInfo);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, TConnection, TCommand, TParameter> queryInfo, CancellationToken cancellationToken);
        IProcessResult<T> ExecuteReader<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T, TDataReader> converter);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T, TDataReader> converter);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T, TDataReader> converter, CancellationToken cancellationToken);
        IEnumerableProcessResult<T> ExecuteEnumerableReader<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T, TDataReader> converter);
        Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T, TDataReader> converter);
        Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T, TDataReader> converter, CancellationToken cancellationToken);
        IProcessResult<T> ExecuteScalar<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, Func<object, T> converter);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, Func<object, T> converter);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, Func<object, T> converter, CancellationToken cancellationToken);
    }

    public interface IDbHelper<TConnection, TCommand, TParameter>
       where TConnection : DbConnection
       where TCommand : DbCommand
       where TParameter : DbParameter
    {
        IProcessResult ExecuteNonQuery(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo);
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo);
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, CancellationToken cancellationToken);
        IProcessResult<T> ExecuteNonQuery<T>(IDbQueryInfo<T, TConnection, TCommand, TParameter> queryInfo);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, TConnection, TCommand, TParameter> queryInfo);
        Task<IProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<T, TConnection, TCommand, TParameter> queryInfo, CancellationToken cancellationToken);
        IProcessResult<T> ExecuteReader<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T> converter);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T> converter);
        Task<IProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T> converter, CancellationToken cancellationToken);
        IEnumerableProcessResult<T> ExecuteEnumerableReader<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T> converter);
        Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T> converter);
        Task<IEnumerableProcessResult<T>> ExecuteEnumerableReaderAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, IDataConverter<T> converter, CancellationToken cancellationToken);
        IProcessResult<T> ExecuteScalar<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, Func<object, T> converter);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, Func<object, T> converter);
        Task<IProcessResult<T>> ExecuteScalarAsync<T>(IDbQueryInfo<TConnection, TCommand, TParameter> queryInfo, Func<object, T> converter, CancellationToken cancellationToken);
    }
}
