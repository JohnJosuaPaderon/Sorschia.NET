using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Configuration
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddConnectionString(this IServiceCollection instance)
        {
            return instance
                .AddSingleton<IConnectionStringManager, ConnectionStringManager>();
        }
    }
}
