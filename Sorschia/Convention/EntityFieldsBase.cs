using Sorschia.Entities;

namespace Sorschia.Convention
{
    public abstract class EntityFieldsBase : IEntityFields
    {
        public EntityFieldsBase(IEntityInfoConfiguration configuration)
        {
            _Configuration = configuration;

            Id = AppendPrefix(nameof(Id));
        }

        protected readonly IEntityInfoConfiguration _Configuration;
        
        public string Id { get; }

        protected string AppendPrefix(string baseText)
        {
            return $"{_Configuration.FieldPrefix}{baseText}";
        }
    }
}
