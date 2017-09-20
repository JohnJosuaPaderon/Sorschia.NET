namespace Sorschia
{
    public struct ValueRange<T>
    {
        public T Begin { get; set; }
        public T End { get; set; }

        public static bool operator ==(ValueRange<T> left, ValueRange<T> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ValueRange<T> left, ValueRange<T> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            var value = (ValueRange<T>)obj;
            return
                Begin.Equals(value.Begin) &&
                End.Equals(value.End);
        }

        public override int GetHashCode()
        {
            return
                Begin.GetHashCode() ^
                End.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Begin} - {End}";
        }
    }
}
