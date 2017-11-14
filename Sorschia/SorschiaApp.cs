using Microsoft.Extensions.DependencyInjection;
using Sorschia.Configurations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Sorschia
{
    public sealed class SorschiaApp
    {
        private const string BASE_DIRECTORY_PLACEHOLDER = "<basedir>";

        static SorschiaApp()
        {
            Current = new SorschiaApp();
            _Builder = SorschiaAppBuilder.Instance;
        }

        private static readonly SorschiaAppBuilder _Builder;

        public static SorschiaApp Current { get; }

        public static T ResolveService<T>()
        {
            return Current.ServiceProvider.GetService<T>();
        }

        public static T ResolveRequiredService<T>()
        {
            var service = Current.ServiceProvider.GetService<T>();

            if (Equals(service, default(T)))
            {
                throw SorschiaException.ServiceRequired(typeof(T).Name);
            }

            return service;
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
            _Builder.Build(Current, bootstrapper);
        }

        private SorschiaApp()
        {
            _ServiceIntegratorComposer = new ServiceIntegratorComposer(this);
            DirectoryProvider = new ApplicationDirectoryProvider(this);
            FileProvider = new ApplicationFileProvider(this);
        }

        private readonly ServiceIntegratorComposer _ServiceIntegratorComposer;
        
        private IEnumerable<IServiceIntegrator> ServiceIntegrators { get; set; }

        public IServiceProvider ServiceProvider { get; internal set; }
        public ApplicationDirectoryProvider DirectoryProvider { get; }
        public ApplicationFileProvider FileProvider { get; }
        public string BaseDirectory { get; internal set; }
        public string PluginDirectory { get; internal set; }
        
        internal void TryIntegrateExternalServices(IServiceCollection services)
        {
            ServiceIntegrators = _ServiceIntegratorComposer.Compose();

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
