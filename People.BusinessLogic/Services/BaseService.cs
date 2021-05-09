using AutoMapper;
using People.Data.Interfaces;

namespace People.BusinessLogic.Services
{
    public abstract class BaseService<T> where T: class, IEntity, new()
    {
        protected Mapper Mapper => new Mapper(MapperConfig);
        protected readonly IConfigurationProvider MapperConfig;

        protected BaseService(IConfigurationProvider mapperConfig)
        {
            MapperConfig = mapperConfig;
        }

    }
}
