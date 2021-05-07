using People.Data.Interfaces;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Agents.Web.Models
{
    public class MeetingModel : IMeeting, IIdentified
    {
        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Editable(true)]
        public int LocationId { get; set; }
        [Editable(false)]
        public string LocationName { get; set; }

        public int AgentId { get; set; }
        [Editable(false)]
        public string AgentName { get; set; }
        public int ClientId { get; set; }
        [Editable(false)]
        public string ClientName { get; set; }

        [Display(ResourceType = typeof(ClientResources))]
        [DisplayFormat(ConvertEmptyStringToNull = true, DataFormatString = "d")]
        [DataType(DataType.DateTime)]
        public DateTime DateTime { get; set; }

        [Display(ResourceType = typeof(ClientResources))]
        [DisplayFormat(ConvertEmptyStringToNull = true, DataFormatString = "d")]
        [DataType(DataType.DateTime)]
        public DateTime ExpectedEndTime { get; set; }

        [Display(ResourceType = typeof(ClientResources))]
        [DisplayFormat(ConvertEmptyStringToNull = true, DataFormatString = "d")]
        [DataType(DataType.DateTime)]
        public DateTime? ActualEndTime { get; set; }
    }
}