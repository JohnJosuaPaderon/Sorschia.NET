using System.Data.SqlClient;

namespace Sorschia.Data
{
    public sealed class SqlQueryParameterConverter : IDbQueryParameterConverter<SqlParameter>
    {
        public SqlParameter Convert(IDbQueryParameter parameter)
        {
            return new SqlParameter(parameter.Name, parameter.Value)
            {
                Direction = DbQueryParameterDirectionConverter.Convert(parameter.Direction)
            };
        }
    }
}
