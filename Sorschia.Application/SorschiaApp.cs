using Microsoft.Extensions.DependencyInjection;
using Sorschia.Configurations;
using Sorschia.Utilities;
using System;
using System.Collections.Generic;
using System.Composition;
using System.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Sorschia
{
    public sealed class SorschiaApp
    {
        private const string ASSEMBLY_SEARCH_PATTERN = "*.dll";

        static SorschiaApp()
        {
            Current = new SorschiaApp();
        }

        public static SorschiaApp Current { get; }

        private const string BASE_DIRECTORY_PLACEHOLDER = "<basedir>";

        public static T ResolveService<T>()
        {
            return Current.ServiceProvider.GetService<T>();
        }

        public static string ResolveDirectory(string key)
        {
            return Current.DirectoryProvider[key];
        }

        public static string ResolveFile(string key)
        {
            return Current.FileProvider[key];
        }

        public static void BuildApp(SorschiaBootstrapper bootstrapper)
        {
            var services = new ServiceCollection();
            bootstrapper.ConfigureServices(services);

            if (!string.IsNullOrWhiteSpace(bootstrapper.BaseDirectory))
            {
                DirectoryResolver.ResolveExistence(bootstrapper.BaseDirectory);
            }

            Current.BaseDirectory = bootstrapper.BaseDirectory;
            Current.PluginDirectory = bootstrapper.PluginDirectory;

            Current.DirectoryProvider = new ApplicationDirectoryProvider(Current);
            Current.FileProvider = new ApplicationFileProvider(Current);

            Current.TryIntegrateExternalServices(services);
            Current.ServiceProvider = services.BuildServiceProvider();
        }
        
        private IEnumerable<IServiceIntegrator> ServiceIntegrators { get; set; }

        public IServiceProvider ServiceProvider { get; private set; }
        public ApplicationDirectoryProvider DirectoryProvider { get; private set; }
        public ApplicationFileProvider FileProvider { get; private set; }
        public string BaseDirectory { get; private set; }
        public string PluginDirectory { get; private set; }

        private void ComposeServiceIntegrators()
        {
            if (Directory.Exists(PluginDirectory))
            {
                var configuration = new ContainerConfiguration();
                configuration.WithAssemblies(GetPluginAssemblies());

                using (var container = configuration.CreateContainer())
                {
                    ServiceIntegrators = container.GetExports<IServiceIntegrator>();
                }
            }
        }

        private IEnumerable<Assembly> GetPluginAssemblies()
        {
            return Directory.GetFiles(PluginDirectory, ASSEMBLY_SEARCH_PATTERN, SearchOption.TopDirectoryOnly).Select(AssemblyLoadContext.Default.LoadFromAssemblyPath);
        }

        private void TryIntegrateExternalServices(IServiceCollection services)
        {
            ComposeServiceIntegrators();

            if (ServiceIntegrators != null && ServiceIntegrators.Any())
            {
                foreach (var serviceIntegrator in ServiceIntegrators)
                {
                    serviceIntegrator.Integrate(services);
                }
            }
        }

        public string ResolveRelativePath(string sourcePath)
        {
            if (sourcePath.StartsWith(BASE_DIRECTORY_PLACEHOLDER))
            {
                return sourcePath.Replace(BASE_DIRECTORY_PLACEHOLDER, BaseDirectory);
            }
            else
            {
                return sourcePath;
            }
        }
    }
}
