using Microsoft.Extensions.DependencyInjection;

namespace Sorschia
{
    public abstract class BootstrapperBase
    {
        public IServiceCollection Services { get; } = new ServiceCollection();

        public void Run()
        {
            ApplicationDomain.ServiceProvider = Services.BuildServiceProvider();
        }
    }
}