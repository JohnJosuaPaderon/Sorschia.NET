using Microsoft.Extensions.DependencyInjection;
using MyDayManager.Entity.Manager;
using MyDayManager.Entity.Process;
using Sorschia.Application;
using System.Composition;

namespace MyDayManager
{
    [Export(typeof(IServiceIntegrator))]
    public sealed class ServiceIntegrator : ServiceIntegratorBase, IServiceIntegrator
    {
        public ServiceIntegrator() : base("SqlServer")
        {
        }

        public void Integrate(IServiceCollection services)
        {
            services
                .UseMyDayManagerEntityProcess()
                .UseMyDayManagerEntityManager();
        }
    }
}
