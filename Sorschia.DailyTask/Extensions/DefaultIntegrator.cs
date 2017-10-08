using Microsoft.Extensions.DependencyInjection;
using Sorschia.DailyTask.EntityInfo;

namespace Sorschia.DailyTask.Extensions
{
    public static class DefaultIntegrator
    {
        public static IServiceCollection UseDailyTaskDefaultInfoProviders(this IServiceCollection instance)
        {
            instance.AddSingleton<IDTaskFields, DTaskFields>();
            instance.AddSingleton<IDTaskParameters, DTaskParameters>();

            return instance;
        }
    }
}
