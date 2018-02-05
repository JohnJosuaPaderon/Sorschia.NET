namespace Sorschia.Data
{
    public sealed class DbQueryParameterCollection : DbQueryParameterCollectionBase, IDbQueryParameterCollection
    {
        public DbQueryParameterCollection() : base(DbQueryParameterCollectionValidator.Instance, DbQueryParameterCollectionMessageComposer.Instance)
        {
        }
    }
}
