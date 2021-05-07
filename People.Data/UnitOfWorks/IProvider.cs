using People.Data.Entities.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace People.Data.UnitOfWorks
{
    public interface IProvider<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> FindSome(Expression<Func<TEntity, bool>> expression);
        TEntity FindOne(Expression<Func<TEntity, bool>> expression);
        TEntity FindOne(int id);
    }
}