using AutoMapper;
using People.Data.Entities;
using People.Data.UnitOfWorks;
using System;
using Client = People.Data.Entities.Client;
using System.Linq;
using People.Data.Interfaces;

namespace People.BusinessLogic.Services
{
    public class ClientService : ClientProvider
    {
        protected readonly IManager<Client> Manager;

        protected string ClientCode(int agentId)
        {
            var date = DateTime.UtcNow.Date;
            var count = ForAgents(agentId).Count(x => x.Since.Year == date.Year && x.Since.Month == date.Month) + 1;
            return $"CL-{date:yyMM}-{agentId:0000}-{count:000}";
        }

        public ClientService(IManager<Client> manager, IConfigurationProvider mapperConfig)
            : base(manager, mapperConfig)
        {
            Manager = manager;
        }

        public TModel Insert<TModel>(TModel model) where TModel : IClient
        {
            model.Code = ClientCode(model.AgentId);
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
