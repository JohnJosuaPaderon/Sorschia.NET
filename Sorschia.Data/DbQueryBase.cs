namespace Sorschia.Data
{
    public abstract class DbQueryBase : IDbQuery
    {
        public DbQueryBase(string text, DbQueryType type)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw SorschiaException.ParameterRequired(nameof(text));
            }

            Parameters = new DbQueryParameterCollection();
            Type = type;
            Text = text;
        }

        public string Text { get; }
        public DbQueryType Type { get; }
        public IDbQueryParameterCollection Parameters { get; }
    }
}
