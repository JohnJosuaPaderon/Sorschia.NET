using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Application
{
    public abstract class SorschiaBootstrapperBase
    {
        public SorschiaBootstrapperBase()
        {
            Services = new ServiceCollection();
        }

        public IServiceCollection Services { get; }
        public string ConfigurationFilePath { get; protected set; }
    }
}
