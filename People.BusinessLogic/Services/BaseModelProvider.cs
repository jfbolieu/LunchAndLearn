using AutoMapper;
using People.Data.Interfaces;
using People.Data.UnitOfWorks;

namespace People.BusinessLogic.Services
{
    public abstract class BaseModelProvider<T>: BaseService<T> where T: class, IEntity, new()
    {
        protected readonly IDataProviderUoW<T>  Provider;

        protected BaseModelProvider(IDataProviderUoW<T> provider, IConfigurationProvider mapperConfig) : base(mapperConfig)
        {
            Provider = provider;
        }
        
    }
}
