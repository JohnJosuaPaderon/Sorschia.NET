using Sorschia.Entities;

namespace Sorschia.Convention
{
    public sealed class SqlServerEntityInfoConfiguration : IEntityInfoConfiguration
    {
        public SqlServerEntityInfoConfiguration()
        {
            FieldPrefix = string.Empty;
            ParameterPrefix = "@_";
        }

        public string FieldPrefix { get; }
        public string ParameterPrefix { get; }
    }
}
