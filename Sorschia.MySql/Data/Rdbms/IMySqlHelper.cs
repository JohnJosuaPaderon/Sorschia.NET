using MySql.Data.MySqlClient;

namespace Sorschia.Data.Rdbms
{
    public interface IMySqlHelper : IDbHelper<MySqlConnection, MySqlCommand, MySqlParameter, MySqlDataReader>
    {
    }
}
