namespace Sorschia.Data
{
    public interface IDbQuery
    {
        string Text { get; }
        DbQueryType Type { get; }
        IDbQueryParameterCollection Parameters { get; }
    }
}
