using System.Collections.Generic;

namespace Sorschia.Entity
{
    partial class EntityCollection<T, TIdentifier>
    {
        protected virtual void UnsafeAdd(T item)
        {
            Source.Add(item.Id, item);
            OnAdded(item);
        }

        protected virtual void UnsafeAdd(IEnumerable<T> items)
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
    }
}
