using Sorschia.DailyTask.Entities;
using Sorschia.DailyTask.Converters;
using Sorschia.DailyTask.EntityInfo;
using Sorschia.Data;
using Sorschia.Processes;
using Sorschia.Extensions;
using Sorschia.Processing;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.DailyTask.Processes
{
    public sealed class GetDTaskById : SqlServerProcessBase, IGetDTaskById
    {
        public GetDTaskById(IDbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter> dbHelper, IDTaskConverter converter, IDTaskParameters parameters) : base(dbHelper)
        {
            _Converter = converter;
            _Parameters = parameters;
        }

        private readonly IDTaskConverter _Converter;
        private readonly IDTaskParameters _Parameters;

        public long DTaskId { get; set; }

        private IQuery<IQueryParameter> Query =>
            Query<IQueryParameter>.GetStoredProcedure(nameof(GetDTaskById))
            .AddInParameter(_Parameters.Id, DTaskId);

        public IProcessResult<IDTask> Execute()
        {
            _Converter.PId.Value = DTaskId;
            return _DbHelper.ExecuteReader(Query, _Converter);
        }

        public Task<IProcessResult<IDTask>> ExecuteAsync()
        {
            _Converter.PId.Value = DTaskId;
            return _DbHelper.ExecuteReaderAsync(Query, _Converter);
        }

        public Task<IProcessResult<IDTask>> ExecuteAsync(CancellationToken cancellationToken)
        {
            _Converter.PId.Value = DTaskId;
            return _DbHelper.ExecuteReaderAsync(Query, _Converter, cancellationToken);
        }
    }
}
