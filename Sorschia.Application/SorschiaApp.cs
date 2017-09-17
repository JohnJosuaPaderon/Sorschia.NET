using Microsoft.Extensions.DependencyInjection;
using Sorschia.Utilities;
using System;

namespace Sorschia
{
    public sealed class SorschiaApp
    {
        static SorschiaApp()
        {
            Current = new SorschiaApp();
        }

        public static SorschiaApp Current { get; }

        public static T Resolve<T>()
        {
            return Current.ServiceProvider.GetService<T>();
        }

        public static void BuildApp(SorschiaBootstrapper bootstrapper)
        {
            var services = new ServiceCollection();
            bootstrapper.ConfigureServices(services);

            if (!string.IsNullOrWhiteSpace(bootstrapper.BaseDirectory))
            {
                DirectoryResolver.Resolve(bootstrapper.BaseDirectory);
            }

            Current.ServiceProvider = services.BuildServiceProvider();
            Current.BaseDirectory = bootstrapper.BaseDirectory;
        }

        public IServiceProvider ServiceProvider { get; private set; }
        public string BaseDirectory { get; private set; }
    }
}
