using People.Data.Entities.Interfaces;
using People.Data.Interfaces;

namespace People.Data.UnitOfWorks
{
    public interface IManager<TEntity> : IProvider<TEntity>
        where TEntity : class, IEntity
    {
        TEntity Create();
        bool Delete(int id);
        TEntity Insert<TModel>(TModel model);
        TEntity Update<TModel>(TModel model) where TModel : IIdentified;
    }
}