namespace Sorschia.Data
{
    public abstract class DbQueryParameterBase : IDbQueryParameter
    {
        public DbQueryParameterBase(string name, DbQueryParameterDirection direction, object value)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw SorschiaException.ParameterRequired(nameof(name));
            }

            Name = name;
            Direction = direction;
            Value = value;
        }

        public string Name { get; }
        public DbQueryParameterDirection Direction { get; }
        public object Value { get; set; }
    }
}
