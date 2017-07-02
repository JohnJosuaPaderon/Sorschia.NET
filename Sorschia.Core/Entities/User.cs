﻿using Sorschia.Entities;
using System;
using System.Security;

namespace Sorschia.Core.Entities
{
    public class User : Entity<ulong>
    {
        public User()
        {
        }

        public User(Person owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public SecureString SecureUsername { get; set; }
        public SecureString SecurePassword { get; set; }
        public UserStatus Status { get; set; }
        public UserType Type { get; set; }
        public Person Owner { get; }
        public string DisplayName { get; set; }

        public override string ToString()
        {
            return DisplayName;
        }
    }
}
