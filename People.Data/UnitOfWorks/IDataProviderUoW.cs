using People.Data.Interfaces;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace People.Data.UnitOfWorks
{
    public interface IDataProviderUoW<TEntity> where TEntity : class, IEntity
    {
        IQueryable<TEntity> FindAll();
        IQueryable<TEntity> FindSome(Expression<Func<TEntity, bool>> expression);
        TEntity FindOne(Expression<Func<TEntity, bool>> expression);
        TEntity FindOne(int id);
    }
}