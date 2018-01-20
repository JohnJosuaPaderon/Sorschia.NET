using Sorschia.Data;
using Sorschia.Processing;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Entity.Process
{
    public abstract class SqlEntityExecuteProcessBase : SqlEntityProcessBase, IProcess
    {
        public SqlEntityExecuteProcessBase(IDbProcessor<SqlCommand> processor, string schema = null) : base(processor, schema)
        {
        }

        public IProcessResult Execute(IProcessContext context)
        {
            return _Processor.ExecuteNonQuery(Query, context);
        }

        public Task<IProcessResult> ExecuteAsync(IProcessContext context)
        {
            return _Processor.ExecuteNonQueryAsync(Query, context);
        }

        public Task<IProcessResult> ExecuteAsync(IProcessContext context, CancellationToken cancellationToken)
        {
            return _Processor.ExecuteNonQueryAsync(Query, context, cancellationToken);
        }
    }
}
