using AutoMapper;
using People.Data.Entities;
using People.Data.Interfaces;
using People.Data.UnitOfWorks;

namespace People.BusinessLogic.Services
{
    public class MeetingManager : BaseModelManager<Meeting>
    {

        public MeetingManager(IDataManagerUoW<Meeting> manager, MapperConfiguration mapperConfig)
            : base(manager, mapperConfig)
        {
        }

        public TModel Insert<TModel>(TModel model) where TModel : IEntity
        {
            return Mapper.Map<TModel>(Manager.Insert(model));
        }

        public TModel Update<TModel>(TModel model) where TModel : IEntity
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
