using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Sorschia.Application;
using Sorschia.Application.EventFeeds;
using Sorschia.Configuration;
using Sorschia.DailyTask.Notifications;
using Sorschia.Events;
using Sorschia.ViewModels;
using System.Windows;

namespace Sorschia.DailyTask.ViewModels
{
    public sealed class MainWindowViewModel : ViewModelBase, ISorschiaEventSubscriber<AppStoppedFeed>
    {
        public MainWindowViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            var connectionStringSource = SorschiaApp.GetService<IConnectionStringSource>();
            _EventManager = SorschiaApp.GetService<ISorschiaEventManager>();
            var stoppedEvent = _EventManager.GetEvent<AppStoppedFeed>();
            _EventManager.Subscribe(stoppedEvent, this);

            AddDTaskRequest = new InteractionRequest<IAddDTaskNotification>();
            AddCommand = new DelegateCommand(Add);
        }

        private readonly ISorschiaEventManager _EventManager;

        public InteractionRequest<IAddDTaskNotification> AddDTaskRequest { get; }
        public DelegateCommand AddCommand { get; }

        private void Add()
        {
            AddDTaskRequest.Raise(new AddDTaskNotification());
        }

        public void CaptureEventFeed(ISorschiaEvent<AppStoppedFeed> sorschiaEvent, AppStoppedFeed feed)
        {
            MessageBox.Show(feed.Session.Id.ToString());
        }
    }
}
