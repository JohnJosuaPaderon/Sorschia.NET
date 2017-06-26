namespace Sorschia.Core.Entities
{
    public class UserStatus
    {
        public static UserStatus Active { get; } = new UserStatus("Active");
        public static UserStatus Inactive { get; } = new UserStatus("Inactive");
        public static UserStatus ForApproval { get; } = new UserStatus("ForApproval");

        protected UserStatus(string value)
        {
            Value = string.IsNullOrWhiteSpace(value) ? null : value.Trim();
        }

        public string Value { get; }

        public static implicit operator UserStatus(string arg)
        {
            return new UserStatus(arg);
        }

        public static explicit operator string(UserStatus arg)
        {
            return arg?.Value;
        }

        public static bool operator ==(UserStatus left, UserStatus right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UserStatus left, UserStatus right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as UserStatus;
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
