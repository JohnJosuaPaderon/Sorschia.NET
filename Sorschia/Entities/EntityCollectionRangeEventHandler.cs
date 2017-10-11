namespace Sorschia.Entities
{
    public delegate void EntityCollectionRangeEventHandler<T, TIdentifier>(object sender, EntityCollectionRangeEventArgs<T, TIdentifier> e)
        where T : IEntity<TIdentifier>;
}
