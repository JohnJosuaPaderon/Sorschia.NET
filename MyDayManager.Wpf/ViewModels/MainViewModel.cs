using Prism.Events;
using Prism.Regions;
using Sorschia.ViewModels;

namespace MyDayManager.ViewModels
{
    public class MainViewModel : ContentViewModelBase
    {
        public MainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator) : base(regionManager, eventAggregator)
        {
        }
    }
}
