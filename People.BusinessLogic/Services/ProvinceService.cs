using AutoMapper;
using People.Data.Entities;
using People.Data.UnitOfWorks;
using System.Collections.Generic;
using System.Linq;
using System.Resources;

namespace People.BusinessLogic.Services
{
    public class ItemResponse
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }
    public class ProvinceService : BaseModelProvider<Province>
    {
        private readonly ResourceManager _resourcesManager;
        public ProvinceService(IDataProviderUoW<Province> provider, IConfigurationProvider mapperConfig)
            :base(provider, mapperConfig)
        {
            _resourcesManager = new ResourceManager(nameof(Resources.Province), typeof(Resources.Province).Assembly);
        }

        public ICollection<ItemResponse> GetAll()
        {
            return Provider.FindAll().ToList().Select(p => new ItemResponse
            {
                Text = _resourcesManager.GetString(p.Code),
                Value = p.Id
            }).OrderBy(x => x.Value).ToArray();
        }
    }
}
