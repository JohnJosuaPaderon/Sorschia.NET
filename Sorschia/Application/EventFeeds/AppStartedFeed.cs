using Sorschia.Events;

namespace Sorschia.Application.EventFeeds
{
    public sealed class AppStartedFeed : SorschiaEventFeedBase, ISorschiaEventFeed
    {
        public AppStartedFeed(IAppSession session)
        {
            Session = session ?? throw SorschiaException.ParameterRequired(nameof(session));
        }

        public IAppSession Session { get; }
    }
}
