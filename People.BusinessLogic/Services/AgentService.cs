using AutoMapper;
using People.Data.Interfaces;
using People.Data.UnitOfWorks;
using Agent = People.Data.Entities.Agent;
namespace People.BusinessLogic.Services
{
    public class AgentService : BaseModelManager<Agent>
    {

        public AgentService(IDataManagerUoW<Agent> manager, IConfigurationProvider mapperConfig)
            : base(manager, mapperConfig)
        {
        }

        public TModel Insert<TModel>(TModel model) where TModel : IAgent, IEntity
        {
            return Mapper.Map<TModel>(Manager.Insert(model));
        }

        public TModel Update<TModel>(TModel model) where TModel : IAgent, IEntity
        {
            return Mapper.Map<TModel>(Manager.Update(model));
        }
        public bool Delete<TModel>(TModel model) where TModel : IAgent, IEntity
        {
            return Delete(model.Id);
        }
        public bool Delete(int id)
        {
            return Manager.Delete(id);
        }
    }
}
