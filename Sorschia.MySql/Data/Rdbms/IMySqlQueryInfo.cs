using MySql.Data.MySqlClient;

namespace Sorschia.Data.Rdbms
{
    public interface IMySqlQueryInfo : IDbQueryInfo<MySqlConnection, MySqlCommand, MySqlParameter>
    {
    }

    public interface IMySqlQueryInfo<T> : IDbQueryInfo<T, MySqlConnection, MySqlCommand, MySqlParameter>
    {
    }
}
