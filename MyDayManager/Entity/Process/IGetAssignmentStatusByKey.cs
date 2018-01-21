using Sorschia.Processing;

namespace MyDayManager.Entity.Process
{
    public interface IGetAssignmentStatusByKey : IProcess<IAssignmentStatus>
    {
        string Key { get; set; }
    }
}
