using People.Data.Entities.Interfaces;
using System.Linq;

namespace People.BusinessLogic.Services
{
    public static class AwareExtensions
    {
        public static IQueryable<T> Active<T>(this IQueryable<T> query) where T: IDeleteAware
        {
            return query.Where(x => !x.Deleted);
        }
    }
}
