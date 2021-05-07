using People.Data.Enums;
using People.Data.Interfaces;
using Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace People.BusinessLogic.Models
{

    public class ClientModel : IClient, IIdentified
    {
        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Editable(false)]
        [Display(ResourceType = typeof(ClientResources))]
        public string Code { get; set; }

        [Editable(false)]
        [Display(ResourceType = typeof(ClientResources))]
        [DisplayFormat(ConvertEmptyStringToNull = true, DataFormatString = "yyyy-MM-dd")]
        [DataType(DataType.Date)]
        public DateTime Since { get; set; }

        [Required]
        [Display(ResourceType = typeof(ClientResources))]
        public int AgentId { get; set; }

        [Required]
        [Display(ResourceType = typeof(ClientResources))]
        [MaxLength(1028), MinLength(1)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [Display(ResourceType = typeof(ClientResources))]
        [DisplayFormat(ConvertEmptyStringToNull = true, DataFormatString = "yyyy-MM-dd")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(ClientResources))]
        [MaxLength(100), MinLength(1)]
        public string FirstName { get; set; }

        [Required]
        [Display(ResourceType = typeof(ClientResources))]
        [EnumDataType(typeof(Gender))]
        public Gender Gender { get; set; }

        [Display(ResourceType = typeof(ClientResources))]
        [MaxLength(1)]
        public string Initial { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(ClientResources))]
        [MaxLength(100), MinLength(1)]
        public string LastName { get; set; }
    }
    public class ClientListItem
    {
        [Editable(false)]
        [Key]
        [HiddenInput]
        public int Id { get; set; }
        [Display(ResourceType = typeof(ClientResources))]
        public string FullName { get; set; }
        [Display(ResourceType = typeof(ClientResources))]
        public string Code { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string AgentId { get; set; }

        [Editable(false)]
        [Display(ResourceType = typeof(ClientResources), ShortName ="Agent")]
        public string AgentName { get; set; }
    }
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

    public class MeetingListItem
    {
        public int Id { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string Location { get; set; }
    }
}
