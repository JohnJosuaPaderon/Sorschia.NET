namespace Sorschia.Data
{
    public abstract class DbDataReaderConverterBase
    {
        public DbDataReaderConverterBase(
            IDbDataReaderToProcessResultConverter toProcessResultConverter,
            IDbDataReaderToEnumerableProcessResultConverter toEnumerableProcessResultConverter)
        {
            _ToProcessResultConverter = toProcessResultConverter;
            _ToEnumerableProcessResultConverter = toEnumerableProcessResultConverter;
        }

        protected readonly IDbDataReaderToEnumerableProcessResultConverter _ToEnumerableProcessResultConverter;
        protected readonly IDbDataReaderToProcessResultConverter _ToProcessResultConverter;
    }
}
