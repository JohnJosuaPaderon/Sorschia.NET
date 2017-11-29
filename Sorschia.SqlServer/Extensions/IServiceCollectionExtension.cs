using Microsoft.Extensions.DependencyInjection;
using Sorschia.Data;
using System.Data.SqlClient;

namespace Sorschia.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseSqlServer(this IServiceCollection instance)
        {
            return instance
                .UseDbConnectionProvider<SqlConnectionProvider, SqlConnection>()
                .UseDbTransactionProvider<SqlTransactionProvider, SqlTransaction>()
                .UseDbCommandCreator<SqlCommandCreator, SqlCommand>()
                .UseDbQueryParameterConverter<SqlQueryParameterConverter, SqlParameter>();
        }
    }
}
