namespace Sorschia.Data
{
    public class DbQueryParameter : DbQueryParameterBase, IDbQueryParameter
    {
        public DbQueryParameter(string name, DbQueryParameterDirection direction, DbQueryParameterType type, object value) : base(name, direction, type, value)
        {
        }
    }
}
