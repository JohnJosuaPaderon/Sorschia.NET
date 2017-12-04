using Sorschia.DailyTask.Models;
using Sorschia.Notifications;

namespace Sorschia.DailyTask.Notifications
{
    public interface IAddDTaskNotification : ICustomNotification
    {
        DTaskModel DTask { get; }
    }
}
