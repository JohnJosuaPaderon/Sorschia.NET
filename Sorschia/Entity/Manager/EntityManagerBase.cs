using Sorschia.Application.EventFeeds;
using Sorschia.Events;
using Sorschia.Processing;
using System;
using System.Collections.Generic;

namespace Sorschia.Entity.Manager
{
    public abstract class EntityManagerBase<T, TIdentifier> : ISorschiaEventSubscriber<AppStoppedFeed>
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

        protected IEntityCollection<T, TIdentifier> Source { get; }
        protected readonly ISorschiaEventManager _EventManager;
        protected readonly ISorschiaEvent<AppStoppedFeed> _AppStopped;
        protected bool EventHandlersEnabled => SorschiaEntityConfiguration.EntityEventHandlersEnabled;

        private void Source_Added(object sender, EntityCollectionEventArgs<T, TIdentifier> e)
        {
            OnAdded(e.Data);
        }

        private void Source_RangeAdded(object sender, EntityCollectionRangeEventArgs<T, TIdentifier> e)
        {
            OnAdded(e.DataCollection);
        }

        private void Source_Updated(object sender, EntityCollectionEventArgs<T, TIdentifier> e)
        {
            OnUpdated(e.Data);
        }

        private void Source_RangeUpdated(object sender, EntityCollectionRangeEventArgs<T, TIdentifier> e)
        {
            OnUpdated(e.DataCollection);
        }

        private void Source_Removed(object sender, EntityCollectionEventArgs<T, TIdentifier> e)
        {
            OnDeleted(e.Data);
        }

        private void Source_RangeRemoved(object sender, EntityCollectionRangeEventArgs<T, TIdentifier> e)
        {
            OnDeleted(e.DataCollection);
        }

        protected virtual void OnAdded(T entity)
        {
            // TODO: 
        }

        protected virtual void OnAdded(IEnumerable<T> entities)
        {
            // TODO:
        }

        protected virtual void OnUpdated(T entity)
        {
            // TODO:
        }

        protected virtual void OnUpdated(IEnumerable<T> entities)
        {
            // TODO:
        }

        protected virtual void OnDeleted(T entity)
        {
            // TODO:
        }

        protected virtual void OnDeleted(IEnumerable<T> entities)
        {
            // TODO:
        }

        protected IProcessResult<T> TryAdd(IProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Add(result.Data));
        }

        protected IAggregateProcessResult<T> TryAdd(IAggregateProcessResult<T> result)
        {
            return TryInvoke(result, entity => Source.Add(entity));
        }

        protected IEnumerableProcessResult<T> TryAdd(IEnumerableProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Add(result.DataCollection));
        }

        protected IProcessResult<T> TryAddUpdate(IProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.AddUpdate(result.Data));
        }

        protected IEnumerableProcessResult<T> TryAddUpdate(IEnumerableProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.AddUpdate(result.DataCollection));
        }

        protected IAggregateProcessResult<T> TryAddUpdate(IAggregateProcessResult<T> result)
        {
            return TryInvoke(result, entity => Source.AddUpdate(entity));
        }

        protected IProcessResult<T> TryRemove(IProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Remove(result.Data));
        }

        protected IEnumerableProcessResult<T> TryRemove(IEnumerableProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Remove(result.DataCollection));
        }

        protected IAggregateProcessResult<T> TryRemove(IAggregateProcessResult<T> result)
        {
            return TryInvoke(result, entity => Source.Remove(entity));
        }

        protected IProcessResult<T> TryUpdate(IProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Update(result.Data));
        }

        protected IEnumerableProcessResult<T> TryUpdate(IEnumerableProcessResult<T> result)
        {
            return TryInvoke(result, () => Source.Update(result.DataCollection));
        }

        protected IAggregateProcessResult<T> TryUpdate(IAggregateProcessResult<T> result)
        {
            return TryInvoke(result, entity => Source.Update(entity));
        }

        protected IProcessResult<T> TryInvoke(IProcessResult<T> result, Action callback)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                callback?.Invoke();
            }

            return result;
        }

        protected IEnumerableProcessResult<T> TryInvoke(IEnumerableProcessResult<T> result, Action callback)
        {
            if (result.Status == ProcessResultStatus.Success)
            {
                callback?.Invoke();
            }

            return result;
        }

        protected IAggregateProcessResult<T> TryInvoke(IAggregateProcessResult<T> aggregateResult, Action<T> callback)
        {
            foreach (var result in aggregateResult.Results)
            {
                if (result.Status == ProcessResultStatus.Success)
                {
                    callback?.Invoke(result.Data);
                }
            }

            return aggregateResult;
        }
        
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
