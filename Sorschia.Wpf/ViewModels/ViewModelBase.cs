using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Sorschia.Events;
using System.Windows.Input;

namespace Sorschia.ViewModels
{
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
        public ViewModelBase(IEventAggregator eventAggregator)
        {
            _EventAggregator = eventAggregator;
            _AppMessageEvent = eventAggregator.GetEvent<AppMessageEvent>();

            InitializeCommand = new DelegateCommand(Initialize);
            ResetMouseCaptureCommand = new DelegateCommand(ResetMouseCapture);
        }
        
        protected readonly IEventAggregator _EventAggregator;
        protected readonly AppMessageEvent _AppMessageEvent;

        public DelegateCommand ResetMouseCaptureCommand { get; }
        public DelegateCommand InitializeCommand { get; }

        private void ResetMouseCapture()
        {
            Mouse.Capture(null);
        }

        protected virtual void Initialize()
        {
            // TODO: Initialize required components
        }

        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
