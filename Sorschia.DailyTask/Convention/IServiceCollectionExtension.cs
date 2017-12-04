using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.DailyTask.Convention
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseEntityConventions(this IServiceCollection instance)
        {
            return instance
                .AddSingleton<IDTaskFields, DTaskFields>()
                .AddSingleton<IDTaskParameters, DTaskParameters>();
        }
    }
}
