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

        public static IServiceCollection UseConnectionStringFileSource(this IServiceCollection instance, string filePath)
        {
            return instance.AddSingleton<IConnectionStringFileSource>(new ConnectionStringFileSource(filePath));
        }

        public static IServiceCollection UseConnectionStringSourcePropertyNameProvider<T>(this IServiceCollection instance)
            where T : class, IConnectionStringSourcePropertyNameProvider
        {
            return instance.AddSingleton<IConnectionStringSourcePropertyNameProvider, T>();
        }

        public static IServiceCollection UseConnectionStringPropertyNameProvider<T>(this IServiceCollection instance)
            where T : class, IConnectionStringPropertyNameProvider
        {
            return instance.AddSingleton<IConnectionStringPropertyNameProvider, T>();
        }
        
        public static IServiceCollection UseConnectionStringCryptoService<T>(this IServiceCollection instance)
            where T : class, IConnectionStringCryptoService
        {
            return instance.AddSingleton<IConnectionStringCryptoService, T>();
        }

        public static IServiceCollection UseDefaultConnectionStringCryptoService(this IServiceCollection instance)
        {
            return instance.UseConnectionStringCryptoService<ConnectionStringCryptoService>();
        }
    }
}
