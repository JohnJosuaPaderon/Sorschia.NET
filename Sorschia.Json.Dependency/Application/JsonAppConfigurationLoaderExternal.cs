using System.Composition;

namespace Sorschia.Application
{
    [Export(typeof(IAppConfigurationLoaderExternal))]
    public sealed class JsonAppConfigurationLoaderExternal : IAppConfigurationLoaderExternal
    {
        public IAppConfigurationLoader GetExternal()
        {
            return JsonAppConfigurationLoader.Instance;
        }
    }
}
