using Sorschia.Application.EventFeeds;
using Sorschia.Events;
using System;

namespace Sorschia.Application
{
    public sealed class AppSession : IAppSession
    {
        public AppSession()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
        public DateTime? Begin { get; private set; }
        public DateTime? End { get; private set; }

        private ISorschiaEventManager _EventManager;

        private ISorschiaEventManager EventManager
        {
            get
            {
                if (_EventManager == null)
                {
                    _EventManager = SorschiaApp.GetService<ISorschiaEventManager>();
                }

                return _EventManager;
            }
        }

        public void Start()
        {
            if (Begin != null)
            {
                throw SorschiaException.AppFailure("App cannot be restarted.");
            }

            Begin = DateTime.Now;
            EventManager.GetEvent<AppStartedFeed>().Raise(new AppStartedFeed(this));
        }

        public void Stop()
        {
            if (End != null)
            {
                throw SorschiaException.AppFailure("App is already stopped.");
            }

            End = DateTime.Now;
            EventManager.GetEvent<AppStoppedFeed>().Raise(new AppStoppedFeed(this));
        }
    }
}
