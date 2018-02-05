using System.Windows;

namespace MyDayManager.Desktop
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            //var appConfigurationLoader = ExternalAppConfigurationLoader.GetExternal(ConfigurationManager.AppSettings.GetString("AppConfigurationLoaderExternal"));
            //SorschiaApp.Build(appConfigurationLoader, new AppBootstrapper());
            //SorschiaApp.StartCurrent();
            //new UiBootstrapper().Run();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            //SorschiaApp.StopCurrent();
        }
    }
}
