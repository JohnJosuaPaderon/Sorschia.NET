using System.Data.SqlClient;

namespace Sorschia.Data.Rdbms
{
    public interface ISqlConnectionEstablisher : IDbConnectionEstablisher<SqlConnection>
    {
    }
}
