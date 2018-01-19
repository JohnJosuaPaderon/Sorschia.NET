using Sorschia.Events;

namespace Sorschia.Application.EventFeeds
{
    public sealed class AppStartedFeed : SorschiaEventFeedBase, ISorschiaEventFeed
    {
        internal AppStartedFeed(IAppSession session)
        {
            Session = session ?? throw SorschiaException.ParameterRequired(nameof(session));
        }

        public IAppSession Session { get; }
    }
}
