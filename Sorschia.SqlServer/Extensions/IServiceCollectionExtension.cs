using Microsoft.Extensions.DependencyInjection;
using Sorschia.Data.Rdbms;
using System.Data.SqlClient;

namespace Sorschia.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseSqlServer(this IServiceCollection services)
        {
            services.AddSingleton<IDbConnectionEstablisher<SqlConnection>, SqlConnectionEstablisher>();

            return services;
        }
    }
}
