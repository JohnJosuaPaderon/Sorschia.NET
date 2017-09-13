using System;

namespace Sorschia.Data
{
    [Flags]
    public enum QueryParameterDirection
    {
        In = 0,
        Out = 1,
        InOut = 2
    }
}
