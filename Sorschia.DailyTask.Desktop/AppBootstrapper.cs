using Sorschia.Application;
using Sorschia.Configuration;
using Sorschia.Convention;
using Sorschia.DailyTask.Convention;
using Sorschia.Data;
using Sorschia.Events;
using Sorschia.Extensions;
using System.Configuration;

namespace Sorschia.DailyTask
{
    class AppBootstrapper : SorschiaBootstrapperBase, ISorschiaBootstrapper
    {
        public AppBootstrapper()
        {
            ConfigurationFilePath = ConfigurationManager.AppSettings.GetString("ConfigurationFilePath");
            Services.UseEventDefaults();
                //.UseConnectionStringSource<JsonConnectionStringSource>()
                //.UseSqlServer()
                //.UseJsonConnectionStringSourceFromFileLoader(ConfigurationManager.AppSettings.GetString("ConnectionStringSource"))
                //.UseEntityConventions()
                //.UseDefaultEntityFormatters()
                //.UseSqlServerForDailyTask();
        }
    }
}
