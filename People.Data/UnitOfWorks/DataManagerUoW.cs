using AutoMapper;
using People.Data.DTO;
using People.Data.Entities.Interfaces;
using People.Data.Interfaces;
using System;
using System.Data.Entity;

namespace People.Data.UnitOfWorks
{
    public class DataManagerUoW<TEntity> : BaseUoW<TEntity>, IDataManagerUoW<TEntity> where TEntity : class, IEntity, new()
    {
        protected readonly IMapper Mapper;
        public DataManagerUoW(DbContext context, MapperConfiguration mapperConfig) : base(context)
        {
            Mapper = new Mapper(mapperConfig);
        }

        public TEntity Create()
        {
            return DbSet.Create();
        }

        public TEntity Insert<TModel>(TModel model) where TModel: IEntity
        {
            var entity = Create();

            Mapper.Map(model, entity);

            if (entity is ICreateAware createAware)
            {
                createAware.SetCreated();
            }

            DbSet.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Update<TModel>(TModel model) where TModel: IEntity
        {
            var entity = DbSet.Find(model.Id);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            Mapper.Map(model, entity);
            if (entity is IModifyAware modifyAware)
            {
                modifyAware.SetModified();
            }

            DbSet.Add(entity);
            Context.SaveChanges();

            return entity;
        }

        public bool Delete(int id)
        {
            var entity = DbSet.Find(id);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            if (entity is ICannotDelete)
                throw new InvalidOperationException();
            
            if (entity is IDeleteAware deleteAware)
            {
                if (deleteAware.Deleted)
                    return true;
                deleteAware.SetDeleted();
            }
            else
                DbSet.Remove(entity);

            Context.SaveChanges();

            return Context.SaveChanges() > 0;
        }
    }
}
