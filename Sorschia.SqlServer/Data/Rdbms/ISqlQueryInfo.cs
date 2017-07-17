using System.Data.SqlClient;

namespace Sorschia.Data.Rdbms
{
    public interface ISqlQueryInfo : IDbQueryInfo<SqlConnection, SqlCommand, SqlParameter>
    {
    }

    public interface ISqlQueryInfo<T> : IDbQueryInfo<T, SqlConnection, SqlCommand, SqlParameter>
    {
    }
}
