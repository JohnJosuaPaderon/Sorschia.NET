namespace Sorschia.Data
{
    public interface IDbDataReaderConverterProperty<T>
    {
        bool UseProvidedValue { get; set; }
        T Value { get; set; }
        T TryGetValue(T alternativeValue);
    }
}
