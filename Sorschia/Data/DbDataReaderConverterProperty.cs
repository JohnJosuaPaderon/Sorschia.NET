namespace Sorschia.Data
{
    public class DbDataReaderConverterProperty<T> : IDbDataReaderConverterProperty<T>
    {
        public bool UseProvidedValue { get; set; }
        public T Value { get; set; }

        public T TryGetValue(T alternativeValue)
        {
            return UseProvidedValue ? Value : alternativeValue;
        }
    }
}
