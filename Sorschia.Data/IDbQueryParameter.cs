namespace Sorschia.Data
{
    public interface IDbQueryParameter
    {
        string Name { get; }
        object Value { get; set; }
        DbQueryParameterDirection Direction { get; }
        DbQueryParameterType Type { get; }
    }
}
