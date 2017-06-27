﻿using Sorschia.Utilities;
using System;

namespace Sorschia
{
    partial class DbValueConverter
    {
        public static short? ToNullableInt16(object value)
        {
            return ConversionBase(value, ValueConverter.ToNullableInt16);
        }

        public static short? ToNullableInt16(object value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToNullableInt16);
        }
    }
}
