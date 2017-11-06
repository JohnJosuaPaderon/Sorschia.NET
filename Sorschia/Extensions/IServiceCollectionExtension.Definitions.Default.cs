using Microsoft.Extensions.DependencyInjection;
using Sorschia.Convention;
using Sorschia.Data;

namespace Sorschia.Extensions
{
    partial class IServiceCollectionExtension
    {
        public static IServiceCollection UseCoreDefault(this IServiceCollection instance)
        {
            instance.UseDefaultEntityInfoConfiguration();
            instance.UseDefaultDbDataReaderToProcessResultConverter();
            instance.UseDefaultDbDataReaderToEnumerableProcessResultConverter();

            return instance;
        }

        public static IServiceCollection UseDefaultDbDataReaderToProcessResultConverter(this IServiceCollection instance)
        {
            instance.UseDbDataReaderToProcessResultConverter<DefaultDbDataReaderToProcessResultConverter>();

            return instance;
        }

        public static IServiceCollection UseDefaultDbDataReaderToEnumerableProcessResultConverter(this IServiceCollection instance)
        {
            instance.UseDbDataReaderToEnumerableProcessResultConverter<DefaultDbDataReaderToEnumerableProcessResultConverter>();

            return instance;
        }

        public static IServiceCollection UseDefaultEntityInfoConfiguration(this IServiceCollection instance)
        {
            instance.UseEntityInfoConfiguration<DefaultEntityInfoConfiguration>();

            return instance;
        }
    }
}
