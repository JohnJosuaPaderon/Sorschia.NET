using Microsoft.Extensions.DependencyInjection;

namespace MyDayManager.Entity.Process
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseMyDayManagerEntityProcess(this IServiceCollection instance)
        {
            return instance
                .AddSingleton<IGetAssignmentStatus, GetAssignmentStatus>()
                .AddSingleton<IGetAssignmentStatusByKey, GetAssignmentStatusByKey>();
        }
    }
}
