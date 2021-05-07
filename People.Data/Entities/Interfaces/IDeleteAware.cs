namespace People.Data.Entities.Interfaces
{
    public interface IDeleteAware : IModifyAware
    {
        bool Deleted { get; set; }
    }
}
