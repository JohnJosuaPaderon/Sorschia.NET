using Microsoft.Extensions.DependencyInjection;

namespace MyDayManager.Entity.Manager
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseMyDayManagerEntityManager(this IServiceCollection instance)
        {
            return instance
                .AddSingleton<IAssignmentStatusManager, AssignmentStatusManager>();
        }
    }
}
