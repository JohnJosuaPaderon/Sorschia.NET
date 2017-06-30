using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

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

        public void Load()
        {
            RegionManager.RequestNavigate(CONTENT_REGION, InitialContent);
        }
    }
}
