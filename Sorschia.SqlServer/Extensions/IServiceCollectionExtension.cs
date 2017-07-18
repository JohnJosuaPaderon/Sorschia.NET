using Microsoft.Extensions.DependencyInjection;
using Sorschia.Data.Rdbms;

namespace Sorschia.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseSqlServer(this IServiceCollection services)
        {
            services.AddSingleton<ISqlConnectionEstablisher, SqlConnectionEstablisher>();
            services.AddSingleton<ISqlHelper, SqlHelper>();

            return services;
        }
    }
}
