using Sorschia.Data.Processing;
using Sorschia.Processing;
using Sorschia.Security;
using System.Data.SqlClient;

namespace Sorschia.Data
{
    public sealed class SqlConnectionProvider : DbConnectionProviderBase<SqlConnection>, IDbConnectionProvider<SqlConnection>
    {
        protected override SqlConnection Instantiate(IProcessContext processContext)
        {
            if (processContext is DbProcessContext dbProcessContext)
            {
                return new SqlConnection(SecureStringConverter.Convert(dbProcessContext.SecureConnectionString));
            }
            else
            {
                throw SorschiaException.InvalidOperation($"Type of '{typeof(DbProcessContext).FullName}' is expected.");
            }
        }
    }
}
