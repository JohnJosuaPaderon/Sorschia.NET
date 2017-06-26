namespace Sorschia.Core.Entities
{
    public class UserType
    {
        public static UserType Administrator { get; } = new UserType("Administrator");
        public static UserType Guest { get; } = new UserType("Guest");

        protected UserType(string value)
        {
            Value = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }

        public string Value { get; }

        public static implicit operator UserType(string arg)
        {
            return new UserType(arg);
        }

        public static explicit operator string(UserType arg)
        {
            return arg?.Value;
        }

        public static bool operator ==(UserType left, UserType right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserType left, UserType right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as UserType;
            return Value.Equals(value.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public override string ToString()
        {
            return Value;
        }
    }
}
