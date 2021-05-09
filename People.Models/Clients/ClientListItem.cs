using People.Models.Interfaces;
using People.Models.Resources;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace People.Models
{
    public class ClientListItem : IWithFullName
    {
        [Editable(false)]
        [Key]
        [HiddenInput]
        public int Id { get; set; }
        [Display(ResourceType = typeof(ClientResources))]
        public string FullName { get; set; }
        [Display(ResourceType = typeof(ClientResources))]
        public string Code { get; set; }
    }
}
