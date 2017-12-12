using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Convention
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseEntityFieldFormatter<T>(this IServiceCollection instance)
            where T : class, IEntityFieldFormatter
        {
            return instance.AddSingleton<IEntityFieldFormatter, T>();
        }

        public static IServiceCollection UseEntityParameterFormatter<T>(this IServiceCollection instance)
            where T : class, IEntityParameterFormatter
        {
            return instance.AddSingleton<IEntityParameterFormatter, T>();
        }

        public static IServiceCollection UseDefaultEntityFormatters(this IServiceCollection instance)
        {
            return instance
                .UseEntityFieldFormatter<DefaultEntityFieldFormatter>()
                .UseEntityParameterFormatter<DefaultEntityParameterFormatter>();
        }

        public static IServiceCollection UseDefaultStringBuilders(this IServiceCollection instance)
        {
            return instance
                .AddSingleton<IAcronymBuilder, AcronymBuilder>()
                .AddSingleton<IFullNameBuilder, FullNameBuilder>()
                .AddSingleton<IInformalFullNameBuilder, InformalFullNameBuilder>();
        }
    }
}
