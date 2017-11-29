using System.Data.SqlClient;

namespace Sorschia.Data
{
    public sealed class SqlTransactionProvider : DbTransactionProviderBase<SqlConnection, SqlTransaction>, IDbTransactionProvider<SqlTransaction>
    {
        public SqlTransactionProvider(IDbConnectionProvider<SqlConnection> connectionProvider) : base(connectionProvider)
        {
        }

        protected override SqlTransaction BeginTransaction(SqlConnection connection)
        {
            return connection.BeginTransaction();
        }
    }
}
