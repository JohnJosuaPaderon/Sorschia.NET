using Sorschia.Entity;

namespace MyDayManager.Entity.Provider
{
    public interface IAssignmentStatusProvider : IStaticEntityProvider
    {
        IAssignmentStatus Pending { get; }
        IAssignmentStatus Ongoing { get; }
        IAssignmentStatus Finished { get; }
    }
}
