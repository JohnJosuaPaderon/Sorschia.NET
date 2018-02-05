using System.Collections.Generic;
using System.Linq;

namespace Sorschia.Entity
{
    partial class EntityCollection<T, TIdentifier>
    {
        protected virtual void UnsafeAddUpdate(IEnumerable<T> items)
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
    }
}
