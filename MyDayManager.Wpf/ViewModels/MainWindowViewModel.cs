using MaterialDesignThemes.Wpf;
using Prism.Events;
using Prism.Regions;
using Sorschia.Events;
using Sorschia.ViewModels;

namespace MyDayManager.ViewModels
{
    internal sealed partial class MainWindowViewModel : ContentViewModelBase
    {
        private const string VERSION = "MyDay Manager V.1.0.0";

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
            _MessageQueue = new SnackbarMessageQueue(new System.TimeSpan(0, 0, 1));
            _TitleBarTextEvent = eventAggregator.GetEvent<WindowTitleBarTextEvent>();
            _AppMessageEvent.Subscribe(AppMessageChanged);
            _TitleBarTextEvent.Subscribe(TitleBarTextChanged);
        }
    }
}
