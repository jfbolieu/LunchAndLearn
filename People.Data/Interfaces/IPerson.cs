using People.Data.Enums;
using System;

namespace People.Data.Interfaces
{
    public interface IPerson
    {
        DateTime BirthDate { get; set; }
        string FirstName { get; set; }
        Gender Gender { get; set; }
        string MiddleName { get; set; }
        string LastName { get; set; }
    }
}