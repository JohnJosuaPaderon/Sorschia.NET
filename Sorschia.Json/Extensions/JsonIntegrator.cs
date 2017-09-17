using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Sorschia.Configurations;

namespace Sorschia.Extensions
{
    public static class JsonIntegrator
    {
        public static IServiceCollection AddJsonConnectionStringSource(this IServiceCollection instance, JObject source)
        {
            instance.AddSingleton(source);
            instance.AddSingleton<IConnectionStringSource, JsonConnectionStringSource>();

            return instance;
        }

        public static IServiceCollection AddJsonConnectionStringSourceProvider(this IServiceCollection instance, JsonConnectionStringSourceProvider provider)
        {
            instance.AddSingleton(provider);

            return instance;
        }
    }
}
