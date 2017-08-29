using System;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data.Rdbms
{
    public sealed class SqlConnectionEstablisher : IDbConnectionEstablisher<SqlConnection>
    {
        public SqlConnection Establish()
        {
            throw new NotImplementedException();
        }

        public Task<SqlConnection> EstablishAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SqlConnection> EstablishAsync(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
