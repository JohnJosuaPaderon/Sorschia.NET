using Sorschia.Processing;

namespace MyDayManager.Entity.Process
{
    public interface IGetAssignmentStatus : IProcess<IAssignmentStatus>
    {
        short Id { get; set; }
    }
}
