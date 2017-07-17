using System.Data.SqlClient;

namespace Sorschia.Data.Rdbms
{
    public interface ISqlHelper : IDbHelper<SqlConnection, SqlCommand, SqlParameter, SqlDataReader>
    {
    }
}
