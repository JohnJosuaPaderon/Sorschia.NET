using System;

namespace Sorschia.Utilities
{
    partial class ValueConverter
    {
        public static TimeSpan? ToNullableTimeSpan(object value)
        {
            if (value != null)
            {
                return ToTimeSpan(value);
            }
            else
            {
                return null;
            }
        }
    }
}
