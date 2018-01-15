using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Security
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseCryptoKeyProvider<T>(this IServiceCollection instance)
            where T : class, ICryptoKeyProvider
        {
            return instance.AddSingleton<ICryptoKeyProvider, T>();
        }
    }
}
