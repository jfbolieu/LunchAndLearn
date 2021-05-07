using People.Data.Enums;

namespace People.Data.Interfaces
{
    public interface IAgent : IPerson
    {
        Departement Departement { get; set; }
    }
}