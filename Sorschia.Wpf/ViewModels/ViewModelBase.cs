using Sorschia.Events;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using System.Windows.Input;

namespace Sorschia.ViewModels
{
    public abstract class ViewModelBase : BindableBase
    {
        public ViewModelBase(IEventAggregator eventAggregator)
        {
            _EventAggregator = eventAggregator;
            _WindowTitleEvent = eventAggregator.GetEvent<WindowTitleEvent>();

            InitializeCommand = new DelegateCommand(Initialize);
            ResetMouseCaptureCommand = new DelegateCommand(ResetMouseCapture);
        }

        protected readonly IEventAggregator _EventAggregator;
        protected readonly WindowTitleEvent _WindowTitleEvent;

        public DelegateCommand ResetMouseCaptureCommand { get; }
        public DelegateCommand InitializeCommand { get; }

        private void ResetMouseCapture()
        {
            Mouse.Capture(null);
        }

        protected virtual void Initialize()
        {

        }
    }
}
