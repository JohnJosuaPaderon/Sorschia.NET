using System.Collections.Generic;

namespace Sorschia.Entity
{
    partial class EntityCollection<T, TIdentifier>
    {
        protected virtual bool UnsafeRemove(T item)
        {
            var result = Source.Remove(item.Id);
            OnRemoved(item);
            return result;
        }

        protected virtual void UnsafeRemove(IEnumerable<T> items)
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
    }
}
