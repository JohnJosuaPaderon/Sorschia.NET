using Sorschia.Events;

namespace Sorschia.Application.EventFeeds
{
    public sealed class AppStoppedFeed : SorschiaEventFeedBase, ISorschiaEventFeed
    {
        internal AppStoppedFeed(IAppSession session)
        {
            Session = session ?? throw SorschiaException.ParameterRequired(nameof(session));
        }

        public IAppSession Session { get; }
    }
}
