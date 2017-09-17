using Newtonsoft.Json.Linq;
using System;

namespace Sorschia.Utilities
{
    public static class JValueConverter
    {
        private static void Validate(JValue jValue)
        {
            if (jValue == null)
            {
                throw new SorschiaException(nameof(jValue), SorschiaExceptionType.UnexpectedNull);
            }
        }

        private static T GetValueBase<T>(JValue jValue, Func<object, T> converter)
        {
            Validate(jValue);

            if (jValue.HasValues)
            {
                return default(T);
            }
            else
            {
                return converter(jValue);
            }
        }

        public static bool ToBoolean(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToBoolean);
        }

        public static byte ToByte(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToByte);
        }

        public static char ToChar(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToChar);
        }

        public static DateTime ToDateTime(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToDateTime);
        }

        public static decimal ToDecimal(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToDecimal);
        }

        public static double ToDouble(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToDouble);
        }

        public static short ToInt16(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToInt16);
        }

        public static int ToInt32(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToInt32);
        }

        public static long ToInt64(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToInt64);
        }

        public static bool? ToNullableBoolean(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableBoolean);
        }

        public static byte? ToNullableByte(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableByte);
        }

        public static char? ToNullableChar(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableChar);
        }

        public static DateTime? ToNullableDateTime(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableDateTime);
        }

        public static decimal? ToNullableDecimal(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableDecimal);
        }

        public static double? ToNullableDouble(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableDouble);
        }

        public static short? ToNullableInt16(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableInt16);
        }

        public static int? ToNullableInt32(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableInt16);
        }

        public static long? ToNullableInt64(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableInt64);
        }

        public static sbyte? ToNullableSByte(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableSByte);
        }

        public static float? ToNullableSingle(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableSingle);
        }

        public static TimeSpan? ToNullableTimeSpan(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableTimeSpan);
        }

        public static ushort? ToNullableUInt16(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableUInt16);
        }

        public static uint? ToNullableUInt32(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableUInt32);
        }

        public static ulong? ToNullableUInt64(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToNullableUInt64);
        }

        public static sbyte ToSByte(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToSByte);
        }

        public static float ToSingle(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToSingle);
        }

        public static string ToString(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToString);
        }

        public static TimeSpan ToTimeSpan(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToTimeSpan);
        }

        public static ushort ToUInt16(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToUInt16);
        }

        public static uint ToUInt32(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToUInt32);
        }

        public static ulong ToUInt64(JValue instance)
        {
            return GetValueBase(instance, ValueConverter.ToUInt64);
        }
    }
}
