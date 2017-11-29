using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Configuration
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseConnectionStringSource<T>(this IServiceCollection instance)
            where T : class, IConnectionStringSource
        {
            return instance.AddSingleton<IConnectionStringSource, T>();
        }

        public static IServiceCollection UseConnectionStringSourceLoader<T>(this IServiceCollection instance)
            where T : class, IConnectionStringSourceLoader
        {
            return instance.AddSingleton<IConnectionStringSourceLoader, T>();
        }
    }
}
