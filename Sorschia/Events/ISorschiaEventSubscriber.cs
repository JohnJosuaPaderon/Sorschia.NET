namespace Sorschia.Events
{
    public interface ISorschiaEventSubscriber<TFeed>
        where TFeed : ISorschiaEventFeed
    {
        void CaptureEventFeed(ISorschiaEvent<TFeed> sorschiaEvent, TFeed feed);
    }
}
