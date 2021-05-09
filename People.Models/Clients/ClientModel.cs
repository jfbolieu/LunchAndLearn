using People.Data.Enums;
using People.Data.Interfaces;
using People.Models.Resources;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace People.Models
{

    public class ClientModel : IClient, IEntity
    {
        [Editable(false)]
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Editable(false)]
        [Display(ResourceType = typeof(ClientResources))]
        [HiddenInput(DisplayValue = true)]
        public string Code { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(ClientResources))]
        [MaxLength(100), MinLength(1)]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(ClientResources))]
        [MaxLength(1)]
        public string MiddleName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(ClientResources))]
        [MaxLength(100), MinLength(1)]
        public string LastName { get; set; }

        [Required]
        [Display(ResourceType = typeof(ClientResources))]
        public Gender Gender { get; set; }

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

        [Display(ResourceType = typeof(ClientResources))]
        [DisplayFormat(ConvertEmptyStringToNull = true, DataFormatString = "yyyy-MM-dd")]
        [DataType(DataType.Date)]
        [HiddenInput(DisplayValue = true)]
        public DateTime Since { get; set; }

    }
}
