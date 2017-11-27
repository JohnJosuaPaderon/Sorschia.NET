﻿namespace Sorschia.Application
{
    public sealed class AppDirectory : IAppDirectory
    {
        public AppDirectory(AppDirectoryType type)
        {
            Type = type;
        }

        public AppDirectoryType Type { get; }
        public string Path { get; set; }
        public bool IsRequired { get; set; }

        public static bool operator ==(AppDirectory left, AppDirectory right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(AppDirectory left, AppDirectory right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is AppDirectory value)
            {
                return Type == value.Type;
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Type.GetHashCode();
        }
    }
}
