using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Sorschia.Application;
using Sorschia.Configuration;
using Sorschia.DailyTask.Notifications;
using Sorschia.ViewModels;

namespace Sorschia.DailyTask.ViewModels
{
    public sealed class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            var connectionStringSource = SorschiaApp.GetService<IConnectionStringSource>();

            AddDTaskRequest = new InteractionRequest<IAddDTaskNotification>();
            AddCommand = new DelegateCommand(Add);
        }

        public InteractionRequest<IAddDTaskNotification> AddDTaskRequest { get; }
        public DelegateCommand AddCommand { get; }

        private void Add()
        {
            AddDTaskRequest.Raise(new AddDTaskNotification());
        }
    }
}
