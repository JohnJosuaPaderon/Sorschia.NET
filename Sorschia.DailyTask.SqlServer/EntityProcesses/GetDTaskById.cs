using Sorschia.DailyTask.Entities;
using Sorschia.DailyTask.EntityConverters;
using Sorschia.Data;
using Sorschia.EntityProcesses;
using Sorschia.Extensions;
using Sorschia.Processing;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.DailyTask.EntityProcesses
{
    public sealed class GetDTaskById : SqlServerProcessBase, IGetDTaskById
    {
        private const string FIELD_ID = "@_Id";

        public GetDTaskById(IDbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter> dbHelper, IDTaskConverter converter) : base(dbHelper)
        {
            _Converter = converter;
        }

        private readonly IDTaskConverter _Converter;

        public long DTaskId { get; set; }

        private IQuery<IQueryParameter> Query =>
            Query<IQueryParameter>.GetStoredProcedure(nameof(GetDTaskById))
            .AddInParameter(FIELD_ID, DTaskId);

        public IProcessResult<IDTask> Execute()
        {
            return _DbHelper.ExecuteReader(Query, _Converter);
        }

        public Task<IProcessResult<IDTask>> ExecuteAsync()
        {
            return _DbHelper.ExecuteReaderAsync(Query, _Converter);
        }

        public Task<IProcessResult<IDTask>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _DbHelper.ExecuteReaderAsync(Query, _Converter, cancellationToken);
        }
    }
}
