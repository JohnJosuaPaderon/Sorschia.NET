namespace Sorschia.Data
{
    public sealed class DbTextQuery : DbQueryBase, IDbQuery
    {
        public DbTextQuery(string text) : base(text, DbQueryType.Text)
        {
        }
    }
}
