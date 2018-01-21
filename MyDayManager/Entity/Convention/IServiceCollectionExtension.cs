using Microsoft.Extensions.DependencyInjection;

namespace MyDayManager.Entity.Convention
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseMyDayManagerEntityConvention(this IServiceCollection instance)
        {
            return instance
                .AddSingleton<IGlobalEntityParameters, GlobalEntityParameters>()
                .AddSingleton<IAssignmentFields, AssignmentFields>()
                .AddSingleton<IAssignmentParameters, AssignmentParameters>()
                .AddSingleton<IAssignmentStatusFields, AssignmentStatusFields>()
                .AddSingleton<IAssignmentStatusParameters, AssignmentStatusParameters>();
        }
    }
}
