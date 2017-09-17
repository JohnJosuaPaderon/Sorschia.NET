using System;

namespace Sorschia.Entities
{
    [Flags]
    public enum EntityCollectionOperation
    {
        NotSet = 0,
        Add = 1,
        Remove = 2,
        Update = 4,
        Clear = 8
    }
}
