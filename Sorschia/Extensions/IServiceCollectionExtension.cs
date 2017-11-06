using Microsoft.Extensions.DependencyInjection;
using Sorschia.Convention;
using Sorschia.Data;

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

        public static IServiceCollection UseDbDataReaderToProcessResultConverter<T>(this IServiceCollection instance)
            where T : class, IDbDataReaderToProcessResultConverter
        {
            instance.AddSingleton<IDbDataReaderToProcessResultConverter, T>();

            return instance;
        }

        public static IServiceCollection UseDbDataReaderToEnumerableProcessResultConverter<T>(this IServiceCollection instance)
            where T : class, IDbDataReaderToEnumerableProcessResultConverter
        {
            instance.AddSingleton<IDbDataReaderToEnumerableProcessResultConverter, T>();

            return instance;
        }
    }
}
