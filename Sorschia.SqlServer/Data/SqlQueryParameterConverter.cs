using System;
using System.Data.SqlClient;

namespace Sorschia.Data
{
    public sealed class SqlQueryParameterConverter : IDbQueryParameterConverter<SqlParameter>
    {
        public SqlParameter Convert(IDbQueryParameter parameter)
        {
            var result = new SqlParameter(parameter.Name, parameter.Value ?? DBNull.Value)
            {
                Direction = DbQueryParameterDirectionConverter.Convert(parameter.Direction)
            };

            if (parameter.Type != DbQueryParameterType.NotSet)
            {
                result.DbType = DbQueryParameterTypeToDbTypeConverter.Convert(parameter.Type);
                result.SqlDbType = DbQueryParameterTypeToSqlDbTypeConverter.Convert(parameter.Type);
            }

            return result;
        }
    }
}
