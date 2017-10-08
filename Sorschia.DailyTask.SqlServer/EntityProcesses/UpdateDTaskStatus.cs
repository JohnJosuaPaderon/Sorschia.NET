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
    public sealed class UpdateDTaskStatus : SqlServerProcessBase, IUpdateDTaskStatus
    {
        private const string MESSAGE_FAILED = "Failed to update task status.";

        public UpdateDTaskStatus(IDbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter> dbHelper, IDTaskParameters parameters) : base(dbHelper)
        {
            _Parameters = parameters;
        }

        private readonly IDTaskParameters _Parameters;

        public IDTask DTask { get; set; }

        private IQuery<IDTask, SqlCommand, IQueryParameter> Query =>
            Query<IDTask, SqlCommand, IQueryParameter>.GetStoredProcedure(nameof(UpdateDTaskStatus), GetProcessResult)
            .AddInParameter(_Parameters.Id, DTask.Id)
            .AddInParameter(_Parameters.Status, DTask.Status);

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
