using Microsoft.Extensions.DependencyInjection;
using Sorschia.Configuration;

namespace Sorschia
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseJson(this IServiceCollection instance, string connectionStringSourceFilePath)
        {
            return instance
                .UseConnectionStringSource<JsonConnectionStringSource>()
                .UseJsonConnectionStringSourceFromFileLoader(connectionStringSourceFilePath);
        }
    }
}
