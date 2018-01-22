using System.Collections.Generic;
using System.Linq;

namespace Sorschia.Entity
{
    partial class EntityCollection<T, TIdentifier>
    {
        public T this[TIdentifier id]
        {
            get
            {
                if (Equals(default(TIdentifier), id))
                    return default(T);

                return Source.ContainsKey(id) ? Source[id] : default(T);
            }
            set
            {
                AddUpdate(value);
            }
        }

        public void Add(IEnumerable<T> items)
        {
            if (items != null && items.Any())
            {
                UnsafeAdd(items);
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
                UnsafeAddUpdate(items);
            }
        }

        public bool ContainsId(TIdentifier id)
        {
            if (!Source.Any()) return false;

            return Source.ContainsKey(id);
        }

        public void Remove(IEnumerable<T> items)
        {
            if (IsValid(items))
            {
                UnsafeRemove(items);
            }
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
                UnsafeUpdate(items);
            }
        }
    }
}
