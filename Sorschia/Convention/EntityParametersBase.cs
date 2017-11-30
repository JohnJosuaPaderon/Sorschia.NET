namespace Sorschia.Convention
{
    public abstract class EntityParametersBase : IEntityParameters
    {
        public EntityParametersBase(IEntityParameterFormatter formatter)
        {
            _Formatter = formatter;

            Id = _Formatter.Format(nameof(Id));
        }

        protected readonly IEntityParameterFormatter _Formatter;

        public string Id { get; }
    }
}
