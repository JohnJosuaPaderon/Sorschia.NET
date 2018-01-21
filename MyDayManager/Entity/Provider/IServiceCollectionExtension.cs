using Microsoft.Extensions.DependencyInjection;

namespace MyDayManager.Entity.Provider
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseMyDayManagerEntityProvider(this IServiceCollection instance)
        {
            return instance
                .AddSingleton<IAssignmentStatusProvider, AssignmentStatusProvider>();
        }
    }
}
