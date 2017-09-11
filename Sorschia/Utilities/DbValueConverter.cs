using System;

namespace Sorschia.Utilities
{
    public static partial class DbValueConverter
    {
        private static bool Convertible<TArgument>(TArgument value)
        {
            return !DBNull.Value.Equals(value);
        }

        private static TResult ConversionBase<TArgument, TResult>(TArgument value, Func<TArgument, TResult> converter)
        {
            return Convertible(value) ? converter(value) : default(TResult);
        }

        private static TResult ConversionBase<TArgument, TResult>(TArgument value, int fromToBase, Func<TArgument, int, TResult> converter)
        {
            return Convertible(value) ? converter(value, fromToBase) : default(TResult);
        }

        private static TResult ConversionBase<TArgument, TResult>(TArgument value, IFormatProvider formatProvider, Func<TArgument, IFormatProvider, TResult> converter)
        {
            return Convertible(value) ? converter(value, formatProvider) : default(TResult);
        }
    }
}
