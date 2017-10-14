using Microsoft.Extensions.DependencyInjection;
using Sorschia.DailyTask.Converters;
using Sorschia.DailyTask.Processes;
using Sorschia.Extensions;

namespace Sorschia.DailyTask.Extensions
{
    public static class SqlServerIntegrator
    {
        public static IServiceCollection UseSqlServerForDailyTask(this IServiceCollection instance)
        {
            instance.AddSqlServer();

            instance.AddTransient<IDTaskConverter, DTaskConverter>();
            instance.AddTransient<IDeleteDTask, DeleteDTask>();
            instance.AddTransient<IGetDTaskById, GetDTaskById>();
            instance.AddTransient<IGetDTaskList, GetDTaskList>();
            instance.AddTransient<IInsertDTask, InsertDTask>();
            instance.AddTransient<IUpdateDTaskStatus, UpdateDTaskStatus>();

            return instance;
        }
    }
}
