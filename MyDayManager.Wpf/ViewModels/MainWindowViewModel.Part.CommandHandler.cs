using MyDayManager.Views;

namespace MyDayManager.ViewModels
{
    partial class MainWindowViewModel
    {
        protected override void Initialize()
        {
            _TitleBarTextEvent.Change(VERSION);
            _AppMessageEvent.Information(VERSION);
            _RegionManager.RequestNavigate(RegionName, nameof(MainView));
        }
    }
}
