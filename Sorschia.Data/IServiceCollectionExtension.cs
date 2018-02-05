using Microsoft.Extensions.DependencyInjection;
using System.Data.Common;

namespace Sorschia.Data
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection UseDbConnectionProvider<T, TConnection>(this IServiceCollection instance)
            where T : class, IDbConnectionProvider<TConnection>
            where TConnection : DbConnection
        {
            return instance.AddSingleton<IDbConnectionProvider<TConnection>, T>();
        }

        public static IServiceCollection UseDbTransactionProvider<T, TTransaction>(this IServiceCollection instance)
            where T : class, IDbTransactionProvider<TTransaction>
            where TTransaction : DbTransaction
        {
            return instance.AddSingleton<IDbTransactionProvider<TTransaction>, T>();
        }

        public static IServiceCollection UseDbCommandCreator<T, TCommand>(this IServiceCollection instance)
            where T : class, IDbCommandCreator<TCommand>
            where TCommand : DbCommand
        {
            return instance.AddSingleton<IDbCommandCreator<TCommand>, T>();
        }

        public static IServiceCollection UseDbQueryParameterConverter<T, TParameter>(this IServiceCollection instance)
            where T : class, IDbQueryParameterConverter<TParameter>
            where TParameter : DbParameter
        {
            return instance.AddSingleton<IDbQueryParameterConverter<TParameter>, T>();
        }

        public static IServiceCollection UseDbProcessor<T, TCommand>(this IServiceCollection instance)
            where T : class, IDbProcessor<TCommand>
            where TCommand : DbCommand
        {
            return instance.AddSingleton<IDbProcessor<TCommand>, T>();
        }
    }
}
