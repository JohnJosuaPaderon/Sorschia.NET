using Sorschia.Entity;
using System;

namespace Sorschia.DevTeam.Entity
{
    public class Project : EntityBase<long>, IProject
    {
        public string Name { get; set; }
        public ValueRange<DateTime>? TimeFrame { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
