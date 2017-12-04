using Prism.Commands;
using Prism.Events;
using Sorschia.Application;
using Sorschia.DailyTask.Entity.Manager;
using Sorschia.DailyTask.Notifications;
using Sorschia.Processing;
using Sorschia.ViewModels;
using System.Windows;

namespace Sorschia.DailyTask.ViewModels
{
    public class AddDTaskViewModel : PopupViewModelBase<IAddDTaskNotification>
    {
        public AddDTaskViewModel(IEventAggregator eventAggregator) : base(eventAggregator)
        {
            _DTaskManager = SorschiaApp.GetService<IDTaskManager>();

            SaveCommand = new DelegateCommand(Save);
        }

        private readonly IDTaskManager _DTaskManager;

        public DelegateCommand SaveCommand { get; }

        private async void Save()
        {
            var result = await _DTaskManager.InsertAsync(PopupNotification.DTask.GetSource());

            if (result.Status == ProcessResultStatus.Success)
            {
                MessageBox.Show($"Id : {result.Data?.Id}");
            }
            else
            {
                MessageBox.Show(result.Message);
            }
        }
    }
}
