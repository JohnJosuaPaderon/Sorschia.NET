﻿using Sorschia.Entity;
using System.Security;

namespace Sorschia.DevTeam.Entities
{
    public class User : EntityBase<long>, IUser
    {
        public Member Owner { get; set; }
        public SecureString SecureUsername { get; set; }
        public SecureString SecurePassword { get; set; }
    }
}
