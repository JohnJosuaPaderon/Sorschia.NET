using Microsoft.Extensions.DependencyInjection;

namespace MyDayManager.Entity.Process
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseMyDayManagerEntityProcess(this IServiceCollection instance)
        {
            return instance
                .AddTransient<IGetAssignmentStatus, GetAssignmentStatus>()
                .AddTransient<IGetAssignmentStatusByKey, GetAssignmentStatusByKey>();
        }
    }
}
