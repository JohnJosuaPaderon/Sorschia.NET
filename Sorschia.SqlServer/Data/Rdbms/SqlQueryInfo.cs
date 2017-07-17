using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Sorschia.Data.Rdbms
{
    public sealed class SqlQueryInfo : ISqlQueryInfo
    {
        public List<SqlParameter> Parameters { get; } = new List<SqlParameter>();

        public CommandType CommandType { get; set; }
        public string CommandText { get; set; }
        public GetProcessResultDelegate<SqlCommand> GetProcessResult { get; set; }

        public SqlCommand CreateCommand(SqlConnection connection)
        {
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = CommandText,
                CommandType = CommandType
            };

            Parameters.ForEach(p => command.Parameters.Add(p));

            return command;
        }
    }

    public sealed class SqlQueryInfo<T> : ISqlQueryInfo<T>
    {
        public List<SqlParameter> Parameters { get; } = new List<SqlParameter>();

        public CommandType CommandType { get; set; }

        public string CommandText { get; set; }
        public T Data { get; set; }
        public GetProcessResultDelegate<T, SqlCommand> GetProcessResult { get; set; }

        public SqlCommand CreateCommand(SqlConnection connection)
        {
            var command = new SqlCommand()
            {
                Connection = connection,
                CommandText = CommandText,
                CommandType = CommandType
            };

            Parameters.ForEach(p => command.Parameters.Add(p));

            return command;
        }
    }
}
