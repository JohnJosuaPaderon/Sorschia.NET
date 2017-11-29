using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Configuration
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseJsonConnectionStringSourceFromFileLoader(this IServiceCollection instance, string filePath)
        {
            return instance.AddSingleton<IConnectionStringSourceLoader>(new JsonConnectionStringSourceFromFileLoader(filePath));
        }
    }
}
