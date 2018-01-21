using Sorschia.Convention;

namespace MyDayManager.Entity.Convention
{
    public interface IAssignmentParameters : IEntityParameters
    {
        string Title { get; }
        string Description { get; }
        string StatusId { get; }
        string Date { get; }
    }
}
