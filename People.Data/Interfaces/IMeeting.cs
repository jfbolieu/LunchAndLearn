using System;

namespace People.Data.Interfaces
{
    public interface IMeeting
    {
        DateTime? ActualEndTime { get; set; }
        int AgentId { get; set; }
        int ClientId { get; set; }
        DateTime DateTime { get; set; }
        DateTime ExpectedEndTime { get; set; }
        int LocationId { get; set; }
    }
}