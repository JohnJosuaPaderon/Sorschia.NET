namespace Sorschia.Data
{
    public static class DbQueryFactory
    {
        public static IDbQuery StoredProcedure(string procedureName)
        {
            if (string.IsNullOrWhiteSpace(procedureName))
            {
                throw SorschiaException.ParameterRequired(nameof(procedureName));
            }
            else
            {
                return new DbProcedureQuery(procedureName);
            }
        }

        public static IDbQuery Text(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw SorschiaException.ParameterRequired(nameof(text));
            }
            else
            {
                return new DbTextQuery(text);
            }
        }
    }
}
