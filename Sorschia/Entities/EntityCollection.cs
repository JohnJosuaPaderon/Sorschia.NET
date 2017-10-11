using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sorschia.Entities
{
    public class EntityCollection<T, TIdentifier> : IEntityCollection<T, TIdentifier>
        where T : IEntity<TIdentifier>
    {
        public EntityCollection()
        {
            Source = new Dictionary<TIdentifier, T>();
        }
        
        public EntityCollection(IEnumerable<T> initialContent)
        {
            if (initialContent == null && !initialContent.Any()) return;

            Source = initialContent.ToDictionary(e => e.Id);
        }
        
        protected Dictionary<TIdentifier, T> Source { get; }
        
        public T this[TIdentifier id]
        {
            get
            {
                if (Equals(default(TIdentifier), id)) return default(T);

                if (Source.ContainsKey(id))
                {
                    return Source[id];
                }
                else
                {
                    return default(T);
                }
            }
            set
            {
                AddUpdate(value);
            }
        }
        
        public int Count => Source.Count;

        public bool IsReadOnly => false;

        public event EntityCollectionEventHandler<T, TIdentifier> Added;
        public event EntityCollectionEventHandler<T, TIdentifier> Removed;
        public event EntityCollectionEventHandler<T, TIdentifier> Updated;
        public event EntityCollectionEventHandler Cleared;
        public event EntityCollectionRangeEventHandler<T, TIdentifier> RangeAdded;
        public event EntityCollectionRangeEventHandler<T, TIdentifier> RangeRemoved;
        public event EntityCollectionRangeEventHandler<T, TIdentifier> RangeUpdated;
        
        public void Add(T item)
        {
            if (IsDefault(item)) return;
            if (Source.ContainsKey(item.Id)) return;

            UnsafeAdd(item);
        }

        public void Add(IEnumerable<T> items)
        {
            if (items != null && items.Any())
            {
                UnsafeAddRange(items);
            }
        }
        
        public void AddUpdate(T item)
        {
            if (IsDefault(item)) return;

            if (Source.ContainsKey(item.Id))
            {
                UnsafeUpdate(item);
            }
            else
            {
                UnsafeAdd(item);
            }
        }

        public void AddUpdate(IEnumerable<T> items)
        {
            if (IsValid(items))
            {
                UnsafeAddUpdateRange(items);
            }
        }
        
        public void Clear()
        {
            if (!Source.Any()) return;

            Source.Clear();
            OnCleared();
        }
        
        public bool Contains(T item)
        {
            if (IsDefault(item)) return false;
            if (!Source.Any()) return false;

            return UnsafeContains(item);
        }

        public bool ContainsId(TIdentifier id)
        {
            if (!Source.Any()) return false;

            return Source.ContainsKey(id);
        }
        
        public void CopyTo(T[] array, int arrayIndex)
        {
            Source.Values.CopyTo(array, arrayIndex);
        }
        
        public IEnumerator<T> GetEnumerator()
        {
            return Source.Values.GetEnumerator();
        }
        
        protected virtual bool IsDefault(T item)
        {
            return Equals(default(T), item);
        }

        protected virtual bool IsValid(IEnumerable<T> items)
        {
            return items != null && items.Any();
        }
        
        protected virtual void OnAdded(T item)
        {
            Added?.Invoke(this, new EntityCollectionEventArgs<T, TIdentifier>(EntityCollectionOperation.Add, item));
        }

        protected virtual void OnAdded(IEnumerable<T> items)
        {
            RangeAdded?.Invoke(this, new EntityCollectionRangeEventArgs<T, TIdentifier>(EntityCollectionOperation.Add, items));
        }
        
        protected virtual void OnCleared()
        {
            Cleared?.Invoke(this, new EntityCollectionEventArgs(EntityCollectionOperation.Clear));
        }
        
        protected virtual void OnRemoved(T item)
        {
            Removed?.Invoke(this, new EntityCollectionEventArgs<T, TIdentifier>(EntityCollectionOperation.Remove, item));
        }

        protected virtual void OnRemoved(IEnumerable<T> items)
        {
            RangeRemoved?.Invoke(this, new EntityCollectionRangeEventArgs<T, TIdentifier>(EntityCollectionOperation.Remove, items));
        }
        
        protected virtual void OnUpdated(T item)
        {
            Updated?.Invoke(this, new EntityCollectionEventArgs<T, TIdentifier>(EntityCollectionOperation.Update, item));
        }

        protected virtual void OnUpdated(IEnumerable<T> items)
        {
            RangeUpdated?.Invoke(this, new EntityCollectionRangeEventArgs<T, TIdentifier>(EntityCollectionOperation.Update, items));
        }
        
        public bool Remove(T item)
        {
            if (IsDefault(item)) return false;
            if (!UnsafeContains(item)) return false;

            return UnsafeRemove(item);
        }

        public void Remove(IEnumerable<T> items)
        {
            if (IsValid(items))
            {
                UnsafeRemoveRange(items);
            }
        }
        
        protected virtual void UnsafeAdd(T item)
        {
            Source.Add(item.Id, item);
            OnAdded(item);
        }

        protected virtual void UnsafeAddRange(IEnumerable<T> items)
        {
            var list = new List<T>();

            foreach (var item in items)
            {
                if (!(IsDefault(item) || Source.ContainsKey(item.Id)))
                {
                    Source.Add(item.Id, item);
                    list.Add(item);
                }
            }

            OnAdded(list);
        }

        protected virtual void UnsafeAddUpdateRange(IEnumerable<T> items)
        {
            var addedList = new List<T>();
            var updatedList = new List<T>();

            foreach (var item in items)
            {
                if (!IsDefault(item))
                {
                    if (Source.ContainsKey(item.Id))
                    {
                        Source[item.Id] = item;
                        updatedList.Add(item);
                    }
                    else
                    {
                        Source.Add(item.Id, item);
                        addedList.Add(item);
                    }
                }
            }

            if (addedList.Any())
            {
                OnAdded(addedList);
            }

            if (updatedList.Any())
            {
                OnUpdated(updatedList);
            }
        }
        
        protected virtual bool UnsafeContains(T item)
        {
            return Source.ContainsKey(item.Id);
        }
        
        protected virtual bool UnsafeRemove(T item)
        {
            var result = Source.Remove(item.Id);
            OnRemoved(item);
            return result;
        }

        protected virtual void UnsafeRemoveRange(IEnumerable<T> items)
        {
            var list = new List<T>();

            foreach (var item in items)
            {
                if (!IsDefault(item) && Source.ContainsKey(item.Id))
                {
                    Source.Remove(item.Id);
                    list.Add(item);
                }
            }

            OnRemoved(list);
        }
        
        protected virtual void UnsafeUpdate(T item)
        {
            Source[item.Id] = item;
            OnUpdated(item);
        }

        protected virtual void UnsafeUpdateRange(IEnumerable<T> items)
        {
            var list = new List<T>();

            foreach (var item in items)
            {
                if (!IsDefault(item) && Source.ContainsKey(item.Id))
                {
                    Source[item.Id] = item;
                    list.Add(item);
                }
            }

            OnUpdated(list);
        }
        
        public void Update(T item)
        {
            if (IsDefault(item)) return;
            if (!Source.Any()) return;

            UnsafeUpdate(item);
        }

        public void Update(IEnumerable<T> items)
        {
            if (IsValid(items))
            {
                UnsafeUpdateRange(items);
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
