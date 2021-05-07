using AutoMapper;
using People.Data.DTO;
using People.Data.Entities.Interfaces;
using People.Data.Interfaces;
using System;
using System.Data.Entity;

namespace People.Data.UnitOfWorks
{
    public class Manager<TEntity> : Provider<TEntity>, IManager<TEntity> where TEntity : class, IEntity
    {
        protected readonly IMapper Mapper;
        public Manager(DbContext context, MapperConfiguration mapperConfig) : base(context)
        {
            Mapper = new Mapper(mapperConfig);
        }
        public TEntity Create()
        {
            return DbSet.Create();
        }

        public TEntity Insert<TModel>(TModel model)
        {
            var entity = Create();

            Mapper.Map(model, entity);

            if (TypeOf.IsCreateAware())
            {
                ((ICreateAware)entity).SetCreated();
            }

            DbSet.Add(entity);
            Context.SaveChanges();
            return entity;
        }

        public TEntity Update<TModel>(TModel model) where TModel: IIdentified
        {
            var entity = FindOne(model.Id);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            Mapper.Map(model, entity);
            if (TypeOf.IsModifyAware())
            {
                ((IModifyAware)entity).SetModified();
            }

            DbSet.Add(entity);
            Context.SaveChanges();

            return entity;
        }

        public bool Delete(int id)
        {
            if (TypeOf.CannotDelete())
            {
                throw new InvalidOperationException();
            }

            var entity = FindOne(id);
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));
            
            if (TypeOf.IsDeleteAware())
            {
                var deleteAware = ((IDeleteAware)entity);
                if (deleteAware.Deleted)
                    return true;
                deleteAware.SetDeleted();
            }
            else
            {
                DbSet.Remove(entity);
            }

            Context.SaveChanges();

            return Context.SaveChanges() > 0;
        }

    }
}
