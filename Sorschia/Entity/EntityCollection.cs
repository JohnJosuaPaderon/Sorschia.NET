using System.Collections.Generic;
using System.Linq;

namespace Sorschia.Entity
{
    public partial class EntityCollection<T, TIdentifier> : IEntityCollection<T, TIdentifier>
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
        
        protected virtual bool IsDefault(T item)
        {
            return Equals(default(T), item);
        }

        protected virtual bool IsValid(IEnumerable<T> items)
        {
            return items != null && items.Any();
        }
    }
}
