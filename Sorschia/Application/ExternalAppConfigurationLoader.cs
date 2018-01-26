using System.Composition.Hosting;
using System.Runtime.Loader;

namespace Sorschia.Application
{
    public class ExternalAppConfigurationLoader
    {
        public static IAppConfigurationLoader GetExternal(string assemblyFilePath)
        {
            var configuration = new ContainerConfiguration()
                .WithAssembly(AssemblyLoadContext.Default.LoadFromAssemblyPath(assemblyFilePath));

            using (var container = configuration.CreateContainer())
            {
                var result = container.GetExport<IAppConfigurationLoaderExternal>();
                return result?.GetExternal() ?? throw SorschiaException.AppFailure("Failed to access Application Configuration Loader.");
            }
        }
    }
}
