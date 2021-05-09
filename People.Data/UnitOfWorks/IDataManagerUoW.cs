using People.Data.Interfaces;

namespace People.Data.UnitOfWorks
{
    public interface IDataManagerUoW<TEntity>where TEntity : class, IEntity, new()
    {
        TEntity Create();
        bool Delete(int id);
        TEntity Insert<TModel>(TModel model) where TModel : IEntity;
        TEntity Update<TModel>(TModel model) where TModel : IEntity;
    }
}