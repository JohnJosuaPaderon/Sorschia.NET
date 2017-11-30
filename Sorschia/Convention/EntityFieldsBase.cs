namespace Sorschia.Convention
{
    public abstract class EntityFieldsBase : IEntityFields
    {
        public EntityFieldsBase(IEntityFieldFormatter formatter)
        {
            _Formatter = formatter;

            Id = _Formatter.Format(nameof(Id));
        }

        protected readonly IEntityFieldFormatter _Formatter;
        
        public string Id { get; }
    }
}
