using System;

namespace People.Data.Entities.Interfaces
{
    public interface IModifyAware : ICreateAware
    {
        string ModifiedBy { get; set; }
        DateTimeOffset? ModifiedOn { get; set; }
    }
}
