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
    public sealed class DeleteDTask : SqlServerProcessBase, IDeleteDTask
    {
        private const string FIELD_ID = "@_Id";
        private const string MESSAGE_FAILED = "Failed to delete task.";

        public DeleteDTask(IDbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter> dbHelper) : base(dbHelper)
        {
        }

        public IDTask DTask { get; set; }

        private IQuery<IDTask, SqlCommand, IQueryParameter> Query =>
            Query<IDTask, SqlCommand, IQueryParameter>.GetStoredProcedure(nameof(DeleteDTask), GetProcessResult)
            .AddInParameter(FIELD_ID, DTask.Id);

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
