using AutoMapper;
using People.Data.Interfaces;
using People.Data.UnitOfWorks;

namespace People.BusinessLogic.Services
{
    public abstract class BaseModelManager<T>: BaseService<T> where T: class, IEntity, new()
    {
        protected readonly IDataManagerUoW<T>  Manager;

        protected BaseModelManager(IDataManagerUoW<T> manager, IConfigurationProvider mapperConfig) : base(mapperConfig)
        {
            Manager = manager;
        }
        
    }
}
