using System;

namespace People.Data.Entities.Interfaces
{
    public interface ICreateAware
    {
        string CreatedBy { get; set; }
        DateTimeOffset CreatedOn { get; set; }
    }
}
