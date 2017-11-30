using Sorschia.Entities;

namespace Sorschia.Models
{
    public abstract class EntityModelBase<T, TIdentifier> : ModelBase<T>
        where T : IEntity<TIdentifier>
    {
        public EntityModelBase(T source) : base(source)
        {
        }

        private TIdentifier _Id;
        public TIdentifier Id
        {
            get { return _Id; }
            set { SetProperty(ref _Id, value); }
        }

        public override T GetSource()
        {
            if (Source != null)
            {
                Source.Id = Id;
            }

            return Source;
        }

        public static bool operator ==(EntityModelBase<T, TIdentifier> left, EntityModelBase<T, TIdentifier> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(EntityModelBase<T, TIdentifier> left, EntityModelBase<T, TIdentifier> right)
        {
            return !(left == right);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (GetType() != obj.GetType()) return false;

            if (obj is EntityModelBase<T, TIdentifier> value)
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
