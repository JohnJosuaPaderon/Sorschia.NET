using Sorschia.Entity;
using Sorschia.Entity.Manager;
using Sorschia.Events;
using Sorschia.Processing;

namespace MyDayManager.Entity.Manager
{
    public abstract class CoreEntityManagerBase<T, TIdentifier> : SqlEntityManagerBase<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        public CoreEntityManagerBase(ISorschiaEventManager eventManager, IProcessContextFactory contextFactory) : base(eventManager, contextFactory)
        {
        }
    }
}
