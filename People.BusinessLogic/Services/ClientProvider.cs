using AutoMapper;
using People.Data.Entities;
using People.Data.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;

namespace People.BusinessLogic.Services
{
    public class ClientProvider : BaseProvider<Client>
    {

        public ClientProvider(IProvider<Client> provider, IConfigurationProvider mapperConfig)
            : base(provider, mapperConfig)
        {
        }

        public ICollection<T> GetAll<T>()
        {
            return Provider.FindAll().ProjectToArray<T>();
        }
        protected IQueryable<Client> ForAgents(params int[] agentIds)
        {
            return Provider.FindSome(x => agentIds.Contains(x.AgentId));
        }
        public ICollection<T> ForAgent<T>(int agentId)
        {
            return ForAgents(agentId).ProjectToArray<T>();
        }

        public T GetById<T>(int id)
        {
            return Mapper.Map<T>(Provider.FindOne(id));
        }
        public T GetByCode<T>(string code)
        {
            return Mapper.Map<T>(Provider.FindOne(x => x.Code.StartsWith(code)));
        }
        public T GetByEmail<T>(string email)
        {
            return Mapper.Map<T>(Provider.FindOne(x => x.Email == email));
        }

        public T GetByName<T>(string name)
        {
            return Mapper.Map<T>(Provider.FindOne(x => x.FirstName.Contains(name) || x.LastName.Contains(name)));
        }
    }
}
