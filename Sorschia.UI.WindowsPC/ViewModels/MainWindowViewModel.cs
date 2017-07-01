using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Windows;

namespace Sorschia.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        public const string CONTENT_REGION = "ContentRegion";
        public static string InitialContent { get; set; }

        public MainWindowViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            RegionManager = regionManager;
            EventAggregator = eventAggregator;
        }

        private readonly IRegionManager RegionManager;
        private readonly IEventAggregator EventAggregator;

        private string _Title = "Sorschia";
        public string Title
        {
            get { return _Title; }
            set { SetProperty(ref _Title, value); }
        }

        private WindowState _WindowState = WindowState.Maximized;
        public WindowState WindowState
        {
            get { return _WindowState; }
            set { SetProperty(ref _WindowState, value); }
        }

        public void Load()
        {
            RegionManager.RequestNavigate(CONTENT_REGION, InitialContent);
        }
    }
}
