using Microsoft.Extensions.DependencyInjection;
using Sorschia.Data;
using System.Data.SqlClient;

namespace Sorschia.Extensions
{
    public static class SqlServerIntegrator
    {
        public static IServiceCollection AddSqlServer(this IServiceCollection instance)
        {
            instance.AddSingleton<IDbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter>, DbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter>>();
            instance.AddSingleton<IDbConnectionProvider<SqlConnection>, SqlConnectionProvider>();
            instance.AddSingleton<IDbTransactionProvider<SqlConnection, SqlTransaction>, SqlTransactionProvider>();
            instance.AddSingleton<IDbCommandProvider<SqlConnection, SqlTransaction, SqlCommand>, SqlCommandProvider>();

            return instance;
        }
    }
}
