using AutoMapper;
using People.Data.Interfaces;
using People.Data.UnitOfWorks;
using Location = People.Data.Entities.Location;

namespace People.BusinessLogic.Services
{
    public class LocationManager : BaseModelManager<Location>
    {


        public LocationManager(IDataManagerUoW<Location> manager, IConfigurationProvider mapperConfig)
            : base(manager, mapperConfig)
        {
        }

        public TModel Insert<TModel>(TModel model) where TModel : ILocation, IEntity
        {
            var result = Manager.Insert(model);
            return Mapper.Map<TModel>(result);
        }

        public TModel Update<TModel>(TModel model) where TModel : ILocation, IEntity
        {
            var result = Manager.Update(model);
            return Mapper.Map<TModel>(result);
        }
        public bool Delete<TModel>(TModel model) where TModel : ILocation, IEntity
        {
            return Delete(model.Id);
        }

        public bool Delete(int id)
        {
            return Manager.Delete(id);
        }
    }
}
