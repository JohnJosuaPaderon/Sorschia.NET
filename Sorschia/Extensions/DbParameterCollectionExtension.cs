using Sorschia.Utilities;
using System;
using System.Data.Common;
using System.IO;

namespace Sorschia.Extensions
{
    public static class DbParameterCollectionExtension
    {
        private static void Validate(DbParameterCollection parameters, string parameterName)
        {
            if (parameters == null)
            {
                throw new ArgumentNullException(nameof(parameters));
            }

            if (parameters.Count <= 0)
            {
                throw new ArgumentException(nameof(parameters), "Parameters is empty.");
            }

            if (string.IsNullOrWhiteSpace(parameterName))
            {
                throw new ArgumentException(nameof(parameterName), "Parameter name is invalid.");
            }
        }

        private static T GetValueBase<T>(DbParameterCollection parameters, string parameterName, Func<object, T> converter)
        {
            Validate(parameters, parameterName);
            return converter(parameters[parameterName].Value);
        }

        public static bool GetBoolean(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToBoolean);
        }

        public static byte GetByte(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToByte);
        }

        public static char GetChar(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToChar);
        }

        public static DateTime GetDateTime(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToDateTime);
        }

        public static decimal GetDecimal(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToDecimal);
        }

        public static double GetDouble(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToDouble);
        }

        public static short GetInt16(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToInt16);
        }

        public static int GetInt32(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToInt32);
        }

        public static long GetInt64(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToInt64);
        }

        public static bool? GetNullableBoolean(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableBoolean);
        }

        public static byte? GetNullableByte(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableByte);
        }

        public static char? GetNullableChar(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableChar);
        }

        public static DateTime? GetNullableDateTime(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableDateTime);
        }

        public static decimal? GetNullableDecimal(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableDecimal);
        }

        public static double? GetNullableDouble(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableDouble);
        }

        public static short? GetNullableInt16(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableInt16);
        }

        public static int? GetNullableInt32(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableInt16);
        }

        public static long? GetNullableInt64(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableInt64);
        }

        public static sbyte? GetNullableSByte(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableSByte);
        }

        public static float? GetNullableSingle(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableSingle);
        }

        public static TimeSpan? GetNullableTimeSpan(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableTimeSpan);
        }

        public static ushort? GetNullableUInt16(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableUInt16);
        }

        public static uint? GetNullableUInt32(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableUInt32);
        }

        public static ulong? GetNullableUInt64(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToNullableUInt64);
        }

        public static sbyte GetSByte(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToSByte);
        }

        public static float GetSingle(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToSingle);
        }

        public static Stream GetStream(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToStream);
        }

        public static string GetString(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToString);
        }

        public static TimeSpan GetTimeSpan(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToTimeSpan);
        }

        public static ushort GetUInt16(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToUInt16);
        }

        public static uint GetUInt32(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToUInt32);
        }

        public static ulong GetUInt64(this DbParameterCollection instance, string parameterName)
        {
            return GetValueBase(instance, parameterName, DbValueConverter.ToUInt64);
        }
    }
}
