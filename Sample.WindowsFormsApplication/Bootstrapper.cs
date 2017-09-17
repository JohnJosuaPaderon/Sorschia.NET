using Microsoft.Extensions.DependencyInjection;
using Sorschia;
using Sorschia.Extensions;

namespace Sample.WindowsFormsApplication
{
    class Bootstrapper : SorschiaBootstrapper
    {
        protected override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            
            services.UseSqlServer();
        }


    }
}
