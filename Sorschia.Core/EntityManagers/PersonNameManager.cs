using System;
using Sorschia.Core.Entities;
using Sorschia.Core.EntityProcesses;

namespace Sorschia.Core.EntityManagers
{
    public class PersonNameManager : IPersonNameManager
    {
        private IConstructPersonMiddleInitials ConstructPersonMiddleInitials { get; }

        public PersonNameManager(IConstructPersonMiddleInitials constructPersonMiddleInitials)
        {
            ConstructPersonMiddleInitials = constructPersonMiddleInitials;
        }

        public IDataProcessResult<string> ConstructFullName(Person person)
        {
            throw new NotImplementedException();
        }

        public IDataProcessResult<string> ConstructInformalFullName(Person person)
        {
            throw new NotImplementedException();
        }

        public IDataProcessResult<string> ConstructMiddleInitials(Person person)
        {
            ConstructPersonMiddleInitials.Person = person;
            return ConstructPersonMiddleInitials.Execute();
        }
    }
}
