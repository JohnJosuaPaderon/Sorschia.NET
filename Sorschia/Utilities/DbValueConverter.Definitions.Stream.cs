using System.IO;

namespace Sorschia.Utilities
{
    partial class DbValueConverter
    {
        public static Stream ToStream(object value)
        {
            return ConversionBase(value, ValueConverter.ToStream);
        }
    }
}
