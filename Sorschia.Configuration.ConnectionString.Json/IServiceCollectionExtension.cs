using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Configuration
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddJsonConnectionString(this IServiceCollection instance)
        {
            return instance
                .AddConnectionString()
                .AddSingleton<ILoadConnectionStringFromFile, LoadConnectionStringFromFile>()
                .AddSingleton<ISaveConnectionStringToFile, SaveConnectionStringToFile>();
        }
    }
}
 