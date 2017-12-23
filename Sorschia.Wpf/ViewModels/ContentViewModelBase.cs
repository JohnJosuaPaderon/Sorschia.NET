using Prism.Events;
using Prism.Regions;

namespace Sorschia.ViewModels
{
    public abstract class ContentViewModelBase : ViewModelBase
    {
        public ContentViewModelBase(IRegionManager regionManager, IEventAggregator eventAggregator) : base(eventAggregator)
        {
            _RegionManager = regionManager;
        }

        protected readonly IRegionManager _RegionManager;
    }
}
