using Sorschia.Entity;
using System;

namespace Sorschia.DevTeam.Entity
{
    public interface IProject : IEntity<long>
    {
        string Name { get; set; }
        ValueRange<DateTime>? TimeFrame { get; set; }
    }
}
