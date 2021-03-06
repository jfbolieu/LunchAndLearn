using AutoMapper;
using People.Data.Entities;
using People.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;

namespace People.BusinessLogic.Services
{
    public class MeetingProvider : BaseModelProvider<Meeting>
    {

        public MeetingProvider(IDataProviderUoW<Meeting> provider, IConfigurationProvider mapperConfig)
            :base(provider, mapperConfig)
        {
        }

        public ICollection<TModel> GetAll<TModel>() where TModel : class
        {
            return Provider.FindAll().ProjectToArray<TModel>(MapperConfig);
        }

        private IQueryable<Meeting> ForAgent(params int[] agentIds)
        {
            return Provider.FindSome(x => agentIds.Contains(x.AgentId));
        }
        private IQueryable<Meeting> ForLocation(params int[] locationIds)
        {
            return Provider.FindSome(x => locationIds.Contains(x.LocationId));
        }
        private IQueryable<Meeting> ForClient(params int[] clientIds)
        {
            return Provider.FindSome(x => clientIds.Contains(x.ClientId));
        }
        private IQueryable<Meeting> ForDateRange(DateTimeOffset from, DateTimeOffset? to = null)
        {
            var result =  Provider.FindSome(x => x.DateTime >= from);

            return to.HasValue ? result.Where(x => x.DateTime < to) : result;

        }

        public ICollection<TModel> ForAgent<TModel>(int agentId) where TModel : class
        {
            return ForAgent(agentId).ProjectToArray<TModel>(MapperConfig);
        }

        public ICollection<TModel> ForClient<TModel>(int clientId) where TModel : class
        {
            return ForClient(clientId).ProjectToArray<TModel>(MapperConfig);
        }

        public ICollection<TModel> ForLocation<TModel>(int locationId) where TModel : class
        {
            return ForLocation(locationId).ProjectToArray<TModel>(MapperConfig);
        }

        public ICollection<TModel> ForDate<TModel>(DateTimeOffset date)
        {
            var to = date.AddDays(1);
            return ForDateRange(date, to).ProjectToArray<TModel>(MapperConfig);
        }

        public TModel FindOne<TModel>(int id)
        {
            return Mapper.Map<TModel>(Provider.FindOne(id));
        }
    }
}
