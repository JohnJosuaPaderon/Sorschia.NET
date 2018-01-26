using Sorschia.Application;
using System.Configuration;
using Sorschia.Extensions;

namespace MyDayManager
{
    class AppBootstrapper : SorschiaBootstrapperBase, ISorschiaBootstrapper
    {
        public AppBootstrapper()
            : base(ConfigurationManager.AppSettings.GetString("ConfigurationFilePath"), ConfigurationManager.AppSettings.GetString("ServiceIntegratorsDirectory"))
        {
        }
    }
}
