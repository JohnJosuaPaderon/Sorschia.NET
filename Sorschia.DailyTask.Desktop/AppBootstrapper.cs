using Sorschia.Application;
using Sorschia.Configuration;
using Sorschia.Convention;
using Sorschia.DailyTask.Convention;
using Sorschia.Data;
using Sorschia.Extensions;
using System.Configuration;

namespace Sorschia.DailyTask
{
    class AppBootstrapper : SorschiaBootstrapperBase, ISorschiaBootstrapper
    {
        public AppBootstrapper()
        {
            ConfigurationFilePath = ConfigurationManager.AppSettings.GetString("ConfigurationFilePath");
            Services
                .UseConnectionStringSource<JsonConnectionStringSource>()
                .UseSqlServer()
                .UseJsonConnectionStringSourceFromFileLoader(ConfigurationManager.AppSettings.GetString("ConnectionStringSource"))
                .UseEntityConventions()
                .UseDefaultEntityFormatters()
                .UseSqlServerForDailyTask();
        }
    }
}
