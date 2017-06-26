using Sorschia.Core.Entities;

namespace Sorschia.Core.EntityProcesses
{
    public interface IConstructPersonMiddleInitials : IDataProcess<string>
    {
        Person Person { get; set; }
    }
}
