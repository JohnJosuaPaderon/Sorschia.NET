namespace Sorschia.Data
{
    public abstract class DbQueryParameterBase : IDbQueryParameter
    {
        public DbQueryParameterBase(string name, DbQueryParameterDirection direction, DbQueryParameterType type, object value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw SorschiaException.ParameterRequired(nameof(name));
            }

            Name = name;
            Direction = direction;
            Type = type;
            Value = value;
        }

        public string Name { get; }
        public DbQueryParameterDirection Direction { get; }
        public DbQueryParameterType Type { get; }
        public object Value { get; set; }
    }
}
