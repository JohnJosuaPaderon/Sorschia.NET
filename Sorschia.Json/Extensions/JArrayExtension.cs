using Newtonsoft.Json.Linq;
using Sorschia.Utilities;
using System;

namespace Sorschia.Extensions
{
    public static class JArrayExtension
    {
        private static void Validate(JArray jArray, string propertyName)
        {
            if (jArray == null)
            {
                throw SorschiaException.ParameterRequired(nameof(jArray));
            }
            else if (jArray.Count <= 0)
            {
                throw SorschiaException.EmptyCollection(nameof(jArray));
            }
            else if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw SorschiaException.ParameterRequired(nameof(propertyName));
            }
        }

        private static T GetValueBase<T>(JArray jArray, string propertyName, Func<JValue, T> jConverter)
        {
            Validate(jArray, propertyName);

            var jToken = jArray[propertyName];

            if (jToken is JValue)
            {
                return jConverter(jToken as JValue);
            }
            else
            {
                return default(T);
            }
        }

        public static bool GetBoolean(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToBoolean);
        }

        public static byte GetByte(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToByte);
        }

        public static char GetChar(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToChar);
        }

        public static DateTime GetDateTime(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToDateTime);
        }

        public static decimal GetDecimal(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToDecimal);
        }

        public static double GetDouble(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToDouble);
        }

        public static short GetInt16(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToInt16);
        }

        public static int GetInt32(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToInt32);
        }

        public static long GetInt64(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToInt64);
        }

        public static bool? GetNullableBoolean(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableBoolean);
        }

        public static byte? GetNullableByte(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableByte);
        }

        public static char? GetNullableChar(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableChar);
        }

        public static DateTime? GetNullableDateTime(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableDateTime);
        }

        public static decimal? GetNullableDecimal(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableDecimal);
        }

        public static double? GetNullableDouble(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableDouble);
        }

        public static short? GetNullableInt16(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableInt16);
        }

        public static int? GetNullableInt32(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableInt16);
        }

        public static long? GetNullableInt64(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableInt64);
        }

        public static sbyte? GetNullableSByte(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableSByte);
        }

        public static float? GetNullableSingle(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableSingle);
        }

        public static TimeSpan? GetNullableTimeSpan(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableTimeSpan);
        }

        public static ushort? GetNullableUInt16(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableUInt16);
        }

        public static uint? GetNullableUInt32(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableUInt32);
        }

        public static ulong? GetNullableUInt64(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableUInt64);
        }

        public static sbyte GetSByte(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToSByte);
        }

        public static float GetSingle(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToSingle);
        }

        public static string GetString(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToString);
        }

        public static TimeSpan GetTimeSpan(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToTimeSpan);
        }

        public static ushort GetUInt16(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToUInt16);
        }

        public static uint GetUInt32(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToUInt32);
        }

        public static ulong GetUInt64(this JArray instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToUInt64);
        }
    }
}
