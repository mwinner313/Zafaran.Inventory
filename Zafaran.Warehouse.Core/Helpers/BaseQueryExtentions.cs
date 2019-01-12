using System.Linq;
using Zafaran.Warehouse.Core.Dtos;

namespace Zafaran.Warehouse.Core.Helpers
{
    public static class BaseQueryExtentions
    {
        public static IQueryable<T> Pagenate<T>(this IQueryable<T> queryable, BaseQuery query)
        {
            return queryable.Skip(query.Page * query.Size).Take(query.Size);
        }
    }
}