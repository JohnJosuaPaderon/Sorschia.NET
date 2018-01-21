using Sorschia.Entity;
using System;

namespace MyDayManager.Entity
{
    public class Assignment : EntityBase<long>, IAssignment
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public IAssignmentStatus Status { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return Title;
        }
    }
}
