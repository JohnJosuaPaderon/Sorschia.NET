using Sorschia.Data;
using System.Data.SqlClient;

namespace Sorschia.Processes
{
    public abstract class SqlServerProcessBase
    {
        public SqlServerProcessBase(IDbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter> dbHelper)
        {
            _DbHelper = dbHelper;
        }

        protected readonly IDbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter> _DbHelper;
    }
}
