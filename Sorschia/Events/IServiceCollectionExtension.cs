using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Events
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseEventDefaults(this IServiceCollection instance)
        {
            return instance
                .AddSingleton<ISorschiaEventManager, SorschiaEventManager>();
        }
    }
}
