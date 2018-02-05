using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Processing
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseProcessContextFactory<T>(this IServiceCollection instance)
            where T : class, IProcessContextFactory
        {
            return instance.AddSingleton<IProcessContextFactory, T>();
        }
    }
}
