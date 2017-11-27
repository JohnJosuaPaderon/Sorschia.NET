using Sorschia.Application;
using System.Configuration;
using Sorschia.Extensions;

namespace Sorschia.DailyTask
{
    class SorschiaBootstrapper : SorschiaBootstrapperBase, ISorschiaBootstrapper
    {
        public SorschiaBootstrapper()
        {
            ConfigurationFilePath = ConfigurationManager.AppSettings.GetString("ConfigurationFilePath");
        }
    }
}
