namespace Sorschia.Entity
{
    public interface IEntity<TIdentifier>
    {
        TIdentifier Id { get; set; }
    }
}
