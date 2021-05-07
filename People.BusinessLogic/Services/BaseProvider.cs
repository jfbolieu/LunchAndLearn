using AutoMapper;
using People.Data.Entities.Interfaces;
using People.Data.UnitOfWorks;

namespace People.BusinessLogic.Services
{
    public abstract class BaseProvider<T> where T: class, IEntity
    {
        protected readonly IConfigurationProvider MapperConfig;
        protected readonly IProvider<T>  Provider;
        protected Mapper Mapper => new Mapper(MapperConfig);

        protected BaseProvider(IProvider<T> provider, IConfigurationProvider mapperConfig)
        {
            Provider = provider;
            MapperConfig = mapperConfig;
        }
        
    }
}
