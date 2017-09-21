using Sorschia.Entities;
using System;

namespace Sorschia.DevTeam.Entities
{
    public interface IProject : IEntity<long>
    {
        string Name { get; set; }
        ValueRange<DateTime>? TimeFrame { get; set; }
    }
}
