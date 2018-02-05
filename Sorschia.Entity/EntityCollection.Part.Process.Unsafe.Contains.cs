namespace Sorschia.Entity
{
    partial class EntityCollection<T, TIdentifier>
    {
        protected virtual bool UnsafeContains(T item)
        {
            return Source.ContainsKey(item.Id);
        }
    }
}
