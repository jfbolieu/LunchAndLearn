using System;

namespace People.Data.Interfaces
{
    public interface IClient : IPerson
    {
        string Code { get; set; }
        DateTime Since { get; set; }
        string Email { get; set; }
    }
}