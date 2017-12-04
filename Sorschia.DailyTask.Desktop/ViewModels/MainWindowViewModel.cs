using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Mvvm;
using Sorschia.Application;
using Sorschia.Configuration;
using Sorschia.DailyTask.Notifications;

namespace Sorschia.DailyTask.ViewModels
{
    public sealed class MainWindowViewModel : BindableBase
    {
        public MainWindowViewModel()
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
