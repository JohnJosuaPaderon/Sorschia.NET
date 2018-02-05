namespace Sorschia.Data
{
    public interface IDbQueryParameterCollectionMessageComposer
    {
        string ComposeParameterNameExists(string parameterName);
        string ComposeParameterNotFound(string parameterName);
    }
}
