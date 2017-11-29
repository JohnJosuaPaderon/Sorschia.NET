using System;
using System.Data.SqlClient;

namespace Sorschia.Data
{
    public sealed class SqlQueryParameterConverter : IDbQueryParameterConverter<SqlParameter>
    {
        public SqlParameter Convert(IDbQueryParameter parameter)
        {
            throw new NotImplementedException();
        }
    }
}
