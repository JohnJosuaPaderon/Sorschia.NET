using Sorschia.Application;
using System.Windows;

namespace Sorschia.DailyTask.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            Bootstrapper.RunBootstrapper();
            SorschiaApp.Build(JsonAppConfigurationLoader.Instance, new SorschiaBootstrapper());
        }
    }
}
