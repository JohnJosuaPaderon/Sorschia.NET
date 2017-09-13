namespace Sorschia.Data
{
    public interface IQueryParameter
    {
        string Name { get; }
        object Value { get; set; }
        bool BindToSource { get; set; }
        string BindingKey { get; set; }
        QueryParameterDirection Direction { get; set; }
    }
}
