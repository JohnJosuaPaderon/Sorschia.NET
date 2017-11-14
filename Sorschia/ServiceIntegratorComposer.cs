using System.Collections.Generic;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Sorschia
{
    internal sealed class ServiceIntegratorComposer
    {
        private const string ASSEMBLY_SEARCH_PATTERN = "*.dll";

        public ServiceIntegratorComposer(SorschiaApp app)
        {
            _App = app;
        }

        private readonly SorschiaApp _App;

        private IEnumerable<Assembly> GetPluginAssemblies()
        {
            return Directory.GetFiles(_App.PluginDirectory, ASSEMBLY_SEARCH_PATTERN, SearchOption.TopDirectoryOnly).Select(AssemblyLoadContext.Default.LoadFromAssemblyPath);
        }

        public IEnumerable<IServiceIntegrator> Compose()
        {
            if (Directory.Exists(_App.PluginDirectory))
            {
                var configuration = new ContainerConfiguration();
                configuration.WithAssemblies(GetPluginAssemblies());

                using (var container = configuration.CreateContainer())
                {
                    return container.GetExports<IServiceIntegrator>();
                }
            }
            else
            {
                return null;
            }
        }
    }
}
