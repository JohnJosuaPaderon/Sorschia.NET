using Sorschia.DailyTask.Entities;
using Sorschia.DailyTask.EntityInfo;
using Sorschia.Data;
using Sorschia.EntityProcesses;
using Sorschia.Extensions;
using Sorschia.Processing;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.DailyTask.EntityProcesses
{
    public sealed class InsertDTask : SqlServerProcessBase, IInsertDTask
    {
        private const string MESSAGE_FAILED = "Failed to insert task.";

        public InsertDTask(IDbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter> dbHelper, IDTaskParameters parameters) : base(dbHelper)
        {
            _Parameters = parameters;
        }

        private readonly IDTaskParameters _Parameters;

        public IDTask DTask { get; set; }

        private IQuery<IDTask, SqlCommand, IQueryParameter> Query =>
            Query<IDTask, SqlCommand, IQueryParameter>.GetStoredProcedure(nameof(InsertDTask), GetProcessResult)
            .AddOutParameter(_Parameters.Id)
            .AddInParameter(_Parameters.Title, DTask.Title)
            .AddInParameter(_Parameters.Description, DTask.Description)
            .AddInParameter(_Parameters.ScheduledDate, DTask.ScheduledDate)
            .AddInParameter(_Parameters.Status, DTask.Status);

        private IProcessResult<IDTask> GetProcessResult(SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
                DTask.Id = command.Parameters.GetInt64(_Parameters.Id);
                return ProcessResult<IDTask>.Success(DTask);
            }
            else
            {
                return ProcessResult<IDTask>.Failed(MESSAGE_FAILED);
            }
        }

        public IProcessResult<IDTask> Execute()
        {
            return _DbHelper.ExecuteNonQuery(Query);
        }

        public Task<IProcessResult<IDTask>> ExecuteAsync()
        {
            return _DbHelper.ExecuteNonQueryAsync(Query);
        }

        public Task<IProcessResult<IDTask>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _DbHelper.ExecuteNonQueryAsync(Query, cancellationToken);
        }
    }
}
