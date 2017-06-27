﻿using Sorschia.Utilities;
using System;

namespace Sorschia
{
    partial class DbValueConverter
    {
        public static bool? ToNullableBoolean(object value)
        {
            return ConversionBase(value, ValueConverter.ToNullableBoolean);
        }

        public static bool? ToNullableBoolean(object value, IFormatProvider formatProvider)
        {
            return ConversionBase(value, formatProvider, ValueConverter.ToNullableBoolean);
        }
    }
}
