using System.Data.Common;

namespace Sorschia.Data
{
    public interface IDbQueryParameterConverter<TParameter>
        where TParameter : DbParameter
    {
        TParameter Convert(IDbQueryParameter parameter);
    }
}
