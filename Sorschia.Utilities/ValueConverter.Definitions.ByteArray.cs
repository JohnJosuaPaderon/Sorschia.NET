namespace Sorschia.Utilities
{
    partial class ValueConverter
    {
        public static byte[] ToByteArray(object value)
        {
            if (value is byte[] bytes)
            {
                return bytes;
            }
            else
            {
                return null;
            }
        }
    }
}
