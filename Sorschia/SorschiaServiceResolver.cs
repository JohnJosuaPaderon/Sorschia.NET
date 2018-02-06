namespace Sorschia
{
    public abstract class SorschiaServiceResolver
    {
        public static TContract Resolve<TContract>()
        {
            if (_Resolver == null)
            {
                throw SorschiaException.AppFailure("Resolver is not initialized.");
            }

            return _Resolver.ResolveProtected<TContract>();
        }

        private static SorschiaServiceResolver _Resolver;

        public static void Initialize(SorschiaServiceResolver resolver)
        {
            if (_Resolver != null)
            {
                throw SorschiaException.AppFailure("Resolver is already initialized.");
            }

            _Resolver = resolver ?? throw SorschiaException.AppFailure("Resolver is null.");
        }

        protected abstract TContract ResolveProtected<TContract>();
    }
}
