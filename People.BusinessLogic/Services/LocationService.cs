using AutoMapper;
using People.Data.Entities;
using People.Data.Interfaces;
using People.Data.UnitOfWorks;
using Location = People.Data.Entities.Location;

namespace People.BusinessLogic.Services
{
    public class LocationService : LocationProvider
    {

        private readonly IManager<Location> _manager;

        public LocationService(IManager<Location> manager, IConfigurationProvider mapperConfig)
            : base(manager, mapperConfig)
        {
            _manager = manager;
        }

        public TModel Insert<TModel>(TModel model) where TModel : ILocation
        {
            var result = _manager.Insert(model);
            return Mapper.Map<TModel>(result);
        }

        public TModel Update<TModel>(TModel model) where TModel : IIdentified
        {
            var result = _manager.Update(model);
            return Mapper.Map<TModel>(result);
        }
        public bool Delete<TModel>(TModel model) where TModel : IIdentified
        {
            return Delete(model.Id);
        }

        public bool Delete(int id)
        {
            return _manager.Delete(id);
        }
    }
}
