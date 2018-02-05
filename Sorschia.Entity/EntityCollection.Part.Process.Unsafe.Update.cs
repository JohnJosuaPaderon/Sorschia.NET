using System.Collections.Generic;

namespace Sorschia.Entity
{
    partial class EntityCollection<T, TIdentifier>
    {
        protected virtual void UnsafeUpdate(T item)
        {
            Source[item.Id] = item;
            OnUpdated(item);
        }

        protected virtual void UnsafeUpdate(IEnumerable<T> items)
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
    }
}
