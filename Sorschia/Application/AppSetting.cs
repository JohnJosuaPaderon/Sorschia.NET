namespace Sorschia.Application
{
    public sealed class AppSetting : IAppSetting
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public static bool operator ==(AppSetting left, AppSetting right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AppSetting left, AppSetting right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is AppSetting value)
            {
                return (Key == null || value.Key == null) ? false : Key == value.Key;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }
    }
}
