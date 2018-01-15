namespace Sorschia.Events
{
    public interface ISorschiaEvent<TFeed>
        where TFeed : ISorschiaEventFeed
    {
        ISorschiaEventFeedEnumerable<TFeed> Feeds { get; }
        TFeed LastFeed { get; }
        void Raise(TFeed feed);
    }
}
