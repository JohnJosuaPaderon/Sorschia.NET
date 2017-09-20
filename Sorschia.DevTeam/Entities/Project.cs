﻿using Sorschia.Entities;
using System;

namespace Sorschia.DevTeam.Entities
{
    public class Project : Entity<long>
    {
        public string Name { get; set; }
        public ValueRange<DateTime> TimeFrame { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}