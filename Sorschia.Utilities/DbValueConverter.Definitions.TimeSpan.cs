using System;

namespace Sorschia.Utilities
{
    partial class DbValueConverter
    {
        public static TimeSpan ToTimeSpan(object value)
        {
            return ConversionBase(value, ValueConverter.ToTimeSpan);
        }
    }
}
