using Microsoft.Extensions.DependencyInjection;
using Sorschia.Convention;

namespace Sorschia.Extensions
{
    public static partial class IServiceCollectionExtension
    {
        public static IServiceCollection UseEntityInfoConfiguration<T>(this IServiceCollection instance)
            where T : class, IEntityInfoConfiguration
        {
            instance.AddSingleton<IEntityInfoConfiguration, T>();

            return instance;
        }
    }
}
