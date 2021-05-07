using AutoMapper;
using People.Data.Entities;
using People.Data.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;


namespace People.BusinessLogic.Services
{
    public class LocationProvider : BaseProvider<Location>
    {

        public LocationProvider(IProvider<Location> provider, IConfigurationProvider mapperConfig)
            :base(provider, mapperConfig)
        {
        }
        private IQueryable<Location> GetLocations(params int[] provinces)
        {
            return provinces.Any() ?
                Provider.FindSome(x => provinces.Contains(x.ProvinceId)) :
                Provider.FindAll();
        }

        public ICollection<T> GetList<T>(params int[] provinces)
        {
            var result = GetLocations(provinces);
            return result.ProjectToArray<T>(MapperConfig);
        }

        public T GetOne<T>(int id)
        {
            var location = Provider.FindOne(id);
            return Mapper.Map<T>(location);
        }
        public T GetOne<T>(string name)
        {
            var location = Provider.FindOne(l => l.Name == name);
            return Mapper.Map<T>(location);
        }
    }
}
