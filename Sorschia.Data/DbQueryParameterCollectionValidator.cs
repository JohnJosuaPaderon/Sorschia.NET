namespace Sorschia.Data
{
    public sealed class DbQueryParameterCollectionValidator : IDbQueryParameterCollectionValidator
    {
        static DbQueryParameterCollectionValidator()
        {
            Instance = new DbQueryParameterCollectionValidator();
        }

        public static DbQueryParameterCollectionValidator Instance { get; }

        public void ValidateParameter(IDbQueryParameter parameter)
        {
            if (parameter == null)
            {
                throw SorschiaException.ParameterRequired(nameof(parameter));
            }
        }

        public void ValidateParameterName(string parameterName)
        {
            if (string.IsNullOrWhiteSpace(parameterName))
            {
                throw SorschiaException.ParameterRequired(nameof(parameterName));
            }
        }
    }
}
