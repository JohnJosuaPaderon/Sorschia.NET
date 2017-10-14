using Microsoft.Extensions.DependencyInjection;
using Sorschia.Convention;

namespace Sorschia.Extensions
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseEntityInfoConfiguration<T>(IServiceCollection instance)
            where T : class, IEntityInfoConfiguration
        {
            instance.AddSingleton<IEntityInfoConfiguration, T>();

            return instance;
        }
    }
}
