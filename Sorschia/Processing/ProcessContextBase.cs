using System;

namespace Sorschia.Processing
{
    public abstract class ProcessContextBase : IProcessContext
    {
        public ProcessContextBase()
        {
            Guid = Guid.NewGuid();
        }

        public Guid Guid { get; }

        public static bool operator ==(ProcessContextBase left, ProcessContextBase right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ProcessContextBase left, ProcessContextBase right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = obj as ProcessContextBase;
            return Guid.Equals(value.Guid);
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }
    }
}
