using People.Data.DTO;
using People.Data.Entities.Interfaces;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace People.Data.UnitOfWorks
{
    public class Provider<TEntity> : IProvider<TEntity> where TEntity : class, IEntity
    {

        protected readonly DbContext Context;
        protected Type TypeOf => typeof(TEntity);
        public Provider(DbContext context)
        {
            Context = context;
        }

        protected DbSet<TEntity> DbSet => Context.Set<TEntity>();

        public TEntity FindOne(int id)
        {
            return DbSet.Find(id);
        }

        public TEntity FindOne(Expression<Func<TEntity, bool>> expression)
        {
            return DbSet.SingleOrDefault(expression);
        }

        public IQueryable<TEntity> FindAll()
        {
            var result = DbSet.AsQueryable();
            if (TypeOf.IsDeleteAware())
                result = result.Where(x => !((IDeleteAware)x).Deleted);
            return result;
        }

        public IQueryable<TEntity> FindSome(Expression<Func<TEntity, bool>> expression)
        {
            return FindAll().Where(expression);
        }

    }
}
