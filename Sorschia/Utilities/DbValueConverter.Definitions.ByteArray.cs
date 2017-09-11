namespace Sorschia.Utilities
{
    partial class DbValueConverter
    {
        public static byte[] ToByteArray(object value)
        {
            return ConversionBase(value, ValueConverter.ToByteArray);
        }
    }
}
