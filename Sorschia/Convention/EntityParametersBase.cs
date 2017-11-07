namespace Sorschia.Convention
{
    public abstract class EntityParametersBase : IEntityParameters
    {
        public EntityParametersBase(IEntityInfoConfiguration configuration)
        {
            _Configuration = configuration;

            Id = AppendPrefix(nameof(Id));
        }

        protected readonly IEntityInfoConfiguration _Configuration;

        public string Id { get; }

        protected string AppendPrefix(string baseText)
        {
            return $"{_Configuration.ParameterPrefix}{baseText}";
        }
    }
}
