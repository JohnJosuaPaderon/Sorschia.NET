using System;
using System.Data.Common;
using System.Security;
using System.Threading.Tasks;

namespace Sorschia.DataAccess.Rdbms
{
    public interface IDbHelper<TCommand, TParameter, TDataReader>
        where TCommand : DbCommand
        where TParameter : DbParameter
        where TDataReader : DbDataReader
    {
        SecureString SecureConnectionString { get; set; }
        IProcessResult ExecuteNonQuery(IDbQueryInfo<TCommand, TParameter> queryInfo);
        IDataProcessResult<T> ExecuteNonQuery<T>(IDbQueryInfo<TCommand, TParameter> queryInfo);
        IDataProcessResult<T> ExecuteReader<T>(IDbQueryInfo<TCommand, TParameter> queryInfo, Func<TDataReader, T> getFromReader);
        IEnumerableDataProcessResult<T> ExecuteReaderEnumerable<T>(IDbQueryInfo<TCommand, TParameter> queryInfo, Func<TDataReader, T> getFromReader);
        IDataProcessResult<T> ExecuteScalar<T>(IDbQueryInfo<TCommand, TParameter> queryInfo, Func<object, T> converter);
    }

    public interface IAsyncDbHelper<TCommand, TParameter, TDataReader>
        where TCommand : DbCommand
        where TParameter : DbParameter
        where TDataReader : DbDataReader
    {
        SecureString SecureConnectionString { get; set; }
        Task<IProcessResult> ExecuteNonQueryAsync(IDbQueryInfo<TCommand, TParameter> queryInfo);
        Task<IDataProcessResult<T>> ExecuteNonQueryAsync<T>(IDbQueryInfo<TCommand, TParameter> queryInfo);
        Task<IDataProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TCommand, TParameter> queryInfo, Func<TDataReader, T> getFromReader);
        Task<IDataProcessResult<T>> ExecuteReaderAsync<T>(IDbQueryInfo<TCommand, TParameter> queryInfo, Func<TDataReader, Task<T>> getFromReaderAsync);
        Task<IEnumerableDataProcessResult<T>> ExecuteReaderEnumerable<T>(IDbQueryInfo<TCommand, TParameter> queryInfo, Func<TDataReader, T> getFromReader);
        Task<IEnumerableDataProcessResult<T>> ExecuteReaderEnumerable<T>(IDbQueryInfo<TCommand, TParameter> queryInfo, Func<TDataReader, Task<T>> getFromReaderAsync);
    }

    public interface ICancellableAsyncDbHelper<TCommand, TParameter, TDataReader>
        where TCommand : DbCommand
        where TParameter : DbParameter
        where TDataReader : DbDataReader
    {

    }
}
