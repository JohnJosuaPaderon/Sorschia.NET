using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Runtime.Loader;

namespace Sorschia.Application
{
    public abstract class SorschiaBootstrapperBase
    {
        private const string SEARCH_PATTERN = "*.dll";

        public SorschiaBootstrapperBase(string configurationFilePath, string serviceIntegratorsDirectory)
        {
            Services = new ServiceCollection();
            ConfigurationFilePath = configurationFilePath;
            ServiceIntegratorsDirectory = serviceIntegratorsDirectory;
        }

        public IServiceCollection Services { get; }
        public string ConfigurationFilePath { get; }
        public string ServiceIntegratorsDirectory { get; }

        public virtual void IntegrateServices()
        {
            if (string.IsNullOrWhiteSpace(ServiceIntegratorsDirectory))
            {
                throw SorschiaException.PropertyRequired(nameof(ServiceIntegratorsDirectory));
            }
            else if (!File.Exists(ServiceIntegratorsDirectory))
            {
                throw SorschiaException.FileNotFound(ServiceIntegratorsDirectory);
            }

            var serviceIntegrators = Compose();

            if (serviceIntegrators != null && serviceIntegrators.Any())
            {
                foreach (var serviceIntegrator in serviceIntegrators)
                {
                    serviceIntegrator.Integrate(Services);
                }
            }
        }

        private IEnumerable<IServiceIntegrator> Compose()
        {
            var configuration = new ContainerConfiguration()
                .WithAssemblies(GetAssemblyFiles().Select(AssemblyLoadContext.Default.LoadFromAssemblyPath));

            using (var container = configuration.CreateContainer())
            {
                return container.GetExports<IServiceIntegrator>();
            }
        }

        private string[] GetAssemblyFiles()
        {
            return Directory.GetFiles(ServiceIntegratorsDirectory, SEARCH_PATTERN, SearchOption.TopDirectoryOnly);
        }
    }
}
