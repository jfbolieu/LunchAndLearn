using People.Data.Interfaces;

namespace People.Data.Entities.Interfaces
{
    public interface IDimension :IEntity
    {
        string Code { get; set; }
    }
}