using System;

namespace Sorschia.Utilities
{
    partial class DbValueConverter
    {
        public static TimeSpan? ToNullableTimeSpan(object value)
        {
            return ConversionBase(value, ValueConverter.ToNullableTimeSpan);
        }
    }
}
