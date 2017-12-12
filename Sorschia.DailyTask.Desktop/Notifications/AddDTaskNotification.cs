using Sorschia.DailyTask.Entity;
using Sorschia.DailyTask.Models;
using Sorschia.Notifications;
using System;

namespace Sorschia.DailyTask.Notifications
{
    public sealed class AddDTaskNotification : SorschiaNotification, IAddDTaskNotification
    {
        public AddDTaskNotification()
        {
            DTask = new DTaskModel(new DTask()
            {
                ScheduledDate = DateTime.Now
            });
        }

        public DTaskModel DTask { get; }
    }
}
