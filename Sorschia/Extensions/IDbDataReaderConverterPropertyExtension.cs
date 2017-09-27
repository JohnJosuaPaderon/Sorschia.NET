using Sorschia.Data;
using System;

namespace Sorschia.Extensions
{
    public static class IDbDataReaderConverterPropertyExtension
    {
        public static T TryGetValue<T>(this IDbDataReaderConverterProperty<T> instance, Func<string, T> expression, string arg)
        {
            return instance.TryGetValue(expression(arg));
        }
    }
}
