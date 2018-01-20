using Sorschia.Data;
using Sorschia.Processing;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Entity.Process
{
    public abstract class SqlEntityExecuteCallbackProcessBase<T, TIdentifier> : SqlEntityProcessBase, IProcess<T>
        where T : IEntity<TIdentifier>
    {
        public SqlEntityExecuteCallbackProcessBase(IDbProcessor<SqlCommand> processor, string schema = null) : base(processor, schema)
        {
        }

        protected abstract IProcessResult<T> Callback(SqlCommand command, int affectedRows);

        public IProcessResult<T> Execute(IProcessContext context)
        {
            return _Processor.ExecuteNonQuery(Query, context, Callback);
        }

        public Task<IProcessResult<T>> ExecuteAsync(IProcessContext context)
        {
            return _Processor.ExecuteNonQueryAsync(Query, context, Callback);
        }

        public Task<IProcessResult<T>> ExecuteAsync(IProcessContext context, CancellationToken cancellationToken)
        {
            return _Processor.ExecuteNonQueryAsync(Query, context, Callback, cancellationToken);
        }
    }
}
