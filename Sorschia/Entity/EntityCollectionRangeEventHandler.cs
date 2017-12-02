namespace Sorschia.Entity
{
    public delegate void EntityCollectionRangeEventHandler<T, TIdentifier>(object sender, EntityCollectionRangeEventArgs<T, TIdentifier> e)
        where T : IEntity<TIdentifier>;
}
