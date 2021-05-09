using People.Data.Enums;
using People.Models.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace People.Models
{
    public class ClientDetail : ClientListItem
    {
        public Gender Gender { get; set; }
        [Display(ResourceType = typeof(ClientResources))]
        [DisplayFormat(ConvertEmptyStringToNull = true, DataFormatString = "yyyy-MM-dd")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public ICollection<MeetingListItem> Meetings { get; set; }
    }
}
