using Newtonsoft.Json.Linq;
using Sorschia.Utilities;
using System;

namespace Sorschia.Extensions
{
    public static class JObjectExtension
    {
        private static void Validate(JObject jObject, string propertyName)
        {
            if (jObject == null)
            {
                throw new SorschiaException(nameof(jObject), SorschiaExceptionKind.UnexpectedNull);
            }

            if (jObject.Count <= 0)
            {
                throw new SorschiaException(nameof(jObject), SorschiaExceptionKind.EmptyCollection);
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                throw new SorschiaException(nameof(propertyName), SorschiaExceptionKind.InvalidValue);
            }
        }

        private static T GetValueBase<T>(JObject jObject, string propertyName, Func<JValue, T> converter)
        {
            Validate(jObject, propertyName);

            var jToken = jObject[propertyName];

            if (jToken is JValue)
            {
                return converter(jToken as JValue);
            }
            else
            {
                return default(T);
            }
        }

        public static bool GetBoolean(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToBoolean);
        }

        public static byte GetByte(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToByte);
        }

        public static char GetChar(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToChar);
        }

        public static DateTime GetDateTime(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToDateTime);
        }

        public static decimal GetDecimal(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToDecimal);
        }

        public static double GetDouble(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToDouble);
        }

        public static short GetInt16(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToInt16);
        }

        public static int GetInt32(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToInt32);
        }

        public static long GetInt64(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToInt64);
        }

        public static bool? GetNullableBoolean(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableBoolean);
        }

        public static byte? GetNullableByte(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableByte);
        }

        public static char? GetNullableChar(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableChar);
        }

        public static DateTime? GetNullableDateTime(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableDateTime);
        }

        public static decimal? GetNullableDecimal(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableDecimal);
        }

        public static double? GetNullableDouble(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableDouble);
        }

        public static short? GetNullableInt16(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableInt16);
        }

        public static int? GetNullableInt32(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableInt16);
        }

        public static long? GetNullableInt64(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableInt64);
        }

        public static sbyte? GetNullableSByte(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableSByte);
        }

        public static float? GetNullableSingle(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableSingle);
        }

        public static TimeSpan? GetNullableTimeSpan(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableTimeSpan);
        }

        public static ushort? GetNullableUInt16(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableUInt16);
        }

        public static uint? GetNullableUInt32(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableUInt32);
        }

        public static ulong? GetNullableUInt64(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToNullableUInt64);
        }

        public static sbyte GetSByte(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToSByte);
        }

        public static float GetSingle(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToSingle);
        }

        public static string GetString(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToString);
        }

        public static TimeSpan GetTimeSpan(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToTimeSpan);
        }

        public static ushort GetUInt16(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToUInt16);
        }

        public static uint GetUInt32(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToUInt32);
        }

        public static ulong GetUInt64(this JObject instance, string propertyName)
        {
            return GetValueBase(instance, propertyName, JValueConverter.ToUInt64);
        }
    }
}
