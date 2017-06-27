using Sorschia.Utilities;
using System;

namespace Sorschia
{
    partial class DbValueConverter
    {
        public static double? ToNullableDouble(object value)
        {
            return ConversionBase(value, ValueConverter.ToNullableDouble);
        }

        public static double? ToNullableDouble(object value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToNullableDouble);
        }
    }
}
