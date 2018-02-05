namespace Sorschia.Data
{
    public interface IDbQueryParameterCollectionValidator
    {
        void ValidateParameterName(string parameterName);
        void ValidateParameter(IDbQueryParameter parameter);
    }
}
