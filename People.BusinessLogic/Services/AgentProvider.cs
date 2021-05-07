using AutoMapper;
using People.Data.Enums;
using People.Data.UnitOfWorks;
using System.Collections.Generic;
using Agent = People.Data.Entities.Agent;
namespace People.BusinessLogic.Services
{
    public class AgentProvider : BaseProvider<Agent>
    {
        public AgentProvider(IProvider<Agent> provider, IConfigurationProvider mapperConfig) : base(provider, mapperConfig)
        {
        }

        public ICollection<T> GetAll<T>()
        {
            return Provider.FindAll().ProjectToArray<T>();
        }

        public ICollection<T> ForDepartement<T>(Departement departement)
        {
            return Provider.FindSome(x => x.Departement == departement).ProjectToArray<T>();
        }

        public T GetById<T>(int id)
        {
            return Mapper.Map<T>(Provider.FindOne(id));
        }

        public T GetByName<T>(string name)
        {
            return Mapper.Map<T>(Provider.FindOne(x => x.FirstName.Contains(name) || x.LastName.Contains(name)));
        }

    }
}
