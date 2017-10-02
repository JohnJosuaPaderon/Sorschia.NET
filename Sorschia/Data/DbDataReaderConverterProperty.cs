namespace Sorschia.Data
{
    public class DbDataReaderConverterProperty<T> : IDbDataReaderConverterProperty<T>
    {
        private T _Value;

        public bool UseProvidedValue { get; set; }

        public T Value
        {
            get { return _Value; }
            set
            {
                UseProvidedValue = false;
                _Value = value;
            }
        }

        public T TryGetValue(T alternativeValue)
        {
            return UseProvidedValue ? Value : alternativeValue;
        }
    }
}
