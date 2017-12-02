namespace Sorschia.Entity
{
    public delegate void EntityCollectionEventHandler(object sender, EntityCollectionEventArgs e);
    public delegate void EntityCollectionEventHandler<T, TIdentifier>(object sender, EntityCollectionEventArgs<T, TIdentifier> e)
        where T : IEntity<TIdentifier>;
}
