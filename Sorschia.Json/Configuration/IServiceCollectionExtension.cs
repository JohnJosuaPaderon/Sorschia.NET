using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Configuration
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseJsonConnectionStringSourceFromFileLoader(this IServiceCollection instance, string filePath)
        {
            return instance
                .UseJsonPropertyNameProviders()
                .UseConnectionStringSourceLoader<JsonConnectionStringSourceFromFileLoader>()
                .UseConnectionStringFileSource(filePath);
        }

        public static IServiceCollection UseJsonPropertyNameProviders(this IServiceCollection instance)
        {
            return instance
                .UseConnectionStringSourcePropertyNameProvider<JsonConnectionStringSourcePropertyNameProvider>()
                .UseConnectionStringPropertyNameProvider<JsonConnectionStringPropertyNameProvider>();
        }
    }
}
