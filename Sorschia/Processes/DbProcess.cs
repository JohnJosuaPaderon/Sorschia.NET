using Sorschia.Data.Rdbms;
using System;
using System.Data.Common;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Processes
{
    public abstract class DbProcess<TConnection, TCommand, TParameter> : IProcess
        where TConnection : DbConnection
        where TCommand : DbCommand
        where TParameter : DbParameter
    {
        protected readonly IDbHelper<TConnection, TCommand, TParameter> DbHelper;

        public DbProcess(IDbHelper<TConnection, TCommand, TParameter> dbHelper)
        {
            DbHelper = dbHelper ?? throw new ArgumentNullException(nameof(dbHelper));
        }

        protected IDbQueryInfo<TConnection, TCommand, TParameter> QueryInfo { get; }

        public IProcessResult Execute()
        {
            return DbHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult> ExecuteAsync()
        {
            return DbHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult> ExecuteAsync(CancellationToken cancellationToken)
        {
            return DbHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }

    public abstract class DbProcess<T, TConnection, TCommand, TParameter> : IProcess<T>
        where TConnection : DbConnection
        where TCommand : DbCommand
        where TParameter : DbParameter
    {
        protected readonly IDbHelper<TConnection, TCommand, TParameter> DbHelper;

        public DbProcess(IDbHelper<TConnection, TCommand, TParameter> dbHelper)
        {
            DbHelper = dbHelper ?? throw new ArgumentNullException(nameof(dbHelper));
        }

        protected IDbQueryInfo<T, TConnection, TCommand, TParameter> QueryInfo { get; }

        public IProcessResult<T> Execute()
        {
            return DbHelper.ExecuteNonQuery(QueryInfo);
        }

        public Task<IProcessResult<T>> ExecuteAsync()
        {
            return DbHelper.ExecuteNonQueryAsync(QueryInfo);
        }

        public Task<IProcessResult<T>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return DbHelper.ExecuteNonQueryAsync(QueryInfo, cancellationToken);
        }
    }
}
