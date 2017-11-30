using Prism.Mvvm;

namespace Sorschia.Models
{
    public abstract class ModelBase<T> : BindableBase
    {
        public ModelBase(T source)
        {
            Source = source;
        }

        protected T Source { get; }
        public abstract T GetSource();
    }
}
