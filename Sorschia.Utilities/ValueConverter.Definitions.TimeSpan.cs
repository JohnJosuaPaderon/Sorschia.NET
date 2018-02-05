using System;

namespace Sorschia.Utilities
{
    partial class ValueConverter
    {
        public static TimeSpan ToTimeSpan(object value)
        {
            if (value != null)
            {
                return new TimeSpan(ToInt64(value));
            }
            else
            {
                return default(TimeSpan);
            }
        }
    }
}
