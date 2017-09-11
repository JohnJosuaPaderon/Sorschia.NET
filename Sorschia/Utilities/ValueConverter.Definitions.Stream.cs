using System.IO;

namespace Sorschia.Utilities
{
    partial class ValueConverter
    {
        public static Stream ToStream(object value)
        {
            if (value != null)
            {
                return new MemoryStream(ToByteArray(value));
            }
            else
            {
                return null;
            }
        }
    }
}
