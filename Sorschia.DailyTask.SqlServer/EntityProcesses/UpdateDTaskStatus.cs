using Sorschia.DailyTask.Entities;
using Sorschia.Data;
using Sorschia.EntityProcesses;
using Sorschia.Extensions;
using Sorschia.Processing;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.DailyTask.EntityProcesses
{
    public sealed class UpdateDTaskStatus : SqlServerProcessBase, IUpdateDTaskStatus
    {
        private const string FIELD_ID = "@_Id";
        private const string FIELD_TITLE = "@_Title";
        private const string FIELD_DESCRIPTION = "@_Description";
        private const string FIELD_SCHEDULED_DATE = "@_ScheduledDate";
        private const string FIELD_STATUS = "@_Status";
        private const string MESSAGE_FAILED = "Failed to update task status.";

        public UpdateDTaskStatus(IDbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter> dbHelper) : base(dbHelper)
        {
        }

        public IDTask DTask { get; set; }

        private IQuery<IDTask, SqlCommand, IQueryParameter> Query =>
            Query<IDTask, SqlCommand, IQueryParameter>.GetStoredProcedure(nameof(UpdateDTaskStatus), GetProcessResult)
            .AddInParameter(FIELD_ID, DTask.Id)
            .AddInParameter(FIELD_TITLE, DTask.Title)
            .AddInParameter(FIELD_DESCRIPTION, DTask.Description)
            .AddInParameter(FIELD_SCHEDULED_DATE, DTask.ScheduledDate)
            .AddInParameter(FIELD_STATUS, DTask.Status);

        private IProcessResult<IDTask> GetProcessResult(SqlCommand command, int affectedRows)
        {
            if (affectedRows > 0)
            {
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
