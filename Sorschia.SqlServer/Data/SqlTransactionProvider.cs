using System.Data.SqlClient;

namespace Sorschia.Data
{
    public sealed class SqlTransactionProvider : IDbTransactionProvider<SqlConnection, SqlTransaction>
    {
        public SqlTransaction Initialize(SqlConnection connection)
        {
            return connection.BeginTransaction();
        }
    }
}
