using Microsoft.Extensions.DependencyInjection;
using Sorschia.Convention;
using Sorschia.Data;
using System.Data.SqlClient;

namespace Sorschia.Extensions
{
    public static class SqlServerIntegrator
    {
        public static IServiceCollection UseSqlServerEntityInfoConfiguration(this IServiceCollection instance)
        {
            instance.UseEntityInfoConfiguration<SqlServerEntityInfoConfiguration>();

            return instance;
        }

        public static IServiceCollection UseSqlServer(this IServiceCollection instance)
        {
            instance.AddSingleton<IDbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter>, DbHelper<SqlConnection, SqlTransaction, SqlCommand, IQueryParameter>>();
            instance.AddSingleton<IDbConnectionProvider<SqlConnection>, SqlConnectionProvider>();
            instance.AddSingleton<IConnectionPool<SqlConnection>, SqlConnectionPool>();
            instance.AddSingleton<IDbTransactionProvider<SqlConnection, SqlTransaction>, SqlTransactionProvider>();
            instance.AddSingleton<IDbCommandProvider<SqlConnection, SqlTransaction, SqlCommand>, SqlCommandProvider>();

            return instance;
        }
    }
}
