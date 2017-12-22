using Microsoft.Extensions.DependencyInjection;
using Sorschia.Configuration;

namespace Sorschia
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseJson(this IServiceCollection instance, string connectionStringSourceFilePath)
        {
            return instance
                .AddSingleton<IJsonFromFileParser, JsonFromFileParser>()
                .UseConnectionStringSource<JsonConnectionStringSource>()
                .UseJsonConnectionStringSourceFromFileLoader(connectionStringSourceFilePath);
        }
    }
}
