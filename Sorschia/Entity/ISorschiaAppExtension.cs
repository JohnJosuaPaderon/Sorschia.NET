using Sorschia.Application;

namespace Sorschia.Entity
{
    public static class ISorschiaAppExtension
    {
        public static void EnableEntityEventHandlers(this ISorschiaApp instance)
        {
            SorschiaEntityConfiguration.EntityEventHandlersEnabled = true;
        }

        public static void DisableEntityEventHandlers(this ISorschiaApp instance)
        {
            SorschiaEntityConfiguration.EntityEventHandlersEnabled = false;
        }
    }
}
