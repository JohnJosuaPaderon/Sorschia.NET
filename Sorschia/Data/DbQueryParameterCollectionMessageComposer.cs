namespace Sorschia.Data
{
    public sealed class DbQueryParameterCollectionMessageComposer : IDbQueryParameterCollectionMessageComposer
    {
        static DbQueryParameterCollectionMessageComposer()
        {
            Instance = new DbQueryParameterCollectionMessageComposer();
        }

        public static DbQueryParameterCollectionMessageComposer Instance { get; }

        public string ComposeParameterNameExists(string parameterName)
        {
            return $"Parameter '{parameterName}' already exists in the collection.";
        }

        public string ComposeParameterNotFound(string parameterName)
        {
            return $"Parameter '{parameterName}' doesn't exists in the collection.";
        }
    }
}
