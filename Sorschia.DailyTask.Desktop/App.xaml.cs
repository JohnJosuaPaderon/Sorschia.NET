using Sorschia.Application;
using Sorschia.Application.EventFeeds;
using Sorschia.Events;
using System.Windows;

namespace Sorschia.DailyTask.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application, ISorschiaEventSubscriber<AppStartedFeed>, ISorschiaEventSubscriber<AppStoppedFeed>
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            SorschiaApp.Build(JsonAppConfigurationLoader.Instance, new AppBootstrapper());
            var eventManager = SorschiaApp.GetService<ISorschiaEventManager>();
            var appStartEvent = eventManager.GetEvent<AppStartedFeed>();
            var appStoppedEvent = eventManager.GetEvent<AppStoppedFeed>();
            eventManager.Subscribe(appStartEvent, this);
            eventManager.Subscribe(appStoppedEvent, this);
            SorschiaApp.StartCurrent();
            Bootstrapper.RunBootstrapper();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            SorschiaApp.StopCurrent();
        }

        public void CaptureEventFeed(ISorschiaEvent<AppStartedFeed> sorschiaEvent, AppStartedFeed feed)
        {
            MessageBox.Show(feed.Session.Id.ToString());
        }

        public void CaptureEventFeed(ISorschiaEvent<AppStoppedFeed> sorschiaEvent, AppStoppedFeed feed)
        {
            MessageBox.Show(feed.Session.Id.ToString());
        }
    }
}
