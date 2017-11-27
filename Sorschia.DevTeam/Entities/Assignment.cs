using Sorschia.Entities;
using System;

namespace Sorschia.DevTeam.Entities
{
    public class Assignment : EntityBase<long>, IAssignment
    {
        public ValueRange<DateTime> TimeFrame { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public AssignmentStatus Status { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
