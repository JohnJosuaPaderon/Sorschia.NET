using MySql.Data.MySqlClient;

namespace Sorschia.Data.Rdbms
{
    public interface IMySqlConnectionEstablisher : IDbConnectionEstablisher<MySqlConnection>
    {
    }
}
