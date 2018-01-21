using Sorschia.Entity;

namespace MyDayManager.Entity
{
    public sealed class AssignmentStatus : EntityBase<short>, IAssignmentStatus
    {
        public AssignmentStatus(string description)
        {
            Description = description;
        }

        public string Description { get; }
    }
}
