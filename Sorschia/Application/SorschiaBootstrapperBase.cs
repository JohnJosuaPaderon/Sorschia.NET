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
        public string BaseDirectory { get; protected set; }
        public string PluginDirectory { get; protected set; }
        public string ConfigurationFilePath { get; protected set; }
    }
}
