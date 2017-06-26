using Sorschia.Core.Entities;

namespace Sorschia.Core.EntityManagers
{
    public interface IPersonNameManager
    {
        IDataProcessResult<string> ConstructFullName(Person person);
        IDataProcessResult<string> ConstructMiddleInitials(Person person);
        IDataProcessResult<string> ConstructInformalFullName(Person person);
    }
}
