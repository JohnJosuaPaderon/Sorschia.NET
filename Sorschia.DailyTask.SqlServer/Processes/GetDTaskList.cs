using Sorschia.DailyTask.Entities;
using Sorschia.DailyTask.Converters;
using Sorschia.Data;
using Sorschia.Processes;
using Sorschia.Processing;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.DailyTask.Processes
{
    public sealed class GetDTaskList : SqlServerProcessBase, IGetDTaskList
    {
        public GetDTaskList(IDbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter> dbHelper, IDTaskConverter converter) : base(dbHelper)
        {
            _Converter = converter;
        }

        private readonly IDTaskConverter _Converter;

        private IQuery<IQueryParameter> Query => Query<IQueryParameter>.GetStoredProcedure(nameof(GetDTaskList));

        public IEnumerableProcessResult<IDTask> Execute()
        {
            return _DbHelper.ExecuteReaderEnumerable(Query, _Converter);
        }

        public Task<IEnumerableProcessResult<IDTask>> ExecuteAsync()
        {
            return _DbHelper.ExecuteReaderEnumerableAsync(Query, _Converter);
        }

        public Task<IEnumerableProcessResult<IDTask>> ExecuteAsync(CancellationToken cancellationToken)
        {
            return _DbHelper.ExecuteReaderEnumerableAsync(Query, _Converter, cancellationToken);
        }
    }
}
