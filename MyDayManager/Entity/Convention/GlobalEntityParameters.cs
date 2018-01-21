using Sorschia.Convention;

namespace MyDayManager.Entity.Convention
{
    internal sealed class GlobalEntityParameters : IGlobalEntityParameters
    {
        public GlobalEntityParameters(IEntityParameterFormatter formatter)
        {
            Key = formatter.Format(nameof(Key));
        }

        public string Key { get; }
    }
}
