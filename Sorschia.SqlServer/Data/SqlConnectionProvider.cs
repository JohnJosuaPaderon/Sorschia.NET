using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;
using Sorschia.Processing;
using System.Collections.Generic;

namespace Sorschia.Data
{
    public sealed class SqlConnectionProvider : DbConnectionProviderBase<SqlConnection>, IDbConnectionProvider<SqlConnection>
    {
        protected override SqlConnection Instantiate(IProcessContext processContext)
        {
            if (processContext is DbProcessContext dbProcessContext)
            {
                return new SqlConnection()
            }
            else
            {
                throw SorschiaException.InvalidOperation($"Type of '{typeof(DbProcessContext).FullName}' is expected.");
            }
        }
    }
}
