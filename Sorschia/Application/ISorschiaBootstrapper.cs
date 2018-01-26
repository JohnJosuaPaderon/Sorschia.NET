using Microsoft.Extensions.DependencyInjection;

namespace Sorschia.Application
{
    public interface ISorschiaBootstrapper
    {
        IServiceCollection Services { get; }
        string ConfigurationFilePath { get; }
        string ServiceIntegratorsDirectory { get; }
        void IntegrateServices();
    }
}
