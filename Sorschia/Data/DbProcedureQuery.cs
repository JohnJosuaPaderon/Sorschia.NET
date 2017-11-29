namespace Sorschia.Data
{
    public sealed class DbProcedureQuery : DbQueryBase, IDbQuery
    {
        public DbProcedureQuery(string text) : base(text, DbQueryType.StoredProcedure)
        {
        }
    }
}
