using Sorschia.DailyTask.Convention;
using Sorschia.Data;
using Sorschia.Processing;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.DailyTask.Entity.Process
{
    public sealed class InsertDTask : CoreProcessBase, IInsertDTask
    {
        public InsertDTask(IDbProcessor<SqlCommand> processor, IDTaskParameters parameters) : base(processor)
        {
            _Parameters = parameters;
        }

        private readonly IDTaskParameters _Parameters;

        public IDTask DTask { get; set; }

        private IDbQuery Query =>
            DbQueryFactory.StoredProcedure(GetDbObjectName())
            .AddOutParameter(_Parameters.Id, DbQueryParameterType.Int64)
            .AddInParameter(_Parameters.Title, DTask.Title)
            .AddInParameter(_Parameters.Description, DTask.Description)
            .AddInParameter(_Parameters.ScheduledDate, DTask.ScheduledDate)
            .AddInParameter(_Parameters.Status, DTask.Status.ToString());

        private IProcessResult<IDTask> Callback(SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                DTask.Id = command.Parameters.GetInt64(_Parameters.Id);
                return ProcessResult<IDTask>.Success(DTask);
            }
            else
            {
                return ProcessResult<IDTask>.Failed("Failed to insert Task.");
            }
        }

        public IProcessResult<IDTask> Execute(IProcessContext context)
        {
            return _Processor.ExecuteNonQuery(Query, context, Callback);
        }

        public Task<IProcessResult<IDTask>> ExecuteAsync(IProcessContext context)
        {
            return _Processor.ExecuteNonQueryAsync(Query, context, Callback);
        }

        public Task<IProcessResult<IDTask>> ExecuteAsync(IProcessContext context, CancellationToken cancellationToken)
        {
            return _Processor.ExecuteNonQueryAsync(Query, context, Callback, cancellationToken);
        }
    }
}
