using Sorschia.Data;

namespace Sorschia.Entity.Converter
{
    public interface IEntityConverter<T, TIdentifier> : IDbDataReaderConverter<T>
        where T : IEntity<TIdentifier>
    {
        IDbDataReaderConverterProperty<TIdentifier> PId { get; }
    }
}
