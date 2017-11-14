using Microsoft.Extensions.DependencyInjection;
using Sorschia.Utilities;

namespace Sorschia
{
    internal sealed class SorschiaAppBuilder
    {
        private static SorschiaAppBuilder _Instance;

        public static SorschiaAppBuilder Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new SorschiaAppBuilder();
                }

                return _Instance;
            }
        }

        private SorschiaAppBuilder()
        {
            
        }

        public void Build(SorschiaApp app, SorschiaBootstrapper bootstrapper)
        {
            var services = new ServiceCollection();
            bootstrapper.ConfigureServices(services);

            if (!string.IsNullOrWhiteSpace(bootstrapper.BaseDirectory))
            {
                DirectoryResolver.ResolveExistence(bootstrapper.BaseDirectory);
            }

            app.BaseDirectory = bootstrapper.BaseDirectory;
            app.PluginDirectory = bootstrapper.PluginDirectory;

            app.TryIntegrateExternalServices(services);
            app.ServiceProvider = services.BuildServiceProvider();
        }
    }
}
