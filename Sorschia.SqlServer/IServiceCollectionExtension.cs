using Microsoft.Extensions.DependencyInjection;
using Sorschia.Data;
using Sorschia.Processing;
using System.Data.SqlClient;

namespace Sorschia
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseSqlServer(this IServiceCollection instance)
        {
            return instance
                .UseDbConnectionProvider<SqlConnectionProvider, SqlConnection>()
                .UseDbTransactionProvider<SqlTransactionProvider, SqlTransaction>()
                .UseDbCommandCreator<SqlCommandCreator, SqlCommand>()
                .UseDbQueryParameterConverter<SqlQueryParameterConverter, SqlParameter>()
                .UseDbProcessor<SqlProcessor, SqlCommand>()
                .UseProcessContextFactory<DbProcessContextFactory<SqlConnection, SqlTransaction>>();
        }
    }
}
