namespace Sorschia.Convention
{
    public sealed class DefaultEntityInfoConfiguration : IEntityInfoConfiguration
    {
        public DefaultEntityInfoConfiguration()
        {
            FieldPrefix = string.Empty;
            ParameterPrefix = "@_";
        }

        public string FieldPrefix { get; }
        public string ParameterPrefix { get; }
    }
}
