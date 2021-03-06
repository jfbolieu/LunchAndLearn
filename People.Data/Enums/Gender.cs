using People.Data.Resources;
using System.ComponentModel.DataAnnotations;

namespace People.Data.Enums
{
    public enum Gender
    {
        [Display(ResourceType =typeof(GenderResources))]
        Unknown,
        [Display(ResourceType =typeof(GenderResources))]
        Man,
        [Display(ResourceType =typeof(GenderResources))]
        Woman,
        [Display(ResourceType =typeof(GenderResources))]
        Other
    }
}
