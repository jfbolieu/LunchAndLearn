using AutoMapper;
using People.Data.UnitOfWorks;
using System;
using System.Linq;
using People.Data.Interfaces;
using People.Data.Entities;

namespace People.BusinessLogic.Services
{
    public class ClientManager : BaseModelManager<Client>
    {
        protected readonly IDataProviderUoW<Client> Provider;

        public ClientManager(IDataManagerUoW<Client> manager, IDataProviderUoW<Client> provider, IConfigurationProvider mapperConfig)
            : base(manager, mapperConfig)
        {
            Provider = provider;
        }

        protected string ClientCode()
        {
            var date = DateTime.UtcNow.Date;
            var count = Provider.FindAll().Count(x => x.Since.Year == date.Year && x.Since.Month == date.Month) + 1;
            return $"CL{date:yyMM}{count:0000}";
        }

        public TModel Insert<TModel>(TModel model) where TModel : IClient, IEntity
        {
            model.Code = ClientCode();
            return Mapper.Map<TModel>(Manager.Insert(model));
        }

        public TModel Update<TModel>(TModel model) where TModel : IClient,  IEntity
        {
            return Mapper.Map<TModel>(Manager.Update(model));
        }

        public bool Delete<TModel>(TModel model) where TModel : IEntity
        {
            return Delete(model.Id);
        }
        public bool Delete(int id)
        {
            return Manager.Delete(id);
        }
    }
}
