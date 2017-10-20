using Microsoft.Extensions.DependencyInjection;
using Sorschia.DailyTask.Extensions;
using System.Composition;

namespace Sorschia.DailyTask
{
    [Export(typeof(IServiceIntegrator))]
    public sealed class ServiceIntegrator : ServiceIntegratorBase, IServiceIntegrator
    {
        public IServiceCollection Integrate(IServiceCollection services)
        {
            services.UseSqlServerForDailyTask();

            return services;
        }
    }
}
