using Sorschia.DailyTask.Models;
using Sorschia.Notifications;

namespace Sorschia.DailyTask.Notifications
{
    public interface IAddDTaskNotification : ISorschiaNotification
    {
        DTaskModel DTask { get; }
    }
}
