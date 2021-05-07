using AutoMapper;
using People.Data.Interfaces;
using People.Data.UnitOfWorks;
using Agent = People.Data.Entities.Agent;
namespace People.BusinessLogic.Services
{
    public class AgentService : AgentProvider
    {
        protected readonly IManager<Agent> Manager;

        public AgentService(IManager<Agent> manager, IConfigurationProvider mapperConfig)
            : base(manager, mapperConfig)
        {
            Manager = manager;
        }

        public TModel Insert<TModel>(TModel model) where TModel : IAgent
        {
            return Mapper.Map<TModel>(Manager.Insert(model));
        }

        public TModel Update<TModel>(TModel model) where TModel : IIdentified
        {
            return Mapper.Map<TModel>(Manager.Update(model));
        }
        public bool Delete<TModel>(TModel model) where TModel : IIdentified
        {
            return Delete(model.Id);
        }
        public bool Delete(int id)
        {
            return Manager.Delete(id);
        }
    }
}
