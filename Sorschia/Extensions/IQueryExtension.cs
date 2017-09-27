using Sorschia.Data;
using System.Data.Common;

namespace Sorschia.Extensions
{
    public static class IQueryExtension
    {
        public static IQuery<IQueryParameter> AddInParameter(this IQuery<IQueryParameter> instance, string name, object value)
        {
            instance.Parameters.AddIn(name, value);
            return instance;
        }

        public static IQuery<IQueryParameter> AddOutParameter(this IQuery<IQueryParameter> instance, string name)
        {
            instance.Parameters.AddOut(name);
            return instance;
        }

        public static IQuery<IQueryParameter> AddInOutParameter(this IQuery<IQueryParameter> instance, string name, object value)
        {
            instance.Parameters.AddInOut(name, value);
            return instance;
        }

        public static IQuery<TCommand, IQueryParameter> AddInParameter<TCommand>(this IQuery<TCommand, IQueryParameter> instance, string name, object value)
            where TCommand : DbCommand
        {
            instance.Parameters.AddIn(name, value);
            return instance;
        }

        public static IQuery<TCommand, IQueryParameter> AddOutParameter<TCommand>(this IQuery<TCommand, IQueryParameter> instance, string name)
            where TCommand : DbCommand
        {
            instance.Parameters.AddOut(name);
            return instance;
        }

        public static IQuery<TCommand, IQueryParameter> AddInOutParameter<TCommand>(this IQuery<TCommand, IQueryParameter> instance, string name, object value)
            where TCommand : DbCommand
        {
            instance.Parameters.AddInOut(name, value);
            return instance;
        }

        public static IQuery<TData, TCommand, IQueryParameter> AddInParameter<TData, TCommand>(this IQuery<TData, TCommand, IQueryParameter> instance, string name, object value)
           where TCommand : DbCommand
        {
            instance.Parameters.AddIn(name, value);
            return instance;
        }

        public static IQuery<TData, TCommand, IQueryParameter> AddOutParameter<TData, TCommand>(this IQuery<TData, TCommand, IQueryParameter> instance, string name)
            where TCommand : DbCommand
        {
            instance.Parameters.AddOut(name);
            return instance;
        }

        public static IQuery<TData, TCommand, IQueryParameter> AddInOutParameter<TData, TCommand>(this IQuery<TData, TCommand, IQueryParameter> instance, string name, object value)
            where TCommand : DbCommand
        {
            instance.Parameters.AddInOut(name, value);
            return instance;
        }
    }
}
