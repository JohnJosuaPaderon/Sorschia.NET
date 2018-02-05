namespace Sorschia.Application
{
    internal sealed class SorschiaAppSetting : ISorschiaAppSetting
    {
        public SorschiaAppSetting(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw SorschiaAppException.InvalidSettingName("Name of application setting cannot be set to null or white space.");
            }

            Name = name;
        }

        public string Name { get; }
        public object Value { get; set; }

        public static bool operator ==(SorschiaAppSetting left, SorschiaAppSetting right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(SorschiaAppSetting left, SorschiaAppSetting right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is SorschiaAppSetting value)
            {
                return (Equals(Name, default(string)) || Equals(value.Name, default(string))) ? false : Equals(Name, value.Name);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
