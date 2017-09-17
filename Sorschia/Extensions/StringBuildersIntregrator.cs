using Microsoft.Extensions.DependencyInjection;
using Sorschia.Utilities;

namespace Sorschia.Extensions
{
    public static class StringBuildersIntregrator
    {
        public static IServiceCollection UseDefaultStringBuilders(this IServiceCollection instance)
        {
            instance.AddSingleton<IAcronymBuilder, AcronymBuilder>();
            instance.AddSingleton<IFullNameBuilder, FullNameBuilder>();
            instance.AddSingleton<IInformalFullNameBuilder, InformalFullNameBuilder>();

            return instance;
        }
    }
}
