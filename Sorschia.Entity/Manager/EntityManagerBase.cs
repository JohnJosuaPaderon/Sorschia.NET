using Sorschia.Events;

namespace Sorschia.Entity.Manager
{
    public abstract partial class EntityManagerBase<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        public EntityManagerBase(ISorschiaEventManager eventManager)
        {
            _EventManager = eventManager;
            Source = new EntityCollection<T, TIdentifier>();

            if (EventHandlersEnabled)
            {
                Source.Added += Source_Added;
                Source.RangeAdded += Source_RangeAdded;
                Source.Updated += Source_Updated;
                Source.RangeUpdated += Source_RangeUpdated;
                Source.Removed += Source_Removed;
                Source.RangeRemoved += Source_RangeRemoved;
            }
        }

        protected readonly ISorschiaEventManager _EventManager;
        protected IEntityCollection<T, TIdentifier> Source { get; }
        protected bool EventHandlersEnabled => SorschiaEntityConfiguration.EntityEventHandlersEnabled;
    }
}
