using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Application
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseAppCryptoService<T>(this IServiceCollection instance)
            where T : class, IAppCryptoService
        {
            return instance.AddSingleton<IAppCryptoService, T>();
        }

        public static IServiceCollection UseDefaultAppCryptoService(this IServiceCollection instance)
        {
            return instance.UseAppCryptoService<DefaultAppCryptoService>();
        }
    }
}
