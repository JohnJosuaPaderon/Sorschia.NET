namespace Sorschia.Entity
{
    public abstract class EntityBase<TIdentifier> : IEntity<TIdentifier>
    {
        public TIdentifier Id { get; set; }

        public static bool operator ==(EntityBase<TIdentifier> left, EntityBase<TIdentifier> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EntityBase<TIdentifier> left, EntityBase<TIdentifier> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is EntityBase<TIdentifier> value)
            {
                return (Equals(Id, default(TIdentifier)) || Equals(value.Id, default(TIdentifier))) ? false : Equals(Id, value.Id);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
