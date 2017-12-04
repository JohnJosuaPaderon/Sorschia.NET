using Microsoft.Extensions.DependencyInjection;
using Sorschia.DailyTask.Entity.Manager;
using Sorschia.DailyTask.Entity.Process;
using Sorschia.Extensions;
using Sorschia.Processing;
using System.Data.SqlClient;

namespace Sorschia.DailyTask
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseSqlServerForDailyTask(this IServiceCollection instance)
        {
            return instance
                .UseProcessContextFactory<DbProcessContextFactory<SqlConnection, SqlTransaction>>()
                .UseSqlServerEntityProcesses()
                .UseSqlServerEntityManagers();
        }
    }
}
