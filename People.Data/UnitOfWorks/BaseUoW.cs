using People.Data.Interfaces;
using System;
using System.Data.Entity;

namespace People.Data.UnitOfWorks
{
    public class BaseUoW<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly DbContext Context;
        protected DbSet<TEntity> DbSet => Context.Set<TEntity>();

        public BaseUoW(DbContext context)
        {
            Context = context;
        }
    }

}
