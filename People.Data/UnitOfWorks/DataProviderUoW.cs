using People.Data.DTO;
using People.Data.Entities.Interfaces;
using People.Data.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace People.Data.UnitOfWorks
{

    public class DataProviderUoW<TEntity> : BaseUoW<TEntity>, IDataProviderUoW<TEntity> where TEntity : class, IEntity, new()
    {

        public DataProviderUoW(DbContext context) : base(context)
        {
        }


        public TEntity FindOne(int id)
        {
            return DbSet.Find(id);
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.SingleOrDefault(expression);
        }

        public virtual IQueryable<TEntity> FindAll()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<TEntity> FindSome(Expression<Func<TEntity, bool>> expression)
        {
            return FindAll().Where(expression);
        }

    }

}
