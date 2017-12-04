using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.DailyTask.Entity.Manager
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseSqlServerEntityManagers(this IServiceCollection instance)
        {
            return instance
                .AddSingleton<IDTaskManager, DTaskManager>();
        }
    }
}
