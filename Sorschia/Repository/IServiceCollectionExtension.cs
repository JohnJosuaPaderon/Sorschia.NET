using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Repository
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddRepository<TContract, TImplementation>(this IServiceCollection instance)
            where TContract : class
            where TImplementation : class, TContract
        {
            return instance.AddSingleton<TContract, TImplementation>();
        }
    }
}
