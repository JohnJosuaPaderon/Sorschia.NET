using Microsoft.Extensions.DependencyInjection;

namespace MyDayManager.Entity.Converter
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseMyDayManagerEntityConverter(this IServiceCollection instance)
        {
            return instance
                .AddTransient<IAssignmentStatusConverter, AssignmentStatusConverter>()
                .AddTransient<IAssignmentConverter, AssignmentConverter>();
        }
    }
}
