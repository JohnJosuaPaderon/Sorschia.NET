using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows.Input;

namespace Sorschia.ViewModels
{
    public abstract class ViewModelBase : BindableBase, INavigationAware
    {
        public ViewModelBase(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            _EventAggregator = eventAggregator;

            InitializeCommand = new DelegateCommand(Initialize);
            ResetMouseCaptureCommand = new DelegateCommand(ResetMouseCapture);
        }

        protected readonly IRegionManager _RegionManager;
        protected readonly IEventAggregator _EventAggregator;

        public DelegateCommand ResetMouseCaptureCommand { get; }
        public DelegateCommand InitializeCommand { get; }

        private void ResetMouseCapture()
        {
            Mouse.Capture(null);
        }

        protected virtual void Initialize()
        {

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
