using Microsoft.Extensions.DependencyInjection;
using Sorschia.Convention;

namespace Sorschia.Extensions
{
    partial class IServiceCollectionExtension
    {
        public static IServiceCollection UseCoreDefault(this IServiceCollection instance)
        {
            instance.UseDefaultEntityInfoConfiguration();

            return instance;
        }

        public static IServiceCollection UseDefaultEntityInfoConfiguration(this IServiceCollection instance)
        {
            instance.UseEntityInfoConfiguration<DefaultEntityInfoConfiguration>();

            return instance;
        }
    }
}
