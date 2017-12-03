using Sorschia.Processing;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Sorschia.Data
{
    public static class IDbDataReaderConverterPropertyExtension
    {
        public static T TryGetValue<T>(this IDbDataReaderConverterProperty<T> instance, Func<string, T> expression, string arg)
        {
            return instance.UseProvidedValue ? instance.Value : expression(arg);
        }

        public static TResult TryGetValueFromProcess<TResult, TArg>(this IDbDataReaderConverterProperty<TResult> instance, Func<TArg, IProcessResult<TResult>> getDataById, Func<string, TArg> getIdFromReader, string idField)
        {
            return instance.UseProvidedValue ? instance.Value : getDataById(getIdFromReader(idField)).Data;
        }

        public static async Task<TResult> TryGetValueFromProcessAsync<TResult, TArg>(this IDbDataReaderConverterProperty<TResult> instance, Func<TArg, Task<IProcessResult<TResult>>> getDataByIdAsync, Func<string, TArg> getIdFromReader, string idField)
        {
            return instance.UseProvidedValue ? instance.Value : (await getDataByIdAsync(getIdFromReader(idField))).Data;
        }

        public static async Task<TResult> TryGetValueFromProcessAsync<TResult, TArg>(this IDbDataReaderConverterProperty<TResult> instance, Func<TArg, CancellationToken, Task<IProcessResult<TResult>>> getDataByIdAsync, Func<string, TArg> getIdFromReader, string idField, CancellationToken cancellationToken)
        {
            return instance.UseProvidedValue ? instance.Value : (await getDataByIdAsync(getIdFromReader(idField), cancellationToken)).Data;
        }
    }
}
