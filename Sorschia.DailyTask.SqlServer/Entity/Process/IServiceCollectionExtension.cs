using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.DailyTask.Entity.Process
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseSqlServerEntityProcesses(this IServiceCollection instance)
        {
            return instance
                .AddSingleton<IInsertDTask, InsertDTask>();
        }
    }
}
