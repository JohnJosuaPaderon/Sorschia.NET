using System;

namespace Sorschia.Core.Entities
{
    public class UserCredentials
    {
        public UserCredentials(User owner)
        {
            Owner = owner ?? throw new ArgumentNullException(nameof(owner));
        }

        public User Owner { get; }
        public string Username { get; set; }
        public string Password { get; set; }

        public static bool operator ==(UserCredentials left, UserCredentials right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserCredentials left, UserCredentials right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as UserCredentials;
            return Owner.Equals(value.Owner);
        }

        public override int GetHashCode()
        {
            return Owner.GetHashCode();
        }

        public override string ToString()
        {
            return Owner.ToString();
        }
    }
}
