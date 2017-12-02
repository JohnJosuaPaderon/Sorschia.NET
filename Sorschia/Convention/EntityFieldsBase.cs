namespace Sorschia.Convention
{
    public abstract class EntityFieldsBase : IEntityFields
    {
        public EntityFieldsBase(IEntityFieldFormatter formatter)
        {
            Id = formatter.Format(nameof(Id));
        }
        
        public string Id { get; }
    }
}
