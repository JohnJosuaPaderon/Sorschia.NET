using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Sorschia.Entity
{
    partial class EntityCollection<T, TIdentifier>
    {
        public void Add(T item)
        {
            if (IsDefault(item)) return;
            if (Source.ContainsKey(item.Id)) return;

            UnsafeAdd(item);
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

        public void CopyTo(T[] array, int arrayIndex)
        {
            Source.Values.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return Source.Values.GetEnumerator();
        }

        public bool Remove(T item)
        {
            if (IsDefault(item)) return false;
            if (!UnsafeContains(item)) return false;

            return UnsafeRemove(item);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
