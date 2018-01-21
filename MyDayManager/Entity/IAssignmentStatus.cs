using Sorschia.Entity;

namespace MyDayManager.Entity
{
    public interface IAssignmentStatus : IEntity<short>
    {
        string Description { get; }
    }
}
