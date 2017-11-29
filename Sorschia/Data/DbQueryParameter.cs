namespace Sorschia.Data
{
    public class DbQueryParameter : DbQueryParameterBase, IDbQueryParameter
    {
        public DbQueryParameter(string name, DbQueryParameterDirection direction, object value) : base(name, direction, value)
        {
        }
    }
}
