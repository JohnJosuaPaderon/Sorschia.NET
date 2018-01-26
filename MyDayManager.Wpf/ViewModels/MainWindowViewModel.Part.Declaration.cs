using MaterialDesignThemes.Wpf;
using Sorschia.Events;

namespace MyDayManager.ViewModels
{
    partial class MainWindowViewModel
    {
        static MainWindowViewModel()
        {
            RegionName = "MainWindowRegion";
        }

        public static string RegionName { get; }

        private readonly WindowTitleBarTextEvent _TitleBarTextEvent;

        private SnackbarMessageQueue _MessageQueue;
        public SnackbarMessageQueue MessageQueue
        {
            get { return _MessageQueue; }
            set { SetProperty(ref _MessageQueue, value); }
        }

        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }
    }
}
