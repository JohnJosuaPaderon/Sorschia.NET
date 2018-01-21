using Sorschia.Processing;

namespace MyDayManager.Entity.Process
{
    public interface IDeleteAssignment : IProcess<IAssignment>
    {
        IAssignment Assignment { get; set; }
    }
}
