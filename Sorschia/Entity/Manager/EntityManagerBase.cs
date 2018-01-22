using Sorschia.Application.EventFeeds;
using Sorschia.Events;

namespace Sorschia.Entity.Manager
{
    public abstract partial class EntityManagerBase<T, TIdentifier> : ISorschiaEventSubscriber<AppStoppedFeed>
        where T : IEntity<TIdentifier>
    {
        public EntityManagerBase(ISorschiaEventManager eventManager)
        {
            _EventManager = eventManager;
            Source = new EntityCollection<T, TIdentifier>();

            if (EventHandlersEnabled)
            {
                _AppStopped = eventManager.GetEvent<AppStoppedFeed>();
                eventManager.Subscribe(_AppStopped, this);
                Source.Added += Source_Added;
                Source.RangeAdded += Source_RangeAdded;
                Source.Updated += Source_Updated;
                Source.RangeUpdated += Source_RangeUpdated;
                Source.Removed += Source_Removed;
                Source.RangeRemoved += Source_RangeRemoved;
            }
        }

        protected readonly ISorschiaEventManager _EventManager;
        protected readonly ISorschiaEvent<AppStoppedFeed> _AppStopped;
        protected IEntityCollection<T, TIdentifier> Source { get; }
        protected bool EventHandlersEnabled => SorschiaEntityConfiguration.EntityEventHandlersEnabled;
        
        public virtual void CaptureEventFeed(ISorschiaEvent<AppStoppedFeed> sorschiaEvent, AppStoppedFeed feed)
        {
            _EventManager.Unsubscribe(_AppStopped, this);
            if (EventHandlersEnabled)
            {
                Source.Added -= Source_Added;
                Source.RangeAdded -= Source_RangeAdded;
                Source.Updated -= Source_Updated;
                Source.RangeUpdated -= Source_RangeUpdated;
                Source.Removed -= Source_Removed;
                Source.RangeRemoved -= Source_RangeRemoved;
            }
        }
    }
}
