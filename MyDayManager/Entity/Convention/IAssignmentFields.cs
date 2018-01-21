using Sorschia.Convention;

namespace MyDayManager.Entity.Convention
{
    public interface IAssignmentFields : IEntityFields
    {
        string Title { get; }
        string Description { get; }
        string StatusId { get; }
        string Date { get; }
    }
}
