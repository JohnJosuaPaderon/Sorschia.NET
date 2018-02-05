namespace Sorschia.Entity.Manager
{
    partial class EntityManagerBase<T, TIdentifier>
    {
        private void Source_Added(object sender, EntityCollectionEventArgs<T, TIdentifier> e)
        {
            OnAdded(e.Data);
        }

        private void Source_RangeAdded(object sender, EntityCollectionRangeEventArgs<T, TIdentifier> e)
        {
            OnAdded(e.DataCollection);
        }

        private void Source_Updated(object sender, EntityCollectionEventArgs<T, TIdentifier> e)
        {
            OnUpdated(e.Data);
        }

        private void Source_RangeUpdated(object sender, EntityCollectionRangeEventArgs<T, TIdentifier> e)
        {
            OnUpdated(e.DataCollection);
        }

        private void Source_Removed(object sender, EntityCollectionEventArgs<T, TIdentifier> e)
        {
            OnDeleted(e.Data);
        }

        private void Source_RangeRemoved(object sender, EntityCollectionRangeEventArgs<T, TIdentifier> e)
        {
            OnDeleted(e.DataCollection);
        }
    }
}
